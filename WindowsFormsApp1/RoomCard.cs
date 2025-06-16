using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class RoomCard : UserControl
    {
        private PictureBox picRoom;
        private Label lblCategory, lblPrice, lblStatus, lblDesc, lblComment;
        private DateTimePicker dtpFrom, dtpTo;
        private TextBox txtComment;
        private Button btnBook, btnPrevImage, btnNextImage;
        private readonly int userId;
        private readonly string userName;
        private readonly string userEmail;
        private readonly string userPhone;
        private readonly string connectionString;
        private readonly int roomId;
        private List<string> imageUrls;
        private int currentImageIndex;
        private static readonly HttpClient httpClient = new HttpClient();

        public RoomCard(RoomData room, int userId, string userName, string userEmail, string userPhone, string connectionString)
        {
            this.userId = userId;
            this.userName = userName;
            this.userEmail = userEmail;
            this.userPhone = userPhone;
            this.connectionString = connectionString;
            this.roomId = room.RoomId;
            this.imageUrls = room.ImageUrls ?? new List<string>();
            this.currentImageIndex = 0;
            InitializeComponents();
            Populate(room);
            File.AppendAllText("debug.log", $"{DateTime.Now}: RoomCard created for RoomId {room.RoomId} with {imageUrls.Count} images\n");
        }

        private void InitializeComponents()
        {
            this.Size = new Size(500, 220);
            this.BackColor = Color.FromArgb(52, 52, 52); // #343434
            this.BorderStyle = BorderStyle.None;
            this.Visible = true;

            picRoom = new PictureBox
            {
                Size = new Size(150, 100),
                Location = new Point(10, 10),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.FromArgb(64, 64, 64),
                Visible = true
            };

            btnPrevImage = new Button
            {
                Text = "<",
                ForeColor = Color.White,
                BackColor = Color.FromArgb(47, 180, 90), // #2FBF5A
                FlatStyle = FlatStyle.Flat,
                Location = new Point(10, 115),
                Size = new Size(30, 25),
                Font = new Font("Segoe UI", 9),
                Cursor = Cursors.Hand,
                Visible = imageUrls.Count > 1
            };
            btnPrevImage.FlatAppearance.BorderSize = 0;
            btnPrevImage.Click += BtnPrevImage_Click;

            btnNextImage = new Button
            {
                Text = ">",
                ForeColor = Color.White,
                BackColor = Color.FromArgb(47, 180, 90), // #2FBF5A
                FlatStyle = FlatStyle.Flat,
                Location = new Point(120, 115),
                Size = new Size(30, 25),
                Font = new Font("Segoe UI", 9),
                Cursor = Cursors.Hand,
                Visible = imageUrls.Count > 1
            };
            btnNextImage.FlatAppearance.BorderSize = 0;
            btnNextImage.Click += BtnNextImage_Click;

            lblCategory = new Label
            {
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(170, 10),
                AutoSize = true,
                Visible = true
            };

            lblPrice = new Label
            {
                ForeColor = Color.FromArgb(47, 180, 90), // #2FBF5A
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(170, 35),
                AutoSize = true,
                Visible = true
            };

            lblStatus = new Label
            {
                ForeColor = Color.LightGray,
                Font = new Font("Segoe UI", 9),
                Location = new Point(170, 60),
                AutoSize = true,
                Visible = true
            };

            lblDesc = new Label
            {
                ForeColor = Color.LightGray,
                Font = new Font("Segoe UI", 8),
                Location = new Point(170, 80),
                Size = new Size(320, 60),
                AutoEllipsis = true,
                Visible = true
            };

            dtpFrom = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Location = new Point(170, 150),
                Size = new Size(100, 20),
                Font = new Font("Segoe UI", 8),
                Visible = true
            };

            dtpTo = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Location = new Point(280, 150),
                Size = new Size(100, 20),
                Font = new Font("Segoe UI", 8),
                Visible = true
            };

            lblComment = new Label
            {
                Text = "Комментарий",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 8),
                Location = new Point(170, 180),
                Size = new Size(60, 20),
                Visible = true
            };

            txtComment = new TextBox
            {
                Location = new Point(230, 180),
                Size = new Size(150, 30),
                Multiline = true,
                ForeColor = Color.White,
                BackColor = Color.FromArgb(64, 64, 64),
                Font = new Font("Segoe UI", 8),
                MaxLength = 200,
                BorderStyle = BorderStyle.FixedSingle,
                Visible = true
            };

            btnBook = new Button
            {
                Text = "Забронировать",
                ForeColor = Color.White,
                BackColor = Color.FromArgb(47, 180, 90), // #2FBF5A
                FlatStyle = FlatStyle.Flat,
                Location = new Point(390, 180),
                Size = new Size(100, 30),
                Font = new Font("Segoe UI", 9),
                Cursor = Cursors.Hand,
                Visible = true
            };
            btnBook.FlatAppearance.BorderSize = 0;
            btnBook.Click += BtnBook_Click;

            Controls.AddRange(new Control[]
            {
                picRoom, btnPrevImage, btnNextImage, lblCategory, lblPrice, lblStatus, lblDesc,
                dtpFrom, dtpTo, lblComment, txtComment, btnBook
            });
        }

        private void Populate(RoomData room)
        {
            lblCategory.Text = room.Category ?? "Нет категории";
            lblPrice.Text = $"{room.Price:C0}/ночь";
            lblStatus.Text = $"Свободно: {room.Quantity - room.BookedQuantity}/{room.Quantity}";
            lblDesc.Text = room.Description ?? "Нет описания";
            LoadCurrentImageAsync();
        }

        private async void LoadCurrentImageAsync()
        {
            if (imageUrls.Count == 0 || currentImageIndex < 0 || currentImageIndex >= imageUrls.Count)
            {
                picRoom.Image = null;
                picRoom.BackColor = Color.FromArgb(64, 64, 64); // Заглушка
                File.AppendAllText("debug.log", $"{DateTime.Now}: No images available for RoomId {roomId}\n");
                btnPrevImage.Visible = false;
                btnNextImage.Visible = false;
                return;
            }

            string imageUrl = imageUrls[currentImageIndex];
            if (!string.IsNullOrEmpty(imageUrl))
            {
                try
                {
                    using (HttpResponseMessage response = await httpClient.GetAsync(imageUrl))
                    {
                        response.EnsureSuccessStatusCode();
                        byte[] imageData = await response.Content.ReadAsByteArrayAsync();
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            picRoom.Image = Image.FromStream(ms);
                            File.AppendAllText("debug.log", $"{DateTime.Now}: Image loaded for RoomId {roomId}: {imageUrl}\n");
                        }
                    }
                }
                catch (Exception ex)
                {
                    picRoom.Image = null;
                    picRoom.BackColor = Color.FromArgb(64, 64, 64); // Заглушка
                    File.AppendAllText("debug.log", $"{DateTime.Now}: Failed to load image for RoomId {roomId}: {ex.Message}\n");
                }
            }
            btnPrevImage.Visible = imageUrls.Count > 1;
            btnNextImage.Visible = imageUrls.Count > 1;
        }

        private void BtnPrevImage_Click(object sender, EventArgs e)
        {
            if (imageUrls.Count > 1)
            {
                currentImageIndex = (currentImageIndex - 1 + imageUrls.Count) % imageUrls.Count;
                LoadCurrentImageAsync();
                File.AppendAllText("debug.log", $"{DateTime.Now}: Previous image selected for RoomId {roomId}, index {currentImageIndex}\n");
            }
        }

        private void BtnNextImage_Click(object sender, EventArgs e)
        {
            if (imageUrls.Count > 1)
            {
                currentImageIndex = (currentImageIndex + 1) % imageUrls.Count;
                LoadCurrentImageAsync();
                File.AppendAllText("debug.log", $"{DateTime.Now}: Next image selected for RoomId {roomId}, index {currentImageIndex}\n");
            }
        }

        private void BtnBook_Click(object sender, EventArgs e)
        {
            if (dtpTo.Value <= dtpFrom.Value)
            {
                MessageBox.Show("Дата выезда должна быть позже даты заезда.", "Ошибка",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Проверка доступности номера
                            string checkQuery = @"
                        SELECT COUNT(*) 
                        FROM GUESTS
                        WHERE room_id = @roomId 
                        AND (check_in_date <= @checkOut AND check_out_date >= @checkIn)";

                            using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn, transaction))
                            {
                                checkCmd.Parameters.AddWithValue("@roomId", roomId);
                                checkCmd.Parameters.AddWithValue("@checkIn", dtpFrom.Value);
                                checkCmd.Parameters.AddWithValue("@checkOut", dtpTo.Value);
                                int conflictCount = (int)checkCmd.ExecuteScalar();
                                if (conflictCount > 0)
                                {
                                    MessageBox.Show("Номер недоступен на выбранные даты.", "Ошибка",
                                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    transaction.Rollback();
                                    return;
                                }
                            }

                            // 2. Получаем следующий ID для гостя
                            int newGuestId;
                            string maxIdQuery = "SELECT ISNULL(MAX(guest_id), 0) + 1 FROM GUESTS";
                            using (SqlCommand cmd = new SqlCommand(maxIdQuery, conn, transaction))
                            {
                                newGuestId = (int)cmd.ExecuteScalar();
                            }

                            // 3. Создаем бронирование с указанием guest_id
                            string insertQuery = @"
                        INSERT INTO GUESTS 
                            (guest_id, room_id, user_id, name, email, phone, 
                             check_in_date, check_out_date, comment, booking_date)
                        VALUES 
                            (@guestId, @roomId, @userId, @name, @email, @phone, 
                             @checkIn, @checkOut, @comment, GETDATE())";

                            using (SqlCommand cmd = new SqlCommand(insertQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@guestId", newGuestId);
                                cmd.Parameters.AddWithValue("@roomId", roomId);
                                cmd.Parameters.AddWithValue("@userId", userId);
                                cmd.Parameters.AddWithValue("@name", userName ?? string.Empty);
                                cmd.Parameters.AddWithValue("@email", userEmail ?? string.Empty);
                                cmd.Parameters.AddWithValue("@phone", userPhone ?? string.Empty);
                                cmd.Parameters.AddWithValue("@checkIn", dtpFrom.Value);
                                cmd.Parameters.AddWithValue("@checkOut", dtpTo.Value);
                                cmd.Parameters.AddWithValue("@comment", txtComment.Text.Trim());

                                cmd.ExecuteNonQuery();
                            }

                            // 4. Обновляем количество забронированных номеров
                            string updateQuery = "UPDATE ROOMS SET booked_quantity = booked_quantity + 1 WHERE room_id = @roomId";
                            using (SqlCommand cmd = new SqlCommand(updateQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@roomId", roomId);
                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            MessageBox.Show($"Бронирование успешно выполнено! ID брони: {newGuestId}",
                                          "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ((AvailableRoomsForm)Parent).RefreshData();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            File.AppendAllText("error.log", $"{DateTime.Now}: Booking error: {ex.Message}\n");
                            MessageBox.Show($"Ошибка бронирования: {ex.Message}", "Ошибка",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText("error.log", $"{DateTime.Now}: DB connection error: {ex.Message}\n");
                MessageBox.Show("Ошибка подключения к базе данных.", "Ошибка",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private decimal CalculateTotalPrice()
        {
            decimal pricePerNight;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT price FROM ROOMS WHERE room_id = @roomId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@roomId", roomId);
                    pricePerNight = (decimal)cmd.ExecuteScalar();
                }
            }
            int days = (dtpTo.Value.Date - dtpFrom.Value.Date).Days;
            return pricePerNight * days;
        }
    }
}