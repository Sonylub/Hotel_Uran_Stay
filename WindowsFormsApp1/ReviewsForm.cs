using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ReviewsForm : Form
    {
        private string connectionString = "Data Source=DESKTOP-JEM6MVF;Initial Catalog=Hotel_Urban_Stay;Integrated Security=True";
        private int userId;
        private int selectedRating = 0;
        private readonly Image starFilled = CreateStarImage(Color.Yellow);
        private readonly Image starEmpty = CreateStarImage(Color.Gray);

        public ReviewsForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            InitializeStars();
            LoadReviews();
        }

        private static Image CreateStarImage(Color color)
        {
            Bitmap bitmap = new Bitmap(20, 20);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.Transparent);
                Point[] points = new Point[]
                {
                    new Point(10, 0), new Point(12, 6), new Point(18, 6),
                    new Point(13, 10), new Point(15, 16), new Point(10, 12),
                    new Point(5, 16), new Point(7, 10), new Point(2, 6),
                    new Point(8, 6)
                };
                g.FillPolygon(new SolidBrush(color), points);
            }
            return bitmap;
        }

        private void InitializeStars()
        {
            star1.Image = starEmpty;
            star2.Image = starEmpty;
            star3.Image = starEmpty;
            star4.Image = starEmpty;
            star5.Image = starEmpty;
        }

        private void star_Click(object sender, EventArgs e)
        {
            PictureBox star = (PictureBox)sender;
            selectedRating = Convert.ToInt32(star.Tag);
            UpdateStarDisplay();
        }

        private void UpdateStarDisplay()
        {
            PictureBox[] stars = { star1, star2, star3, star4, star5 };
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].Image = i < selectedRating ? starFilled : starEmpty;
            }
        }

        private void LoadReviews()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT R.review_id, R.guest_id, R.rating, R.comment, R.created_at, U.username
                        FROM REVIEWS R
                        INNER JOIN GUESTS G ON R.guest_id = G.guest_id
                        INNER JOIN USERS U ON G.user_id = U.user_id
                        ORDER BY R.created_at DESC";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            flowLayoutPanelReviews.Controls.Clear();
                            while (reader.Read())
                            {
                                CreateReviewCard(reader);
                            }
                            if (flowLayoutPanelReviews.Controls.Count == 0)
                            {
                                Label lblNoReviews = new Label
                                {
                                    Text = "Нет отзывов",
                                    Font = new Font("Segoe UI", 12F, FontStyle.Italic),
                                    ForeColor = Color.White,
                                    AutoSize = true,
                                    Location = new Point(10, 10)
                                };
                                flowLayoutPanelReviews.Controls.Add(lblNoReviews);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки отзывов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateReviewCard(SqlDataReader reader)
        {
            int rating = reader.GetInt32(2);
            string comment = reader.IsDBNull(3) ? "Без комментария" : reader.GetString(3);
            DateTime createdAt = reader.GetDateTime(4);
            string username = reader.GetString(5);

            Panel card = new Panel
            {
                Size = new Size(737, 100), // Начальная высота, будет пересчитана
                BackColor = Color.FromArgb(60, 60, 64),
                Margin = new Padding(10)
            };

            Label lblUsername = new Label
            {
                Text = username,
                Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(10, 10),
                AutoSize = true
            };

            Label lblComment = new Label
            {
                Text = comment,
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.LightGray,
                Location = new Point(10, 35),
                MaximumSize = new Size(600, 0), // Ограничение по ширине, высота автоматическая
                AutoSize = true
            };

            Label lblDate = new Label
            {
                Text = $"Дата: {createdAt:d}",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.White,
                Location = new Point(620, 10),
                AutoSize = true
            };

            Panel ratingPanel = new Panel
            {
                Location = new Point(620, 35),
                Size = new Size(100, 20)
            };

            for (int i = 0; i < 5; i++)
            {
                PictureBox star = new PictureBox
                {
                    Size = new Size(15, 15),
                    Location = new Point(i * 18, 0),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Image = i < rating ? starFilled : starEmpty
                };
                ratingPanel.Controls.Add(star);
            }

            card.Controls.AddRange(new Control[] { lblUsername, lblComment, lblDate, ratingPanel });

            // Пересчёт высоты карточки
            int maxHeight = Math.Max(lblComment.Bottom, ratingPanel.Bottom) + 10; // Отступ снизу
            card.Size = new Size(737, maxHeight);

            flowLayoutPanelReviews.Controls.Add(card);
        }

        private int? GetGuestId()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT TOP 1 guest_id FROM GUESTS WHERE user_id = @userId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : (int?)null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка получения guest_id: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void buttonSubmitReview_Click(object sender, EventArgs e)
        {
            string comment = textBoxComment.Text.Trim();
            int? guestId = GetGuestId();

            if (guestId == null)
            {
                MessageBox.Show("Не удалось определить пользователя. Пожалуйста, проверьте ваш профиль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedRating == 0)
            {
                MessageBox.Show("Пожалуйста, выберите оценку.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(comment) || comment == "Введите ваш отзыв...")
            {
                MessageBox.Show("Пожалуйста, введите текст отзыва.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comment.Length > 500)
            {
                MessageBox.Show("Отзыв не должен превышать 500 символов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        INSERT INTO REVIEWS (guest_id, rating, comment, created_at)
                        VALUES (@guestId, @rating, @comment, @createdAt)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@guestId", guestId);
                        cmd.Parameters.AddWithValue("@rating", selectedRating);
                        cmd.Parameters.AddWithValue("@comment", comment);
                        cmd.Parameters.AddWithValue("@createdAt", DateTime.Now);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Отзыв успешно отправлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxComment.Text = "Введите ваш отзыв...";
                selectedRating = 0;
                UpdateStarDisplay();
                LoadReviews();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка отправки отзыва: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxComment_Enter(object sender, EventArgs e)
        {
            if (textBoxComment.Text == "Введите ваш отзыв...")
            {
                textBoxComment.Text = "";
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}