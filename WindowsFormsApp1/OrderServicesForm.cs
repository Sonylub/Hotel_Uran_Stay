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
                    Size = new Size(280, 220),
                    Margin = new Padding(10),
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.White
                };

                Label lblName = new Label
                {
                    Text = name,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    Location = new Point(10, 10),
                    Size = new Size(260, 30),
                    ForeColor = Color.FromArgb(31, 41, 55)
                };

                Label lblPrice = new Label
                {
                    Text = $"{price:C2}",
                    Font = new Font("Segoe UI", 10, FontStyle.Regular),
                    Location = new Point(10, 40),
                    Size = new Size(260, 20),
                    ForeColor = Color.FromArgb(107, 114, 128)
                };

                Label lblDescription = new Label
                {
                    Text = shortDescription.Length > 100 ? shortDescription.Substring(0, 100) + "..." : shortDescription,
                    Font = new Font("Segoe UI", 9, FontStyle.Regular),
                    Location = new Point(10, 60),
                    Size = new Size(260, 80),
                    ForeColor = Color.FromArgb(107, 114, 128)
                };

                Button btnSelect = new Button
                {
                    Text = "Выбрать",
                    Font = new Font("Segoe UI", 10, FontStyle.Regular),
                    Location = new Point(180, 180),
                    Size = new Size(90, 30),
                    BackColor = Color.FromArgb(30, 64, 175),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Tag = serviceId
                };
                btnSelect.FlatAppearance.BorderSize = 0;
                btnSelect.Click += BtnSelectService_Click;

                card.Controls.AddRange(new Control[] { lblName, lblPrice, lblDescription, btnSelect });
                card.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(243, 244, 246);
                card.MouseLeave += (s, e) => card.BackColor = Color.White;

                flowLayoutPanelServices.Controls.Add(card);
            }
        }

        private void BtnSelectService_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            selectedServiceId = Convert.ToInt32(btn.Tag);
            UpdateDescription();
            HighlightSelectedCard();
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
                int serviceId = Convert.ToInt32(card.Controls.OfType<Button>().First().Tag);
                card.BorderStyle = serviceId == selectedServiceId ? BorderStyle.Fixed3D : BorderStyle.FixedSingle;
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

                            // Проверка, не заказана ли услуга ранее
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

                            // Вставка в GUESTSERVICES
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