using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ReviewsForm : Form
    {
        private string connectionString = "Data Source=DESKTOP-JEM6MVF;Initial Catalog=Hotel_Urban_Stay;Integrated Security=True";
        private int userId;
        private DataTable reviewsTable;

        public ReviewsForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            LoadReviews();
        }

        private void LoadReviews()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT R.review_id, R.guest_id, R.rating, R.comment, R.created_at, G.name
                        FROM REVIEWS R
                        INNER JOIN GUESTS G ON R.guest_id = G.guest_id";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        reviewsTable = new DataTable();
                        adapter.Fill(reviewsTable);
                        dataGridViewReviews.DataSource = reviewsTable;
                        dataGridViewReviews.Columns["review_id"].HeaderText = "ID";
                        dataGridViewReviews.Columns["guest_id"].HeaderText = "ID Гостя";
                        dataGridViewReviews.Columns["rating"].HeaderText = "Рейтинг";
                        dataGridViewReviews.Columns["comment"].HeaderText = "Комментарий";
                        dataGridViewReviews.Columns["created_at"].HeaderText = "Дата";
                        dataGridViewReviews.Columns["name"].HeaderText = "Имя";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки отзывов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSubmitReview_Click(object sender, EventArgs e)
        {
            int rating = (int)numericUpDownRating.Value;
            string comment = textBoxComment.Text.Trim();

            if (rating < 1 || rating > 5)
            {
                MessageBox.Show("Рейтинг должен быть от 1 до 5.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(comment))
            {
                MessageBox.Show("Комментарий не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comment.Length > 500)
            {
                MessageBox.Show("Комментарий не должен превышать 500 символов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                            // Вставка нового отзыва (без review_id, так как он IDENTITY)
                            string insertReviewQuery = @"
                                INSERT INTO REVIEWS (guest_id, rating, comment, created_at)
                                VALUES (@guestId, @rating, @comment, @createdAt)";
                            using (SqlCommand cmd = new SqlCommand(insertReviewQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@guestId", guestId);
                                cmd.Parameters.AddWithValue("@rating", rating);
                                cmd.Parameters.AddWithValue("@comment", comment);
                                cmd.Parameters.AddWithValue("@createdAt", DateTime.Now);
                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            MessageBox.Show("Отзыв успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadReviews(); // Обновить таблицу отзывов
                            textBoxComment.Clear();
                            numericUpDownRating.Value = 1;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Ошибка добавления отзыва: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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