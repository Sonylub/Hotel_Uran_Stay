using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class OrderServicesForm : Form
    {
        private string connectionString = "Data Source=DESKTOP-JEM6MVF;Initial Catalog=Hotel_Urban_Stay;Integrated Security=True";
        private int userId;
        private DataTable servicesTable;

        public OrderServicesForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            LoadServices();
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
                        dataGridViewServices.DataSource = servicesTable;
                        dataGridViewServices.Columns["service_id"].HeaderText = "ID";
                        dataGridViewServices.Columns["name"].HeaderText = "Название";
                        dataGridViewServices.Columns["price"].HeaderText = "Цена";
                        dataGridViewServices.Columns["short_description"].HeaderText = "Краткое описание";
                        dataGridViewServices.Columns["detailed_description"].Visible = false; // Скрыто, отображается в textBoxDescription
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки услуг: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewServices_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewServices.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridViewServices.SelectedRows[0].Index;
                textBoxDescription.Text = servicesTable.Rows[rowIndex]["detailed_description"].ToString();
            }
            else
            {
                textBoxDescription.Text = "";
            }
        }

        private void buttonOrder_Click(object sender, EventArgs e)
        {
            if (dataGridViewServices.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите услугу для заказа.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int serviceId = Convert.ToInt32(dataGridViewServices.SelectedRows[0].Cells["service_id"].Value);
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
                                cmd.Parameters.AddWithValue("@serviceId", serviceId);
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
                                cmd.Parameters.AddWithValue("@serviceId", serviceId);
                                cmd.Parameters.AddWithValue("@orderDate", DateTime.Now);
                                cmd.Parameters.AddWithValue("@quantity", quantity);
                                cmd.Parameters.AddWithValue("@status", "Ordered");
                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            MessageBox.Show("Услуга успешно заказана!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadServices(); // Обновить таблицу (если нужно)
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
    }
}