using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormLK : Form
    {
        private string connectionString = "Data Source=ADCLG1;Initial Catalog=Hotel_Urban_Stay;Integrated Security=True";
        private int userId;

        public FormLK(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            LoadProfile();
            LoadBookings();
            LoadServices();
        }

        private void LoadProfile()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Загружаем данные из USERS
                    string userQuery = "SELECT username FROM USERS WHERE user_id = @userId";
                    string username = string.Empty;
                    using (SqlCommand cmd = new SqlCommand(userQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        username = cmd.ExecuteScalar()?.ToString() ?? "Гость";
                    }

                    // Загружаем данные из GUESTS
                    string guestQuery = "SELECT name, email, phone FROM GUESTS WHERE user_id = @userId";
                    string name = string.Empty, email = string.Empty, phone = string.Empty;
                    using (SqlCommand cmd = new SqlCommand(guestQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                name = reader["name"] != DBNull.Value ? reader["name"].ToString() : string.Empty;
                                email = reader["email"] != DBNull.Value ? reader["email"].ToString() : string.Empty;
                                phone = reader["phone"] != DBNull.Value ? reader["phone"].ToString() : string.Empty;
                            }
                        }
                    }

                    // Заполняем профиль
                    lblUsername.Text = $"Имя пользователя: {username}";
                    lblName.Text = string.IsNullOrEmpty(name) ? "Имя: Не указано" : $"Имя: {name}";
                    lblEmail.Text = string.IsNullOrEmpty(email) ? "Email: Не указан" : $"Email: {email}";
                    lblPhone.Text = string.IsNullOrEmpty(phone) ? "Телефон: Не указан" : $"Телефон: {phone}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки профиля: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBookings()
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
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            flowLayoutPanelBookings.Controls.Clear();
                            if (dt.Rows.Count == 0)
                            {
                                Label lblNoBookings = new Label
                                {
                                    Text = "Нет активных бронирований",
                                    Font = new Font("Segoe UI", 12, FontStyle.Italic),
                                    ForeColor = Color.FromArgb(107, 114, 128),
                                    AutoSize = true,
                                    Location = new Point(10, 10)
                                };
                                flowLayoutPanelBookings.Controls.Add(lblNoBookings);
                                return;
                            }

                            CultureInfo usCulture = CultureInfo.CreateSpecificCulture("en-US");
                            foreach (DataRow row in dt.Rows)
                            {
                                Panel card = CreateBookingCard(row, usCulture);
                                flowLayoutPanelBookings.Controls.Add(card);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки бронирований: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Panel CreateBookingCard(DataRow row, CultureInfo culture)
        {
            DateTime checkIn = Convert.ToDateTime(row["check_in_date"]);
            DateTime checkOut = Convert.ToDateTime(row["check_out_date"]);
            int nights = (checkOut - checkIn).Days;
            decimal price = Convert.ToDecimal(row["price"]);
            decimal totalPrice = price * nights;
            string category = row["category"].ToString();
            string comment = row["comment"] != DBNull.Value ? row["comment"].ToString() : "Нет комментария";
            DateTime bookingDate = Convert.ToDateTime(row["booking_date"]);

            Panel card = new Panel
            {
                Size = new Size(380, 220),
                Margin = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };

            Label lblCategory = new Label
            {
                Text = $"Номер: {category}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(10, 10),
                Size = new Size(360, 30),
                ForeColor = Color.FromArgb(31, 41, 55)
            };

            Label lblDates = new Label
            {
                Text = $"Заезд: {checkIn:d} | Выезд: {checkOut:d}",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                Location = new Point(10, 40),
                Size = new Size(360, 20),
                ForeColor = Color.FromArgb(107, 114, 128)
            };

            Label lblNights = new Label
            {
                Text = $"Ночей: {nights}",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                Location = new Point(10, 60),
                Size = new Size(360, 20),
                ForeColor = Color.FromArgb(107, 114, 128)
            };

            Label lblPrice = new Label
            {
                Text = $"Цена за ночь: {(row["price"] != DBNull.Value ? Convert.ToDecimal(row["price"]) : 0):C2}",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                Location = new Point(10, 80),
                Size = new Size(360, 20),
                ForeColor = Color.FromArgb(107, 114, 128)
            };

            Label lblTotalPrice = new Label
            {
                Text = $"Общая стоимость: {totalPrice:C2}",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(10, 100),
                Size = new Size(360, 20),
                ForeColor = Color.FromArgb(31, 41, 55)
            };

            Label lblBookingDate = new Label
            {
                Text = $"Дата бронирования: {bookingDate:d}",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                Location = new Point(10, 120),
                Size = new Size(360, 20),
                ForeColor = Color.FromArgb(107, 114, 128)
            };

            Label lblComment = new Label
            {
                Text = $"Комментарий: {(comment.Length > 50 ? comment.Substring(0, 50) + "..." : comment)}",
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                Location = new Point(10, 140),
                Size = new Size(360, 40),
                ForeColor = Color.FromArgb(107, 114, 128)
            };

            Button btnDetails = new Button
            {
                Text = "Подробности",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                Location = new Point(280, 180),
                Size = new Size(90, 30),
                BackColor = Color.FromArgb(30, 64, 175),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnDetails.FlatAppearance.BorderSize = 0;
            btnDetails.Click += (s, e) => MessageBox.Show($"Полные данные бронирования:\n\n{category}\n{checkIn:d} - {checkOut:d}\n{totalPrice:C2}\n{comment}", "Подробности");

            card.Controls.AddRange(new Control[] { lblCategory, lblDates, lblNights, lblPrice, lblTotalPrice, lblBookingDate, lblComment, btnDetails });
            card.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(243, 244, 246);
            card.MouseLeave += (s, e) => card.BackColor = Color.White;

            return card;
        }

        private void LoadServices()
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
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            flowLayoutPanelServices.Controls.Clear();
                            if (dt.Rows.Count == 0)
                            {
                                Label lblNoServices = new Label
                                {
                                    Text = "Нет заказанных услуг",
                                    Font = new Font("Segoe UI", 12, FontStyle.Italic),
                                    ForeColor = Color.FromArgb(107, 114, 128),
                                    AutoSize = true,
                                    Location = new Point(10, 10)
                                };
                                flowLayoutPanelServices.Controls.Add(lblNoServices);
                                return;
                            }

                            CultureInfo usCulture = CultureInfo.CreateSpecificCulture("en-US");
                            foreach (DataRow row in dt.Rows)
                            {
                                Panel card = CreateServiceCard(row, usCulture);
                                flowLayoutPanelServices.Controls.Add(card);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки услуг: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Panel CreateServiceCard(DataRow row, CultureInfo culture)
        {
            string name = row["name"].ToString();
            decimal price = Convert.ToDecimal(row["price"]);
            int quantity = Convert.ToInt32(row["quantity"]);
            decimal totalPrice = price * quantity;
            string status = row["status"].ToString();
            string description = row["short_description"] != DBNull.Value ? row["short_description"].ToString() : "Нет описания";
            DateTime orderDate = Convert.ToDateTime(row["order_date"]);

            Panel card = new Panel
            {
                Size = new Size(380, 200),
                Margin = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };

            Label lblName = new Label
            {
                Text = $"Услуга: {name}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(10, 10),
                Size = new Size(360, 30),
                ForeColor = Color.FromArgb(31, 41, 55)
            };

            Label lblQuantity = new Label
            {
                Text = $"Количество: {quantity}",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                Location = new Point(10, 40),
                Size = new Size(360, 20),
                ForeColor = Color.FromArgb(107, 114, 128)
            };

            Label lblPrice = new Label
            {
                Text = $"Цена за единицу: {(row["price"] != DBNull.Value ? Convert.ToDecimal(row["price"]) : 0):C2}",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                Location = new Point(10, 60),
                Size = new Size(360, 20),
                ForeColor = Color.FromArgb(107, 114, 128)
            };

            Label lblTotalPrice = new Label
            {
                Text = $"Общая стоимость: {totalPrice:C2}",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(10, 80),
                Size = new Size(360, 20),
                ForeColor = Color.FromArgb(31, 41, 55)
            };

            Label lblStatus = new Label
            {
                Text = $"Статус: {status}",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                Location = new Point(10, 100),
                Size = new Size(360, 20),
                ForeColor = status == "Подтверждено" ? Color.Green : Color.FromArgb(107, 114, 128)
            };

            Label lblOrderDate = new Label
            {
                Text = $"Дата заказа: {orderDate:d}",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                Location = new Point(10, 120),
                Size = new Size(360, 20),
                ForeColor = Color.FromArgb(107, 114, 128)
            };

            Label lblDescription = new Label
            {
                Text = $"Описание: {(description.Length > 50 ? description.Substring(0, 50) + "..." : description)}",
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                Location = new Point(10, 140),
                Size = new Size(360, 20),
                ForeColor = Color.FromArgb(107, 114, 128)
            };

            Button btnDetails = new Button
            {
                Text = "Подробности",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                Location = new Point(280, 160),
                Size = new Size(90, 30),
                BackColor = Color.FromArgb(30, 64, 175),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnDetails.FlatAppearance.BorderSize = 0;
            btnDetails.Click += (s, e) => MessageBox.Show($"Полные данные услуги:\n\n{name}\n{quantity} x {price:C2}\n{totalPrice:C2}\n{status}\n{description}", "Подробности");

            card.Controls.AddRange(new Control[] { lblName, lblQuantity, lblPrice, lblTotalPrice, lblStatus, lblOrderDate, lblDescription, btnDetails });
            card.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(243, 244, 246);
            card.MouseLeave += (s, e) => card.BackColor = Color.White;

            return card;
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Функция редактирования профиля пока не реализована.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}