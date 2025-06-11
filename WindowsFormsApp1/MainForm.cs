using System;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        private string connectionString = "Data Source=ADCLG1;Initial Catalog=Hotel_Urban_Stay;Integrated Security=True";
        private int userId;

        public MainForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            LoadUserName();
        }

        private void LoadUserName()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT name FROM GUESTS WHERE user_id = @userId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            labelWelcome.Text = $"Добро пожаловать, {result.ToString()}!";
                        }
                        else
                        {
                            labelWelcome.Text = "Добро пожаловать, Гость!";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки имени: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAvailableRooms_Click(object sender, EventArgs e)
        {
            AvailableRoomsForm form = new AvailableRoomsForm(userId);
            form.ShowDialog();
        }

        private void buttonMyBookings_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT G.guest_id, G.room_id, G.check_in_date, G.check_out_date, G.comment, G.booking_date, 
                               R.category, R.price
                        FROM GUESTS G
                        LEFT JOIN ROOMS R ON G.room_id = R.room_id
                        WHERE G.user_id = @userId AND G.room_id IS NOT NULL";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            StringBuilder message = new StringBuilder("Ваши бронирования:\n\n");
                            bool hasBookings = false;
                            CultureInfo usCulture = CultureInfo.CreateSpecificCulture("en-US");

                            while (reader.Read())
                            {
                                hasBookings = true;
                                DateTime checkIn = reader.GetDateTime(reader.GetOrdinal("check_in_date"));
                                DateTime checkOut = reader.GetDateTime(reader.GetOrdinal("check_out_date"));
                                int nights = (checkOut - checkIn).Days;
                                decimal price = reader.GetDecimal(reader.GetOrdinal("price"));
                                decimal totalPrice = price * nights;

                                message.AppendLine($"Номер: {reader["category"]}");
                                message.AppendLine($"Цена за ночь: {price.ToString("C2", usCulture)}");
                                message.AppendLine($"Количество ночей: {nights}");
                                message.AppendLine($"Общая стоимость: {totalPrice.ToString("C2", usCulture)}");
                                message.AppendLine($"Дата заезда: {checkIn:d}");
                                message.AppendLine($"Дата выезда: {checkOut:d}");
                                message.AppendLine($"Дата бронирования: {reader["booking_date"]:g}");
                                if (!reader.IsDBNull(reader.GetOrdinal("comment")))
                                {
                                    message.AppendLine($"Комментарий: {reader["comment"]}");
                                }
                                message.AppendLine("-------------------");
                            }

                            if (!hasBookings)
                            {
                                message.AppendLine("У вас нет активных бронирований.");
                            }

                            MessageBox.Show(message.ToString(), "Мои бронирования", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки бронирований: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonMyServices_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT GS.guest_id, GS.service_id, GS.order_date, GS.quantity, GS.status, 
                               S.name, S.price, S.short_description
                        FROM GUESTSERVICES GS
                        INNER JOIN SERVICES S ON GS.service_id = S.service_id
                        INNER JOIN GUESTS G ON GS.guest_id = G.guest_id
                        WHERE G.user_id = @userId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            StringBuilder message = new StringBuilder("Ваши заказанные услуги:\n\n");
                            bool hasServices = false;
                            CultureInfo usCulture = CultureInfo.CreateSpecificCulture("en-US");

                            while (reader.Read())
                            {
                                hasServices = true;
                                decimal price = reader.GetDecimal(reader.GetOrdinal("price"));
                                int quantity = reader.GetInt32(reader.GetOrdinal("quantity"));
                                decimal totalPrice = price * quantity;

                                message.AppendLine($"Услуга: {reader["name"]}");
                                message.AppendLine($"Цена за единицу: {price.ToString("C2", usCulture)}");
                                message.AppendLine($"Количество: {quantity}");
                                message.AppendLine($"Общая стоимость: {totalPrice.ToString("C2", usCulture)}");
                                message.AppendLine($"Дата заказа: {reader["order_date"]:g}");
                                message.AppendLine($"Статус: {reader["status"]}");
                                message.AppendLine($"Описание: {reader["short_description"]}");
                                message.AppendLine("-------------------");
                            }

                            if (!hasServices)
                            {
                                message.AppendLine("У вас нет заказанных услуг.");
                            }

                            MessageBox.Show(message.ToString(), "Мои услуги", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки услуг: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonOrderServices_Click(object sender, EventArgs e)
        {
            OrderServicesForm form = new OrderServicesForm(userId);
            form.ShowDialog();
        }

        private void buttonReviews_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Открывается форма для отзывов (user_id: {userId}).", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Пример: ReviewsForm form = new ReviewsForm(userId);
            // form.ShowDialog();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Close();
        }
    }
}