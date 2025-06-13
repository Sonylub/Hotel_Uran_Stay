using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AvailableRoomsForm : Form
    {
        private string connectionString = "Data Source=ADCLG1;Initial Catalog=Hotel_Urban_Stay;Integrated Security=True";
        private int userId;
        private DataTable roomsTable;
        private List<string> roomImages;
        private int currentImageIndex;
        private int selectedRoomId = -1;

        public AvailableRoomsForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            roomImages = new List<string>();
            currentImageIndex = 0;
            LoadRooms();
            UpdateBookingButtonState();
        }


        private void LoadRooms()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT room_id, category, description, price, status, quantity, booked_quantity " +
                                   "FROM ROOMS WHERE status = 'Available' AND booked_quantity < quantity";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        roomsTable = new DataTable();
                        adapter.Fill(roomsTable);
                        PopulateRoomCards();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки номеров: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateRoomCards()
        {
            flowLayoutPanelRooms.Controls.Clear();
            foreach (DataRow row in roomsTable.Rows)
            {
                int roomId = Convert.ToInt32(row["room_id"]);
                string category = row["category"].ToString();
                string description = row["description"].ToString();
                decimal price = Convert.ToDecimal(row["price"]);
                int available = Convert.ToInt32(row["quantity"]) - Convert.ToInt32(row["booked_quantity"]);

                Panel card = new Panel
                {
                    Size = new Size(280, 320),
                    Margin = new Padding(10),
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.FromArgb(255, 255, 255)
                };

                PictureBox image = new PictureBox
                {
                    Size = new Size(280, 160),
                    Location = new Point(0, 0),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    ImageLocation = GetRoomImage(roomId)
                };

                Label lblCategory = new Label
                {
                    Text = category,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    Location = new Point(10, 170),
                    Size = new Size(260, 30),
                    ForeColor = Color.FromArgb(31, 41, 55)
                };

                Label lblPrice = new Label
                {
                    Text = $"{price:C2} / ночь",
                    Font = new Font("Segoe UI", 10, FontStyle.Regular),
                    Location = new Point(10, 200),
                    Size = new Size(260, 20),
                    ForeColor = Color.FromArgb(107, 114, 128)
                };

                Label lblDescription = new Label
                {
                    Text = description.Length > 50 ? description.Substring(0, 50) + "..." : description,
                    Font = new Font("Segoe UI", 9, FontStyle.Regular),
                    Location = new Point(10, 220),
                    Size = new Size(260, 40),
                    ForeColor = Color.FromArgb(107, 114, 128)
                };

                Label lblAvailable = new Label
                {
                    Text = $"Осталось: {available}",
                    Font = new Font("Segoe UI", 9, FontStyle.Italic),
                    Location = new Point(10, 260),
                    Size = new Size(260, 20),
                    ForeColor = available <= 2 ? Color.Red : Color.Green
                };

                Button btnSelect = new Button
                {
                    Text = "Выбрать",
                    Font = new Font("Segoe UI", 10, FontStyle.Regular),
                    Location = new Point(180, 280),
                    Size = new Size(90, 30),
                    BackColor = Color.FromArgb(30, 64, 175),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Tag = roomId
                };
                btnSelect.FlatAppearance.BorderSize = 0;
                btnSelect.Click += BtnSelectRoom_Click;

                card.Controls.AddRange(new Control[] { image, lblCategory, lblPrice, lblDescription, lblAvailable, btnSelect });
                card.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(243, 244, 246);
                card.MouseLeave += (s, e) => card.BackColor = Color.FromArgb(255, 255, 255);

                flowLayoutPanelRooms.Controls.Add(card);
            }
        }

        private string GetRoomImage(int roomId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT TOP 1 image_url FROM IMAGES WHERE room_id = @roomId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@roomId", roomId);
                        object result = cmd.ExecuteScalar();
                        return result?.ToString() ?? null;
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        private void BtnSelectRoom_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            selectedRoomId = Convert.ToInt32(btn.Tag);
            LoadImages(selectedRoomId);
            HighlightSelectedCard();
            UpdateBookingButtonState();
        }

        private void HighlightSelectedCard()
        {
            foreach (Panel card in flowLayoutPanelRooms.Controls)
            {
                int roomId = Convert.ToInt32(card.Controls.OfType<Button>().First().Tag);
                card.BorderStyle = roomId == selectedRoomId ? BorderStyle.Fixed3D : BorderStyle.FixedSingle;
            }
        }

        private void LoadImages(int roomId)
        {
            roomImages.Clear();
            currentImageIndex = 0;
            pictureBoxMainImage.Image = null;
            flowLayoutPanelThumbnails.Controls.Clear();

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
                                roomImages.Add(reader.GetString(0));
                            }
                        }
                    }
                }

                if (roomImages.Count > 0)
                {
                    UpdateImage();
                    PopulateThumbnails();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки изображений: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateImage()
        {
            if (roomImages.Count > 0 && currentImageIndex >= 0 && currentImageIndex < roomImages.Count)
            {
                pictureBoxMainImage.ImageLocation = roomImages[currentImageIndex];
            }
        }

        private void PopulateThumbnails()
        {
            flowLayoutPanelThumbnails.Controls.Clear();
            for (int i = 0; i < roomImages.Count; i++)
            {
                PictureBox thumb = new PictureBox
                {
                    Size = new Size(60, 60),
                    Margin = new Padding(5),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    ImageLocation = roomImages[i],
                    BorderStyle = i == currentImageIndex ? BorderStyle.Fixed3D : BorderStyle.FixedSingle,
                    Tag = i
                };
                thumb.Click += Thumbnail_Click;
                flowLayoutPanelThumbnails.Controls.Add(thumb);
            }
        }

        private void Thumbnail_Click(object sender, EventArgs e)
        {
            PictureBox thumb = (PictureBox)sender;
            currentImageIndex = Convert.ToInt32(thumb.Tag);
            UpdateImage();
            UpdateThumbnailBorders();
        }

        private void UpdateThumbnailBorders()
        {
            foreach (PictureBox thumb in flowLayoutPanelThumbnails.Controls)
            {
                int index = Convert.ToInt32(thumb.Tag);
                thumb.BorderStyle = index == currentImageIndex ? BorderStyle.Fixed3D : BorderStyle.FixedSingle;
            }
        }

        private void buttonBook_Click(object sender, EventArgs e)
        {
            if (selectedRoomId == -1)
            {
                MessageBox.Show("Выберите номер для бронирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime checkInDate = dateTimePickerCheckIn.Value;
            DateTime checkOutDate = dateTimePickerCheckOut.Value;
            string comment = textBoxComment.Text.Trim();

            if (checkInDate < DateTime.Today)
            {
                MessageBox.Show("Дата заезда не может быть раньше сегодняшнего дня.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (checkOutDate <= checkInDate)
            {
                MessageBox.Show("Дата выезда должна быть позже даты заезда.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comment.Length > 500)
            {
                MessageBox.Show("Комментарий не должен превышать 500 символов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            int guestId;
                            string getGuestIdQuery = "SELECT guest_id FROM GUESTS WHERE user_id = @userId";
                            using (SqlCommand cmd = new SqlCommand(getGuestIdQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@userId", userId);
                                object result = cmd.ExecuteScalar();
                                if (result == null)
                                {
                                    MessageBox.Show("Гость не найден. Пожалуйста, зарегистрируйтесь.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    transaction.Rollback();
                                    return;
                                }
                                guestId = Convert.ToInt32(result);
                            }

                            string checkAvailabilityQuery = "SELECT COUNT(*) FROM GUESTS WHERE room_id = @roomId " +
                                                           "AND (@checkInDate < check_out_date AND @checkOutDate > check_in_date)";
                            using (SqlCommand cmd = new SqlCommand(checkAvailabilityQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@roomId", selectedRoomId);
                                cmd.Parameters.AddWithValue("@checkInDate", checkInDate);
                                cmd.Parameters.AddWithValue("@checkOutDate", checkOutDate);
                                int count = (int)cmd.ExecuteScalar();
                                if (count > 0)
                                {
                                    MessageBox.Show("Номер занят на выбранные даты.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    transaction.Rollback();
                                    return;
                                }
                            }

                            string updateRoomsQuery = "UPDATE ROOMS SET quantity = quantity - 1, booked_quantity = booked_quantity + 1, " +
                                                     "status = CASE WHEN booked_quantity + 1 = quantity THEN 'Not Available' ELSE 'Available' END " +
                                                     "WHERE room_id = @roomId AND quantity > booked_quantity";
                            using (SqlCommand cmd = new SqlCommand(updateRoomsQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@roomId", selectedRoomId);
                                int rowsAffected = cmd.ExecuteNonQuery();
                                if (rowsAffected == 0)
                                {
                                    MessageBox.Show("Номер больше не доступен.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    transaction.Rollback();
                                    return;
                                }
                            }

                            string updateGuestsQuery = "UPDATE GUESTS SET room_id = @roomId, check_in_date = @checkInDate, " +
                                                      "check_out_date = @checkOutDate, comment = @comment, booking_date = @bookingDate " +
                                                      "WHERE guest_id = @guestId";
                            using (SqlCommand cmd = new SqlCommand(updateGuestsQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@roomId", selectedRoomId);
                                cmd.Parameters.AddWithValue("@checkInDate", checkInDate);
                                cmd.Parameters.AddWithValue("@checkOutDate", checkOutDate);
                                cmd.Parameters.AddWithValue("@comment", string.IsNullOrWhiteSpace(comment) ? (object)DBNull.Value : comment);
                                cmd.Parameters.AddWithValue("@bookingDate", DateTime.Now);
                                cmd.Parameters.AddWithValue("@guestId", guestId);
                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            MessageBox.Show("Номер успешно забронирован!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadRooms();
                            selectedRoomId = -1;
                            UpdateBookingButtonState();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Ошибка бронирования: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePickerCheckIn_ValueChanged(object sender, EventArgs e)
        {
            UpdateBookingButtonState();
        }

        private void dateTimePickerCheckOut_ValueChanged(object sender, EventArgs e)
        {
            UpdateBookingButtonState();
        }

        private void UpdateBookingButtonState()
        {
            buttonBook.Enabled = selectedRoomId != -1 && dateTimePickerCheckIn.Value >= DateTime.Today &&
                                dateTimePickerCheckOut.Value > dateTimePickerCheckIn.Value;
        }

        private void textBoxComment_TextChanged(object sender, EventArgs e)
        {
            UpdateBookingButtonState();
        }
    }
}