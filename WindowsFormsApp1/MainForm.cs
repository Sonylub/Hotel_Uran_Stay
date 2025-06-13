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
                        //labelWelcome.Text = result != null ? $"Добро пожаловать, {result}!" : "Добро пожаловать, Гость!";
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
            //panelContent.Controls.Clear();
            //var control = new AvailableRoomsControl(userId);
            //control.Dock = DockStyle.Fill;
            //panelContent.Controls.Add(control);
        }

        private void buttonPersonalAccount_Click(object sender, EventArgs e)
        {
            //panelContent.Controls.Clear();
            //var control = new PersonalAccountControl(userId);
            //control.Dock = DockStyle.Fill;
            //panelContent.Controls.Add(control);
        }

        private void buttonOrderServices_Click(object sender, EventArgs e)
        {
            //panelContent.Controls.Clear();
            ////var control = new OrderServicesControl(userId);
            //control.Dock = DockStyle.Fill;
            //panelContent.Controls.Add(control);
        }


        private void buttonReviews_Click(object sender, EventArgs e)
        {
            reviewsControl1.Controls.Clear();
            var control = new ReviewsControl(userId)
            {
                Dock = DockStyle.Fill,
                Visible = true
            };
            reviewsControl1.Controls.Add(control);
            reviewsControl1.Visible = true;
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