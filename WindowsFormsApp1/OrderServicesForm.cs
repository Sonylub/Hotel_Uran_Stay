using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class OrderServicesForm : Form
    {
        private string connectionString = "Data Source=DESKTOP-JEM6MVF;Initial Catalog=Hotel_Urban_Stay;Integrated Security=True";
        private int userId;
        private DataTable servicesTable;
        private int selectedServiceId = -1;
        private decimal selectedServicePrice = 0;

        public OrderServicesForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            LoadServices();
            UpdateOrderButtonState();
        }

        private void LoadServices()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT service_id, name, price, short_description, detailed_description FROM SERVICES";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        servicesTable = new DataTable();
                        adapter.Fill(servicesTable);
                        PopulateServiceCards();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки услуг: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateServiceCards()
        {
            flowLayoutPanelServices.Controls.Clear();
            foreach (DataRow row in servicesTable.Rows)
            {
                int serviceId = Convert.ToInt32(row["service_id"]);
                string name = row["name"].ToString();
                decimal price = Convert.ToDecimal(row["price"]);
                string shortDescription = row["short_description"].ToString();

                Panel card = new Panel
                {
                    Size = new Size(358, 220), // Начальная высота, будет пересчитана
                    Margin = new Padding(8), // 8+8=16px между карточками
                    BackColor = Color.FromArgb(60, 60, 64),
                    BorderStyle = BorderStyle.None
                };

                Label lblName = new Label
                {
                    Text = name,
                    Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold),
                    ForeColor = Color.White,
                    Location = new Point(10, 10),
                    Size = new Size(338, 30),
                    AutoSize = false
                };

                Label lblPrice = new Label
                {
                    Text = $"{price:F2} $",
                    Font = new Font("Segoe UI", 10F),
                    ForeColor = Color.White,
                    Location = new Point(10, 40),
                    AutoSize = true
                };

                Label lblTotalPrice = new Label
                {
                    Text = "Итого: 0.00 $",
                    Font = new Font("Segoe UI", 10F),
                    ForeColor = Color.White,
                    Location = new Point(10, 60),
                    AutoSize = true,
                    Visible = false // Скрыт до выбора услуги
                };

                Label lblDescription = new Label
                {
                    Text = shortDescription,
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = Color.LightGray,
                    Location = new Point(10, 80),
                    MaximumSize = new Size(338, 0), // Ограничение по ширине, высота автоматическая
                    AutoSize = true
                };

                Button btnSelect = new Button
                {
                    Text = "Выбрать",
                    Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                    BackColor = Color.FromArgb(47, 180, 90),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(248, 180),
                    Size = new Size(100, 30),
                    Tag = new { ServiceId = serviceId, Price = price }
                };
                btnSelect.FlatAppearance.BorderSize = 0;
                btnSelect.Click += BtnSelectService_Click;

                card.Controls.AddRange(new Control[] { lblName, lblPrice, lblTotalPrice, lblDescription, btnSelect });

                // Пересчёт высоты карточки
                int maxHeight = Math.Max(lblDescription.Bottom, btnSelect.Bottom) + 10; // Отступ снизу
                card.Size = new Size(358, maxHeight);

                flowLayoutPanelServices.Controls.Add(card);
            }
        }

        private void BtnSelectService_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            var tag = (dynamic)btn.Tag;
            selectedServiceId = tag.ServiceId;
            selectedServicePrice = tag.Price;
            UpdateDescription();
            HighlightSelectedCard();
            UpdateTotalPrice();
            UpdateOrderButtonState();
        }


        private void UpdateDescription()
        {
            DataRow[] rows = servicesTable.Select($"service_id = {selectedServiceId}");
            if (rows.Length > 0)
            {
                textBoxDescription.Text = rows[0]["detailed_description"].ToString();
            }
            else
            {
                textBoxDescription.Text = "";
            }
        }

        private void HighlightSelectedCard()
        {
            foreach (Panel card in flowLayoutPanelServices.Controls)
            {
                var btn = card.Controls.OfType<Button>().First();
                var tag = (dynamic)btn.Tag;
                int serviceId = tag.ServiceId;
                card.BackColor = serviceId == selectedServiceId ? Color.FromArgb(70, 70, 74) : Color.FromArgb(60, 60, 64);
                card.Controls.OfType<Label>().First(l => l.Name == "" && l.Location.Y == 60).Visible = serviceId == selectedServiceId;
            }
        }

        private void UpdateTotalPrice()
        {
            foreach (Panel card in flowLayoutPanelServices.Controls)
            {
                var btn = card.Controls.OfType<Button>().First();
                var tag = (dynamic)btn.Tag;
                int serviceId = tag.ServiceId;
                if (serviceId == selectedServiceId)
                {
                    var lblTotalPrice = card.Controls.OfType<Label>().First(l => l.Name == "" && l.Location.Y == 60);
                    decimal total = selectedServicePrice * numericUpDownQuantity.Value;
                    lblTotalPrice.Text = $"Итого: {total:F2} $";
                }
            }
        }

        private void buttonOrder_Click(object sender, EventArgs e)
        {
            if (selectedServiceId == -1)
            {
                MessageBox.Show("Выберите услугу для заказа.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int quantity = (int)numericUpDownQuantity.Value;

            if (quantity < 1)
            {
                MessageBox.Show("Укажите количество услуг не менее 1.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            // Получение guest_id
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

                            // Проверка существующего заказа
                            string checkOrderQuery = "SELECT COUNT(*) FROM GUESTSERVICES WHERE guest_id = @guestId AND service_id = @serviceId";
                            using (SqlCommand cmd = new SqlCommand(checkOrderQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@guestId", guestId);
                                cmd.Parameters.AddWithValue("@serviceId", selectedServiceId);
                                int count = (int)cmd.ExecuteScalar();
                                if (count > 0)
                                {
                                    MessageBox.Show("Эта услуга уже заказана. Обратитесь в поддержку для изменения заказа.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    transaction.Rollback();
                                    return;
                                }
                            }

                            // Вставка заказа
                            string insertOrderQuery = "INSERT INTO GUESTSERVICES (guest_id, service_id, order_date, quantity, status) " +
                                                     "VALUES (@guestId, @serviceId, @orderDate, @quantity, @status)";
                            using (SqlCommand cmd = new SqlCommand(insertOrderQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@guestId", guestId);
                                cmd.Parameters.AddWithValue("@serviceId", selectedServiceId);
                                cmd.Parameters.AddWithValue("@orderDate", DateTime.Now);
                                cmd.Parameters.AddWithValue("@quantity", quantity);
                                cmd.Parameters.AddWithValue("@status", "Ordered");
                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            MessageBox.Show("Услуга успешно заказана!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            selectedServiceId = -1;
                            selectedServicePrice = 0;
                            textBoxDescription.Text = "";
                            numericUpDownQuantity.Value = 1;
                            UpdateOrderButtonState();
                            PopulateServiceCards();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Ошибка заказа: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void numericUpDownQuantity_ValueChanged(object sender, EventArgs e)
        {
            UpdateOrderButtonState();
        }

        private void UpdateOrderButtonState()
        {
            buttonOrder.Enabled = selectedServiceId != -1 && numericUpDownQuantity.Value >= 1;
        }
    }
}