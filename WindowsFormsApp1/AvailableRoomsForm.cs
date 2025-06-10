using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AvailableRoomsForm : Form
    {
        private string connectionString = "Data Source=ADCLG1;Initial Catalog=Hotel_Urban_Stay;Integrated Security=True";
        private int userId;
        private DataTable roomsTable;

        public AvailableRoomsForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
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
            pictureBoxRoom.Image = null; // Очистка изображения
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
                        if (result != null)
                        {
                            // Заглушка: предполагается, что image_url доступен локально или через URL
                            // Для реальной загрузки используйте WebClient или PictureBox.Load
                            pictureBoxRoom.ImageLocation = result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки изображения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonBook_Click(object sender, EventArgs e)
        {
            if (dataGridViewRooms.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите номер для бронирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int roomId = Convert.ToInt32(dataGridViewRooms.SelectedRows[0].Cells["room_id"].Value);
            int quantity = Convert.ToInt32(dataGridViewRooms.SelectedRows[0].Cells["quantity"].Value);
            int bookedQuantity = Convert.ToInt32(dataGridViewRooms.SelectedRows[0].Cells["booked_quantity"].Value);

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
                                    return;
                                }
                                guestId = Convert.ToInt32(result);
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

                            // Обновление GUESTS (добавление room_id)
                            string updateGuestsQuery = "UPDATE GUESTS SET room_id = @roomId WHERE guest_id = @guestId";
                            using (SqlCommand cmd = new SqlCommand(updateGuestsQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@roomId", roomId);
                                cmd.Parameters.AddWithValue("@guestId", guestId);
                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            MessageBox.Show("Номер успешно забронирован!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadRooms(); // Обновить таблицу
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