using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;




namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=ADCLG1;Initial Catalog=Hotel_Urban_Stay;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = checkBox2.Checked ? '\0' : '*';
        }

        private void label4_Click(object sender, EventArgs e)
        {
            // Регистрация (пока пусто)
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox4.Text.Trim();
            string password = textBox2.Text.Trim();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT user_id, admin FROM USERS WHERE username = @username AND password = @password AND admin = 1";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int userId = reader.GetInt32(0);
                                AdminForm adminForm = new AdminForm();
                                adminForm.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Неверный логин, пароль или пользователь не является администратором.", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrationForm regForm = new RegistrationForm();
            regForm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string username = textBox3.Text.Trim();
            string password = textBox1.Text.Trim();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT user_id FROM USERS WHERE username = @username AND password = @password AND admin = 0";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int userId = reader.GetInt32(0);
                                MainForm mainForm = new MainForm(userId);
                                mainForm.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Неверный логин, пароль или пользователь не является гостем.", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}