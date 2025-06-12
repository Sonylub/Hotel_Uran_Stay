using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AvailableRoomsForm : Form
    {
        private string connectionString = "Data Source=DESKTOP-JEM6MVF;Initial Catalog=Hotel_Urban_Stay;Integrated Security=True";
        private int userId;
        private DataTable roomsTable;
        private List<string> roomImages;
        private int currentImageIndex;

        public AvailableRoomsForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            roomImages = new List<string>();
            currentImageIndex = 0;
            LoadRooms();
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
                        dataGridViewRooms.DataSource = roomsTable;
                        dataGridViewRooms.Columns["room_id"].HeaderText = "ID";
                        dataGridViewRooms.Columns["category"].HeaderText = "Категория";
                        dataGridViewRooms.Columns["description"].HeaderText = "Описание";
                        dataGridViewRooms.Columns["price"].HeaderText = "Цена";
                        dataGridViewRooms.Columns["status"].HeaderText = "Статус";
                        dataGridViewRooms.Columns["quantity"].HeaderText = "Всего";
                        dataGridViewRooms.Columns["booked_quantity"].HeaderText = "Забронировано";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки номеров: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewRooms_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewRooms.SelectedRows.Count > 0)
            {
                int roomId = Convert.ToInt32(dataGridViewRooms.SelectedRows[0].Cells["room_id"].Value);
                LoadImages(roomId);
            }
        }

        private void LoadImages(int roomId)
        {
            roomImages.Clear();
            currentImageIndex = 0;
            pictureBoxRoom.Image = null;

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
                    UpdateImage(); // Исправлено: вызов UpdateImage вместо UpdateImageDisplay
                    buttonNextImage.Enabled = roomImages.Count > 1;
                    buttonPrevImage.Enabled = roomImages.Count > 1;
                }
                else
                {
                    buttonNextImage.Enabled = false;
                    buttonPrevImage.Enabled = false;
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
                pictureBoxRoom.ImageLocation = roomImages[currentImageIndex];
                // Для загрузки изображений через URL можно использовать WebClient:
                // using (var client = new System.Net.WebClient())
                // {
                //     byte[] imageData = client.DownloadData(roomImages[currentImageIndex]);
                //     using (var stream = new System.IO.MemoryStream(imageData))
                //     {
                //         pictureBoxRoom.Image = System.Drawing.Image.FromStream(stream);
                //     }
                // }
            }
        }

        private void buttonPrevImage_Click(object sender, EventArgs e)
        {
            if (currentImageIndex > 0)
            {
                currentImageIndex--;
                UpdateImage(); // Исправлено: вызов UpdateImage вместо UpdateImageDisplay
            }
        }

        private void buttonNextImage_Click(object sender, EventArgs e)
        {
            if (currentImageIndex < roomImages.Count - 1)
            {
                currentImageIndex++;
                UpdateImage(); // Исправлено: вызов UpdateImage вместо UpdateImageDisplay
            }
        }

        private void buttonBook_Click(object sender, EventArgs e)
        {
            if (dataGridViewRooms.SelectedRows.Count == 0)
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

            int roomId = Convert.ToInt32(dataGridViewRooms.SelectedRows[0].Cells["room_id"].Value);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Получение guest_id для текущего user_id
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

                            // Проверка доступности номера на выбранные даты
                            string checkAvailabilityQuery = "SELECT COUNT(*) FROM GUESTS WHERE room_id = @roomId " +
                                                           "AND (@checkInDate < check_out_date AND @checkOutDate > check_in_date)";
                            using (SqlCommand cmd = new SqlCommand(checkAvailabilityQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@roomId", roomId);
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

                            // Обновление ROOMS
                            string updateRoomsQuery = "UPDATE ROOMS SET quantity = quantity - 1, booked_quantity = booked_quantity + 1, " +
                                                     "status = CASE WHEN booked_quantity + 1 = quantity THEN 'Not Available' ELSE 'Available' END " +
                                                     "WHERE room_id = @roomId AND quantity > booked_quantity";
                            using (SqlCommand cmd = new SqlCommand(updateRoomsQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@roomId", roomId);
                                int rowsAffected = cmd.ExecuteNonQuery();
                                if (rowsAffected == 0)
                                {
                                    MessageBox.Show("Номер больше не доступен.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    transaction.Rollback();
                                    return;
                                }
                            }

                            // Обновление GUESTS
                            string updateGuestsQuery = "UPDATE GUESTS SET room_id = @roomId, check_in_date = @checkInDate, " +
                                                      "check_out_date = @checkOutDate, comment = @comment, booking_date = @bookingDate " +
                                                      "WHERE guest_id = @guestId";
                            using (SqlCommand cmd = new SqlCommand(updateGuestsQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@roomId", roomId);
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
    }
}