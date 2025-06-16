using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ReviewsControl : UserControl
    {
        private string connectionString = "Data Source=DESKTOP-JEM6MVF;Initial Catalog=Hotel_Urban_Stay;Integrated Security=True";
        private int userId;

        public ReviewsControl()
        {
            InitializeComponent();
        }

        public ReviewsControl(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            InitializeControl();
        }

        private void InitializeControl()
        {
            if (this.IsInDesignMode()) return; // Avoid initialization in designer
            DisableFields();
            DisplayReviews();
            UpdateSubmitButtonState();
        }

        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }

            DisplayReviews();
            DisableFields();
        }

        private bool IsInDesignMode()
        {
            return (this.Site != null) && this.Site.DesignMode;
        }

        private void DisableFields()
        {
            review_guestName.Enabled = false;
        }

        private void DisplayReviews()
        {
            ReviewData rd = new ReviewData();
            var listData = rd.ReviewListData();
            dataGridViewReviews.DataSource = listData;

            dataGridViewReviews.Columns["ReviewID"].HeaderText = "ID отзыва";
            dataGridViewReviews.Columns["GuestID"].HeaderText = "ID гостя";
            dataGridViewReviews.Columns["GuestName"].HeaderText = "Имя гостя";
            dataGridViewReviews.Columns["Rating"].HeaderText = "Рейтинг";
            dataGridViewReviews.Columns["Comment"].HeaderText = "Комментарий";
            dataGridViewReviews.Columns["CreatedAt"].HeaderText = "Дата";

            dataGridViewReviews.Columns["Comment"].Width = 200;
            dataGridViewReviews.Columns["GuestName"].Width = 120;
            dataGridViewReviews.Columns["CreatedAt"].Width = 100;
        }

        private void dataGridViewReviews_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridViewReviews.Rows[e.RowIndex];
                review_guestName.Text = row.Cells["GuestName"].Value?.ToString();
                review_rating.Value = Convert.ToDecimal(row.Cells["Rating"].Value ?? 1);
                review_comment.Text = row.Cells["Comment"].Value?.ToString();
            }
        }

        private void buttonSubmitReview_Click(object sender, EventArgs e)
        {
            int rating = (int)review_rating.Value;
            string comment = review_comment.Text.Trim();

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

            DialogResult check = MessageBox.Show("Вы уверены, что хотите добавить отзыв?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        using (SqlTransaction transaction = conn.BeginTransaction())
                        {
                            try
                            {
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
                                RefreshData();
                                ClearFields();
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                MessageBox.Show($"Ошибка добавления отзыва: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка подключения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Отмена", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            review_guestName.Text = "";
            review_rating.Value = 1;
            review_comment.Text = "";
        }

        private void review_comment_TextChanged(object sender, EventArgs e)
        {
            UpdateSubmitButtonState();
        }

        private void review_rating_ValueChanged(object sender, EventArgs e)
        {
            UpdateSubmitButtonState();
        }

        private void UpdateSubmitButtonState()
        {
            buttonSubmitReview.Enabled = !string.IsNullOrWhiteSpace(review_comment.Text) && review_comment.Text.Length <= 500;
        }
    }
}