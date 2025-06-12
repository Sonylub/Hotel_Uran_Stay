using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class RegistrationForm : Form
    {
        private string connectionString = "Data Source=DESKTOP-JEM6MVF;Initial Catalog=Hotel_Urban_Stay;Integrated Security=True";

        public RegistrationForm()
        {
            InitializeComponent();
            SetPlaceholders();
        }

        private void SetPlaceholders()
        {
            textBoxUsername.Text = "Введите логин";
            textBoxUsername.ForeColor = System.Drawing.Color.Gray;
            textBoxPassword.Text = "Введите пароль";
            textBoxPassword.ForeColor = System.Drawing.Color.Gray;
            textBoxFirstName.Text = "Введите имя";
            textBoxFirstName.ForeColor = System.Drawing.Color.Gray;
            textBoxEmail.Text = "example@domain.com";
            textBoxEmail.ForeColor = System.Drawing.Color.Gray;
            textBoxPhone.Text = "+7(123)456-78-90";
            textBoxPhone.ForeColor = System.Drawing.Color.Gray;
        }

        private void textBoxUsername_Enter(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == "Введите логин")
            {
                textBoxUsername.Text = "";
                textBoxUsername.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void textBoxUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxUsername.Text))
            {
                textBoxUsername.Text = "Введите логин";
                textBoxUsername.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "Введите пароль")
            {
                textBoxPassword.Text = "";
                textBoxPassword.ForeColor = System.Drawing.Color.Black;
                textBoxPassword.PasswordChar = '*';
            }
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                textBoxPassword.Text = "Введите пароль";
                textBoxPassword.ForeColor = System.Drawing.Color.Gray;
                textBoxPassword.PasswordChar = '\0';
            }
        }

        private void textBoxFirstName_Enter(object sender, EventArgs e)
        {
            if (textBoxFirstName.Text == "Введите имя")
            {
                textBoxFirstName.Text = "";
                textBoxFirstName.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void textBoxFirstName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxFirstName.Text))
            {
                textBoxFirstName.Text = "Введите имя";
                textBoxFirstName.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void textBoxEmail_Enter(object sender, EventArgs e)
        {
            if (textBoxEmail.Text == "example@domain.com")
            {
                textBoxEmail.Text = "";
                textBoxEmail.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void textBoxEmail_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                textBoxEmail.Text = "example@domain.com";
                textBoxEmail.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void textBoxPhone_Enter(object sender, EventArgs e)
        {
            if (textBoxPhone.Text == "+7(123)456-78-90")
            {
                textBoxPhone.Text = "";
                textBoxPhone.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void textBoxPhone_Leave(object sender, EventArgs e)
        {
            if (textBoxPhone.Text == "+7(123)456-78-90" || string.IsNullOrWhiteSpace(textBoxPhone.Text))
            {
                textBoxPhone.Text = "+7(123)456-78-90";
                textBoxPhone.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPassword.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || email == "example@domain.com")
                return true; // Email is optional
            string pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            return Regex.IsMatch(email, pattern);
        }

        private bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone) || phone == "+7(123)456-78-90")
                return true; // Phone is optional
            string pattern = @"^\+?\d{1,3}?[-.\s]?\(?\d{3}\)?[-.\s]?\d{3}[-.\s]?\d{2}[-.\s]?\d{2}$";
            return Regex.IsMatch(phone, pattern);
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text.Trim();
            string name = textBoxFirstName.Text.Trim();
            string email = textBoxEmail.Text.Trim();
            string phone = textBoxPhone.Text.Trim();

            if (username == "Введите логин" || string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Логин обязателен для заполнения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password == "Введите пароль" || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пароль обязателен для заполнения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (name == "Введите имя" || string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Имя обязательно для заполнения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Некорректный формат почты.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidPhone(phone))
            {
                MessageBox.Show("Некорректный формат телефона.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Получение следующего user_id
                    int userId;
                    string getUserIdQuery = "SELECT ISNULL(MAX(user_id), 0) + 1 FROM USERS";
                    using (SqlCommand cmdUserId = new SqlCommand(getUserIdQuery, conn))
                    {
                        userId = (int)cmdUserId.ExecuteScalar();
                    }

                    // Получение следующего guest_id
                    int guestId;
                    string getGuestIdQuery = "SELECT ISNULL(MAX(guest_id), 0) + 1 FROM GUESTS";
                    using (SqlCommand cmdGuestId = new SqlCommand(getGuestIdQuery, conn))
                    {
                        guestId = (int)cmdGuestId.ExecuteScalar();
                    }

                    // Проверка уникальности username
                    string checkQuery = "SELECT COUNT(*) FROM USERS WHERE username = @username";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@username", username);
                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Пользователь с таким логином уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Вставка в USERS и GUESTS
                    string query = "INSERT INTO USERS (user_id, username, admin, password) VALUES (@userId, @username, 0, @password); " +
                                   "INSERT INTO GUESTS (guest_id, user_id, name, email, phone) VALUES (@guestId, @userId, @name, @email, @phone);";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@guestId", guestId);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@email", email == "example@domain.com" ? (object)DBNull.Value : email);
                        cmd.Parameters.AddWithValue("@phone", phone == "+7(123)456-78-90" ? (object)DBNull.Value : phone);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Регистрация успешно завершена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при регистрации: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}