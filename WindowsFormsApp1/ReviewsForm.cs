using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
            UpdateSubmitButtonState();
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
                        PopulateReviewCards();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки отзывов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateReviewCards()
        {
            flowLayoutPanelReviews.Controls.Clear();
            if (reviewsTable.Rows.Count == 0)
            {
                Label lblNoReviews = new Label
                {
                    Text = "Отзывы пока отсутствуют",
                    Font = new Font("Segoe UI", 12, FontStyle.Italic),
                    ForeColor = Color.FromArgb(107, 114, 128),
                    AutoSize = true,
                    Location = new Point(10, 10)
                };
                flowLayoutPanelReviews.Controls.Add(lblNoReviews);
                return;
            }

            foreach (DataRow row in reviewsTable.Rows)
            {
                string name = row["name"].ToString();
                int rating = Convert.ToInt32(row["rating"]);
                string comment = row["comment"].ToString();
                DateTime createdAt = Convert.ToDateTime(row["created_at"]);

                Panel card = new Panel
                {
                    Size = new Size(560, 180),
                    Margin = new Padding(10),
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.White
                };

                Label lblName = new Label
                {
                    Text = name,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    Location = new Point(10, 10),
                    Size = new Size(540, 30),
                    ForeColor = Color.FromArgb(31, 41, 55)
                };

                Label lblRating = new Label
                {
                    Text = $"Рейтинг: {new string('★', rating)}{new string('☆', 5 - rating)}",
                    Font = new Font("Segoe UI", 10, FontStyle.Regular),
                    Location = new Point(10, 40),
                    Size = new Size(540, 20),
                    ForeColor = Color.FromArgb(245, 158, 11)
                };

                Label lblComment = new Label
                {
                    Text = comment.Length > 200 ? comment.Substring(0, 200) + "..." : comment,
                    Font = new Font("Segoe UI", 9, FontStyle.Regular),
                    Location = new Point(10, 60),
                    Size = new Size(540, 80),
                    ForeColor = Color.FromArgb(107, 114, 128)
                };

                Label lblDate = new Label
                {
                    Text = $"Дата: {createdAt:d}",
                    Font = new Font("Segoe UI", 9, FontStyle.Regular),
                    Location = new Point(10, 140),
                    Size = new Size(540, 20),
                    ForeColor = Color.FromArgb(107, 114, 128)
                };

                card.Controls.AddRange(new Control[] { lblName, lblRating, lblComment, lblDate });
                card.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(243, 244, 246);
                card.MouseLeave += (s, e) => card.BackColor = Color.White;

                flowLayoutPanelReviews.Controls.Add(card);
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

                            // Вставка нового отзыва
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
                            LoadReviews();
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

        private void textBoxComment_TextChanged(object sender, EventArgs e)
        {
            UpdateSubmitButtonState();
        }

        private void numericUpDownRating_ValueChanged(object sender, EventArgs e)
        {
            UpdateSubmitButtonState();
        }

        private void UpdateSubmitButtonState()
        {
            buttonSubmitReview.Enabled = !string.IsNullOrWhiteSpace(textBoxComment.Text) && textBoxComment.Text.Length <= 500;
        }
    }
}