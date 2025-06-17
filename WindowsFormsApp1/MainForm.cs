using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        private string connectionString = "Data Source=DESKTOP-JEM6MVF;Initial Catalog=Hotel_Urban_Stay;Integrated Security=True";
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
                            MessageBox.Show($"Добро пожаловать, {result.ToString()}!", "Приветствие", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Добро пожаловать, Гость!", "Приветствие", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            AvailableRoomsForm availableRoomsForm = new AvailableRoomsForm(this.userId);
            availableRoomsForm.Show();
        }

        private void buttonPersonalAccount_Click(object sender, EventArgs e)
        {
            FormLK formLK = new FormLK(userId);
            formLK.Location = this.Location;
            formLK.ShowDialog();
        }

        private void buttonOrderServices_Click(object sender, EventArgs e)
        {
            OrderServicesForm servicesForm = new OrderServicesForm(userId);
            servicesForm.ShowDialog();
        }

        private void buttonReviews_Click(object sender, EventArgs e)
        {
            ReviewsForm reviewsForm = new ReviewsForm(userId);
            reviewsForm.Location = this.Location;
            reviewsForm.ShowDialog();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}