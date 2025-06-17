using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AvailableRoomsForm : Form
    {
        private string connectionString = "Data Source=DESKTOP-JEM6MVF;Initial Catalog=Hotel_Urban_Stay;Integrated Security=True";
        private int userId;
        private List<Room> rooms = new List<Room>();
        private int currentImageIndex = 0;
        private List<string> currentRoomImages = new List<string>();

        public AvailableRoomsForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            LoadRooms();
            lblSelectedRoom.Text = $"Доступные номера (User: {userId})"; ;
        }

        private void LoadRooms()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT room_id, category, description, price, quantity - booked_quantity AS available_quantity
                        FROM ROOMS
                        WHERE status = 'Available' AND quantity > booked_quantity";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            flowLayoutPanelRooms.Controls.Clear();
                            rooms.Clear();
                            while (reader.Read())
                            {
                                Room room = new Room
                                {
                                    RoomId = reader.GetInt32(0),
                                    Category = reader.GetString(1),
                                    Description = reader.GetString(2),
                                    Price = reader.GetDecimal(3),
                                    AvailableQuantity = reader.GetInt32(4)
                                };
                                rooms.Add(room);
                                CreateRoomCard(room);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки номеров: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateRoomCard(Room room)
        {
            Panel card = new Panel
            {
                Size = new Size(460, 100),
                BackColor = Color.FromArgb(60, 60, 64),
                Margin = new Padding(10)
            };

            Label lblCategory = new Label
            {
                Text = room.Category,
                Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(10, 10),
                AutoSize = true
            };

            Label lblDescription = new Label
            {
                Text = room.Description.Length > 50 ? room.Description.Substring(0, 50) + "..." : room.Description,
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.LightGray,
                Location = new Point(10, 35),
                Size = new Size(300, 40),
                AutoSize = false
            };

            Label lblPrice = new Label
            {
                Text = $"Цена: {room.Price:C}/ночь",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.White,
                Location = new Point(320, 10),
                AutoSize = true
            };

            Label lblQuantity = new Label
            {
                Text = $"Доступно: {room.AvailableQuantity}",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.White,
                Location = new Point(320, 35),
                AutoSize = true
            };

            Button btnSelect = new Button
            {
                Text = "Выбрать",
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                BackColor = Color.FromArgb(47, 180, 90),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(100, 30),
                Location = new Point(320, 60),
                Tag = room.RoomId
            };
            btnSelect.FlatAppearance.BorderSize = 0;
            btnSelect.Click += BtnSelect_Click;

            card.Controls.AddRange(new Control[] { lblCategory, lblDescription, lblPrice, lblQuantity, btnSelect });
            flowLayoutPanelRooms.Controls.Add(card);
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            int roomId = (int)((Button)sender).Tag;
            LoadImagesForRoom(roomId);
            currentImageIndex = 0;
            UpdateImageDisplay();
            lblSelectedRoom.Text = $"Выбран номер ID: {roomId}";
        }

        private void LoadImagesForRoom(int roomId)
        {
            currentRoomImages.Clear();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT image_url FROM IMAGES WHERE room_id = @roomId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@roomId", roomId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                currentRoomImages.Add(reader.GetString(0));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки изображений: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateImageDisplay()
        {
            if (currentRoomImages.Count > 0)
            {
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        byte[] imageData = client.DownloadData(currentRoomImages[currentImageIndex]);
                        using (var stream = new System.IO.MemoryStream(imageData))
                        {
                            pictureBoxSlider.Image = Image.FromStream(stream);
                        }
                    }
                    lblImageCounter.Text = $"{currentImageIndex + 1}/{currentRoomImages.Count}";
                }
                catch
                {
                    pictureBoxSlider.Image = null;
                    lblImageCounter.Text = "Изображение недоступно";
                }
            }
            else
            {
                pictureBoxSlider.Image = null;
                lblImageCounter.Text = "Нет изображений";
            }
        }

        private void btnPrevImage_Click(object sender, EventArgs e)
        {
            if (currentRoomImages.Count > 0)
            {
                currentImageIndex = (currentImageIndex - 1 + currentRoomImages.Count) % currentRoomImages.Count;
                UpdateImageDisplay();
            }
        }

        private void btnNextImage_Click(object sender, EventArgs e)
        {
            if (currentRoomImages.Count > 0)
            {
                currentImageIndex = (currentImageIndex + 1) % currentRoomImages.Count;
                UpdateImageDisplay();
            }
        }

        private void buttonBookRoom_Click(object sender, EventArgs e)
        {
            // Проверка выбран ли номер
            if (string.IsNullOrEmpty(lblSelectedRoom.Text) || lblSelectedRoom.Text == "Выберите номер")
            {
                MessageBox.Show("Пожалуйста, сначала выберите номер для бронирования.",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Получение roomId из метки
            int roomId;
            try
            {
                roomId = int.Parse(lblSelectedRoom.Text.Split(':')[1].Trim());
            }
            catch
            {
                MessageBox.Show("Ошибка при определении выбранного номера.",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка дат
            DateTime checkIn = dateTimePickerCheckIn.Value.Date;
            DateTime checkOut = dateTimePickerCheckOut.Value.Date;

            if (checkOut <= checkIn)
            {
                MessageBox.Show("Дата выезда должна быть позже даты заезда.",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string comment = textBoxComment.Text.Trim();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Проверяем существующее бронирование пользователя
                            string checkBookingQuery = @"
                        SELECT guest_id, room_id 
                        FROM GUESTS 
                        WHERE user_id = @userId 
                        AND check_in_date IS NOT NULL";

                            int existingGuestId = -1;
                            int? existingRoomId = null;

                            using (SqlCommand checkCmd = new SqlCommand(checkBookingQuery, conn, transaction))
                            {
                                checkCmd.Parameters.AddWithValue("@userId", this.userId);
                                using (SqlDataReader reader = checkCmd.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        existingGuestId = reader.GetInt32(0);
                                        if (!reader.IsDBNull(1))
                                        {
                                            existingRoomId = reader.GetInt32(1);
                                        }
                                    }
                                }
                            }

                            // 2. Если бронирование уже существует
                            if (existingGuestId != -1)
                            {
                                transaction.Commit();

                                string message = existingRoomId.HasValue ?
                                    $"У вас уже есть активное бронирование номера {existingRoomId.Value}." :
                                    "У вас уже есть активное бронирование.";

                                MessageBox.Show(message + "\nДля изменения бронирования обратитесь к администратору.",
                                              "Бронирование существует",
                                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                            // 3. Проверка доступности номера
                            string checkAvailabilityQuery = @"
                        SELECT quantity - booked_quantity 
                        FROM ROOMS 
                        WHERE room_id = @roomId 
                        AND status = 'Available'";

                            int available;
                            using (SqlCommand checkCmd = new SqlCommand(checkAvailabilityQuery, conn, transaction))
                            {
                                checkCmd.Parameters.AddWithValue("@roomId", roomId);
                                available = (int)checkCmd.ExecuteScalar();
                            }

                            if (available <= 0)
                            {
                                MessageBox.Show("Этот номер больше недоступен для бронирования.",
                                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            // 4. Обновляем запись гостя (если существует) или создаем новую
                            string updateOrInsertQuery;
                            SqlCommand cmd;

                            // Проверяем есть ли запись гостя с NULL значениями
                            string checkGuestQuery = "SELECT guest_id FROM GUESTS WHERE user_id = @userId AND room_id IS NULL";
                            int guestId = -1;

                            using (SqlCommand checkCmd = new SqlCommand(checkGuestQuery, conn, transaction))
                            {
                                checkCmd.Parameters.AddWithValue("@userId", this.userId);
                                object result = checkCmd.ExecuteScalar();
                                if (result != null)
                                {
                                    guestId = Convert.ToInt32(result);
                                }
                            }

                            if (guestId != -1)
                            {
                                // Обновляем существующую запись
                                updateOrInsertQuery = @"
                            UPDATE GUESTS SET
                                room_id = @roomId,
                                check_in_date = @checkIn,
                                check_out_date = @checkOut,
                                comment = @comment,
                                booking_date = @bookingDate
                            WHERE guest_id = @guestId";

                                cmd = new SqlCommand(updateOrInsertQuery, conn, transaction);
                                cmd.Parameters.AddWithValue("@guestId", guestId);
                            }
                            else
                            {
                                // Создаем новую запись
                                updateOrInsertQuery = @"
                            INSERT INTO GUESTS 
                                (user_id, room_id, check_in_date, check_out_date, comment, booking_date) 
                            VALUES 
                                (@userId, @roomId, @checkIn, @checkOut, @comment, @bookingDate)";

                                cmd = new SqlCommand(updateOrInsertQuery, conn, transaction);
                            }

                            // Общие параметры
                            cmd.Parameters.AddWithValue("@userId", this.userId);
                            cmd.Parameters.AddWithValue("@roomId", roomId);
                            cmd.Parameters.AddWithValue("@checkIn", checkIn);
                            cmd.Parameters.AddWithValue("@checkOut", checkOut);
                            cmd.Parameters.AddWithValue("@comment",
                                string.IsNullOrEmpty(comment) ? DBNull.Value : (object)comment);
                            cmd.Parameters.AddWithValue("@bookingDate", DateTime.Now);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected == 0)
                            {
                                throw new Exception("Не удалось обновить данные бронирования.");
                            }

                            // 5. Обновляем количество забронированных номеров
                            string updateRoomQuery = @"
                        UPDATE ROOMS 
                        SET booked_quantity = booked_quantity + 1 
                        WHERE room_id = @roomId";

                            using (SqlCommand updateCmd = new SqlCommand(updateRoomQuery, conn, transaction))
                            {
                                updateCmd.Parameters.AddWithValue("@roomId", roomId);
                                updateCmd.ExecuteNonQuery();
                            }

                            transaction.Commit();

                            MessageBox.Show("Номер успешно забронирован!", "Успех",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Обновление интерфейса
                            LoadRooms();
                            lblSelectedRoom.Text = "Выберите номер";
                            textBoxComment.Clear();
                            currentRoomImages.Clear();
                            pictureBoxSlider.Image = null;
                            lblImageCounter.Text = "0/0";
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Ошибка при бронировании: {ex.Message}",
                                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения: {ex.Message}",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class Room
    {
        public int RoomId { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int AvailableQuantity { get; set; }
    }
}