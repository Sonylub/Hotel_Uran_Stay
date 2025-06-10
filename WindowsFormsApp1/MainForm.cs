using System;
using System.Data.SqlClient;
using System.Windows.Forms;

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
            MessageBox.Show($"Открывается форма для просмотра бронирований (user_id: {userId}).", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Пример: MyBookingsForm form = new MyBookingsForm(userId);
            // form.ShowDialog();
        }

        private void buttonMyServices_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Открывается форма для просмотра услуг (user_id: {userId}).", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Пример: MyServicesForm form = new MyServicesForm(userId);
            // form.ShowDialog();
        }

        private void buttonOrderServices_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Открывается форма для заказа дополнительных услуг.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Пример: OrderServicesForm form = new OrderServicesForm(userId);
            // form.ShowDialog();
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