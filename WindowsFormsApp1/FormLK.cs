using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormLK : Form
    {
        private string connectionString = "Data Source=DESKTOP-JEM6MVF;Initial Catalog=Hotel_Urban_Stay;Integrated Security=True";
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
                                    ForeColor = Color.White,
                                    AutoSize = true,
                                    Location = new Point(10, 10)
                                };
                                flowLayoutPanelBookings.Controls.Add(lblNoBookings);
                                return;
                            }

                            foreach (DataRow row in dt.Rows)
                            {
                                Panel card = CreateBookingCard(row);
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

        private Panel CreateBookingCard(DataRow row)
        {
            int guestId = Convert.ToInt32(row["guest_id"]);
            int roomId = Convert.ToInt32(row["room_id"]);
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
                Size = new Size(730, 220), // Начальная высота, будет пересчитана
                Margin = new Padding(10),
                BackColor = Color.FromArgb(60, 60, 64)
            };

            Label lblCategory = new Label
            {
                Text = $"Номер: {category}",
                Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(10, 10),
                AutoSize = true
            };

            Label lblDates = new Label
            {
                Text = $"Заезд: {checkIn:d} | Выезд: {checkOut:d}",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.LightGray,
                Location = new Point(10, 35),
                AutoSize = true
            };

            Label lblNights = new Label
            {
                Text = $"Ночей: {nights}",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.LightGray,
                Location = new Point(10, 55),
                AutoSize = true
            };

            Label lblPrice = new Label
            {
                Text = $"Цена за ночь: {price:F2} $",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.LightGray,
                Location = new Point(10, 75),
                AutoSize = true
            };

            Label lblTotalPrice = new Label
            {
                Text = $"Общая стоимость: {totalPrice:F2} $",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(10, 95),
                AutoSize = true
            };

            Label lblBookingDate = new Label
            {
                Text = $"Дата бронирования: {bookingDate:d}",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.LightGray,
                Location = new Point(10, 115),
                AutoSize = true
            };

            Label lblComment = new Label
            {
                Text = $"Комментарий: {comment}",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.LightGray,
                Location = new Point(10, lblBookingDate.Bottom + 5), // 5px отступ
                MaximumSize = new Size(600, 0),
                AutoSize = true
            };

            Button btnDetails = new Button
            {
                Text = "Подробности",
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                BackColor = Color.FromArgb(47, 180, 90),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(510, 180),
                Size = new Size(100, 30),
                Tag = new { Category = category, CheckIn = checkIn, CheckOut = checkOut, TotalPrice = totalPrice, Comment = comment }
            };
            btnDetails.FlatAppearance.BorderSize = 0;
            btnDetails.Click += (s, e) =>
            {
                var tag = (dynamic)((Button)s).Tag;
                MessageBox.Show($"Полные данные бронирования:\n\n{tag.Category}\n{tag.CheckIn:d} - {tag.CheckOut:d}\n{tag.TotalPrice:F2} $\n{tag.Comment}", "Подробности");
            };

            Button btnCancelBooking = new Button
            {
                Text = "Отменить",
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                BackColor = Color.FromArgb(200, 50, 50),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(620, 180),
                Size = new Size(100, 30),
                Tag = new { GuestId = guestId, RoomId = roomId }
            };
            btnCancelBooking.FlatAppearance.BorderSize = 0;
            btnCancelBooking.Click += BtnCancelBooking_Click;

            card.Controls.AddRange(new Control[] { lblCategory, lblDates, lblNights, lblPrice, lblTotalPrice, lblBookingDate, lblComment, btnDetails, btnCancelBooking });

            // Пересчёт высоты карточки
            int maxHeight = Math.Max(lblComment.Bottom, btnDetails.Bottom) + 10; // Отступ снизу
            card.Size = new Size(730, maxHeight);

            return card;
        }

        private void BtnCancelBooking_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var tag = (dynamic)btn.Tag;
            int guestId = tag.GuestId;
            int roomId = tag.RoomId;

            DialogResult result = MessageBox.Show("Вы уверены, что хотите отменить бронирование?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Проверка на наличие активных услуг
                            string checkServicesQuery = "SELECT COUNT(*) FROM GUESTSERVICES WHERE guest_id = @guestId";
                            using (SqlCommand cmd = new SqlCommand(checkServicesQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@guestId", guestId);
                                int serviceCount = (int)cmd.ExecuteScalar();
                                if (serviceCount > 0)
                                {
                                    MessageBox.Show("У вас есть активные услуги. Пожалуйста, отмените их перед отменой бронирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }

                            // Очистка полей бронирования
                            string updateGuestQuery = @"
                                UPDATE GUESTS 
                                SET room_id = NULL, check_in_date = NULL, check_out_date = NULL, comment = NULL, booking_date = NULL 
                                WHERE guest_id = @guestId AND user_id = @userId";
                            using (SqlCommand cmd = new SqlCommand(updateGuestQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@guestId", guestId);
                                cmd.Parameters.AddWithValue("@userId", userId);
                                int rowsAffected = cmd.ExecuteNonQuery();
                                if (rowsAffected == 0)
                                {
                                    throw new Exception("Бронирование не найдено или не принадлежит пользователю.");
                                }
                            }

                            // Уменьшение booked_quantity
                            string updateRoomQuery = "UPDATE ROOMS SET booked_quantity = booked_quantity - 1 WHERE room_id = @roomId";
                            using (SqlCommand cmd = new SqlCommand(updateRoomQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@roomId", roomId);
                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            MessageBox.Show("Бронирование успешно отменено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadBookings();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Ошибка отмены бронирования: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                                    ForeColor = Color.White,
                                    AutoSize = true,
                                    Location = new Point(10, 10)
                                };
                                flowLayoutPanelServices.Controls.Add(lblNoServices);
                                return;
                            }

                            foreach (DataRow row in dt.Rows)
                            {
                                Panel card = CreateServiceCard(row);
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

        private Panel CreateServiceCard(DataRow row)
        {
            int guestId = Convert.ToInt32(row["guest_id"]);
            int serviceId = Convert.ToInt32(row["service_id"]);
            string name = row["name"].ToString();
            decimal price = Convert.ToDecimal(row["price"]);
            int quantity = Convert.ToInt32(row["quantity"]);
            decimal totalPrice = price * quantity;
            string status = row["status"].ToString();
            string description = row["short_description"] != DBNull.Value ? row["short_description"].ToString() : "Нет описания";
            DateTime orderDate = Convert.ToDateTime(row["order_date"]);

            Panel card = new Panel
            {
                Size = new Size(357, 200), // Начальная высота, будет пересчитана
                Margin = new Padding(4), // 4+4=8px между карточками
                BackColor = Color.FromArgb(60, 60, 64)
            };

            Label lblName = new Label
            {
                Text = $"Услуга: {name}",
                Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(10, 10),
                AutoSize = true
            };

            Label lblQuantity = new Label
            {
                Text = $"Количество: {quantity}",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.LightGray,
                Location = new Point(10, 35),
                AutoSize = true
            };

            Label lblPrice = new Label
            {
                Text = $"Цена за единицу: {price:F2} $",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.LightGray,
                Location = new Point(10, 55),
                AutoSize = true
            };

            Label lblTotalPrice = new Label
            {
                Text = $"Общая стоимость: {totalPrice:F2} $",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(10, 75),
                AutoSize = true
            };

            Label lblStatus = new Label
            {
                Text = $"Статус: {status}",
                Font = new Font("Segoe UI", 10F),
                ForeColor = status == "Подтверждено" ? Color.Green : Color.LightGray,
                Location = new Point(10, 95),
                AutoSize = true
            };

            Label lblOrderDate = new Label
            {
                Text = $"Дата заказа: {orderDate:d}",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.LightGray,
                Location = new Point(10, 115),
                AutoSize = true
            };

            Label lblDescription = new Label
            {
                Text = $"Описание: {description}",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.LightGray,
                Location = new Point(10, 135),
                MaximumSize = new Size(337, 0),
                AutoSize = true
            };

            Button btnDetails = new Button
            {
                Text = "Подробности",
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                BackColor = Color.FromArgb(47, 180, 90),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(137, 160),
                Size = new Size(100, 30),
                Tag = new { Name = name, Quantity = quantity, Price = price, TotalPrice = totalPrice, Status = status, Description = description }
            };
            btnDetails.FlatAppearance.BorderSize = 0;
            btnDetails.Click += (s, e) =>
            {
                var tag = (dynamic)((Button)s).Tag;
                MessageBox.Show($"Полные данные услуги:\n\n{tag.Name}\n{tag.Quantity} x {tag.Price:F2} $\n{tag.TotalPrice:F2} $\n{tag.Status}\n{tag.Description}", "Подробности");
            };

            Button btnCancelService = new Button
            {
                Text = "Отменить",
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                BackColor = Color.FromArgb(200, 50, 50),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(247, 160),
                Size = new Size(100, 30),
                Tag = new { GuestId = guestId, ServiceId = serviceId }
            };
            btnCancelService.FlatAppearance.BorderSize = 0;
            btnCancelService.Click += BtnCancelService_Click;

            card.Controls.AddRange(new Control[] { lblName, lblQuantity, lblPrice, lblTotalPrice, lblStatus, lblOrderDate, lblDescription, btnDetails, btnCancelService });

            // Пересчёт высоты карточки
            int maxHeight = Math.Max(lblDescription.Bottom, btnDetails.Bottom) + 10; // Отступ снизу
            card.Size = new Size(357, maxHeight);

            return card;
        }

        private void BtnCancelService_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var tag = (dynamic)btn.Tag;
            int guestId = tag.GuestId;
            int serviceId = tag.ServiceId;

            DialogResult result = MessageBox.Show("Вы уверены, что хотите отменить услугу?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM GUESTSERVICES WHERE guest_id = @guestId AND service_id = @serviceId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@guestId", guestId);
                        cmd.Parameters.AddWithValue("@serviceId", serviceId);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            MessageBox.Show("Услуга не найдена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    MessageBox.Show("Услуга успешно отменена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadServices();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка отмены услуги: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Функция редактирования профиля пока не реализована.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}