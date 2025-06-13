namespace WindowsFormsApp1
{
    partial class ReviewsControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.dataGridViewReviews = new System.Windows.Forms.DataGridView();
            this.panelAddReview = new System.Windows.Forms.Panel();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonSubmitReview = new System.Windows.Forms.Button();
            this.review_comment = new System.Windows.Forms.TextBox();
            this.panelLineComment = new System.Windows.Forms.Panel();
            this.labelComment = new System.Windows.Forms.Label();
            this.review_rating = new System.Windows.Forms.NumericUpDown();
            this.panelLineRating = new System.Windows.Forms.Panel();
            this.labelRating = new System.Windows.Forms.Label();
            this.review_guestName = new System.Windows.Forms.TextBox();
            this.panelLineName = new System.Windows.Forms.Panel();
            this.labelGuestName = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReviews)).BeginInit();
            this.panelAddReview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.review_rating)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewReviews
            // 
            this.dataGridViewReviews.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(50)))));
            this.dataGridViewReviews.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewReviews.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.dataGridViewReviews.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridViewReviews.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(50)))));
            this.dataGridViewReviews.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridViewReviews.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(180)))), ((int)(((byte)(90)))));
            this.dataGridViewReviews.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewReviews.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.dataGridViewReviews.Location = new System.Drawing.Point(20, 60);
            this.dataGridViewReviews.Name = "dataGridViewReviews";
            this.dataGridViewReviews.RowHeadersVisible = false;
            this.dataGridViewReviews.Size = new System.Drawing.Size(510, 300);
            this.dataGridViewReviews.TabIndex = 0;
            this.dataGridViewReviews.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewReviews_CellClick);
            // 
            // panelAddReview
            // 
            this.panelAddReview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.panelAddReview.Controls.Add(this.buttonClear);
            this.panelAddReview.Controls.Add(this.buttonSubmitReview);
            this.panelAddReview.Controls.Add(this.review_comment);
            this.panelAddReview.Controls.Add(this.panelLineComment);
            this.panelAddReview.Controls.Add(this.labelComment);
            this.panelAddReview.Controls.Add(this.review_rating);
            this.panelAddReview.Controls.Add(this.panelLineRating);
            this.panelAddReview.Controls.Add(this.labelRating);
            this.panelAddReview.Controls.Add(this.review_guestName);
            this.panelAddReview.Controls.Add(this.panelLineName);
            this.panelAddReview.Controls.Add(this.labelGuestName);
            this.panelAddReview.Location = new System.Drawing.Point(20, 370);
            this.panelAddReview.Name = "panelAddReview";
            this.panelAddReview.Size = new System.Drawing.Size(510, 210);
            this.panelAddReview.TabIndex = 1;
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.Color.Gray;
            this.buttonClear.FlatAppearance.BorderSize = 0;
            this.buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClear.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.buttonClear.ForeColor = System.Drawing.Color.White;
            this.buttonClear.Location = new System.Drawing.Point(380, 165);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(120, 35);
            this.buttonClear.TabIndex = 10;
            this.buttonClear.Text = "Очистить";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonSubmitReview
            // 
            this.buttonSubmitReview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(180)))), ((int)(((byte)(90)))));
            this.buttonSubmitReview.FlatAppearance.BorderSize = 0;
            this.buttonSubmitReview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSubmitReview.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.buttonSubmitReview.ForeColor = System.Drawing.Color.White;
            this.buttonSubmitReview.Location = new System.Drawing.Point(250, 165);
            this.buttonSubmitReview.Name = "buttonSubmitReview";
            this.buttonSubmitReview.Size = new System.Drawing.Size(120, 35);
            this.buttonSubmitReview.TabIndex = 9;
            this.buttonSubmitReview.Text = "Оставить отзыв";
            this.buttonSubmitReview.UseVisualStyleBackColor = false;
            this.buttonSubmitReview.Click += new System.EventHandler(this.buttonSubmitReview_Click);
            // 
            // review_comment
            // 
            this.review_comment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.review_comment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.review_comment.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.review_comment.ForeColor = System.Drawing.Color.White;
            this.review_comment.Location = new System.Drawing.Point(20, 90);
            this.review_comment.Multiline = true;
            this.review_comment.Name = "review_comment";
            this.review_comment.Size = new System.Drawing.Size(470, 60);
            this.review_comment.TabIndex = 8;
            this.review_comment.TextChanged += new System.EventHandler(this.review_comment_TextChanged);
            // 
            // panelLineComment
            // 
            this.panelLineComment.BackColor = System.Drawing.Color.Silver;
            this.panelLineComment.Location = new System.Drawing.Point(20, 150);
            this.panelLineComment.Name = "panelLineComment";
            this.panelLineComment.Size = new System.Drawing.Size(470, 1);
            this.panelLineComment.TabIndex = 7;
            // 
            // labelComment
            // 
            this.labelComment.AutoSize = true;
            this.labelComment.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelComment.ForeColor = System.Drawing.Color.Silver;
            this.labelComment.Location = new System.Drawing.Point(20, 70);
            this.labelComment.Name = "labelComment";
            this.labelComment.Size = new System.Drawing.Size(100, 19);
            this.labelComment.TabIndex = 6;
            this.labelComment.Text = "Комментарий:";
            // 
            // review_rating
            // 
            this.review_rating.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.review_rating.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.review_rating.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.review_rating.ForeColor = System.Drawing.Color.White;
            this.review_rating.Location = new System.Drawing.Point(250, 30);
            this.review_rating.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            this.review_rating.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.review_rating.Name = "review_rating";
            this.review_rating.Size = new System.Drawing.Size(100, 22);
            this.review_rating.TabIndex = 5;
            this.review_rating.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.review_rating.ValueChanged += new System.EventHandler(this.review_rating_ValueChanged);
            // 
            // panelLineRating
            // 
            this.panelLineRating.BackColor = System.Drawing.Color.Silver;
            this.panelLineRating.Location = new System.Drawing.Point(250, 50);
            this.panelLineRating.Name = "panelLineRating";
            this.panelLineRating.Size = new System.Drawing.Size(100, 1);
            this.panelLineRating.TabIndex = 4;
            // 
            // labelRating
            // 
            this.labelRating.AutoSize = true;
            this.labelRating.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelRating.ForeColor = System.Drawing.Color.Silver;
            this.labelRating.Location = new System.Drawing.Point(250, 10);
            this.labelRating.Name = "labelRating";
            this.labelRating.Size = new System.Drawing.Size(100, 19);
            this.labelRating.TabIndex = 3;
            this.labelRating.Text = "Рейтинг (1-5):";
            // 
            // review_guestName
            // 
            this.review_guestName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.review_guestName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.review_guestName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.review_guestName.ForeColor = System.Drawing.Color.White;
            this.review_guestName.Location = new System.Drawing.Point(20, 30);
            this.review_guestName.Name = "review_guestName";
            this.review_guestName.Size = new System.Drawing.Size(200, 22);
            this.review_guestName.TabIndex = 2;
            // 
            // panelLineName
            // 
            this.panelLineName.BackColor = System.Drawing.Color.Silver;
            this.panelLineName.Location = new System.Drawing.Point(20, 50);
            this.panelLineName.Name = "panelLineName";
            this.panelLineName.Size = new System.Drawing.Size(200, 1);
            this.panelLineName.TabIndex = 1;
            // 
            // labelGuestName
            // 
            this.labelGuestName.AutoSize = true;
            this.labelGuestName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelGuestName.ForeColor = System.Drawing.Color.Silver;
            this.labelGuestName.Location = new System.Drawing.Point(20, 10);
            this.labelGuestName.Name = "labelGuestName";
            this.labelGuestName.Size = new System.Drawing.Size(100, 19);
            this.labelGuestName.TabIndex = 0;
            this.labelGuestName.Text = "Имя гостя:";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(20, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(171, 25);
            this.labelTitle.TabIndex = 2;
            this.labelTitle.Text = "Отзывы об отеле";
            // 
            // ReviewsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(50)))));
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.panelAddReview);
            this.Controls.Add(this.dataGridViewReviews);
            this.Name = "ReviewsControl";
            this.Size = new System.Drawing.Size(550, 600);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReviews)).EndInit();
            this.panelAddReview.ResumeLayout(false);
            this.panelAddReview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.review_rating)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewReviews;
        private System.Windows.Forms.Panel panelAddReview;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelGuestName;
        private System.Windows.Forms.TextBox review_guestName;
        private System.Windows.Forms.Panel panelLineName;
        private System.Windows.Forms.Label labelRating;
        private System.Windows.Forms.NumericUpDown review_rating;
        private System.Windows.Forms.Panel panelLineRating;
        private System.Windows.Forms.Label labelComment;
        private System.Windows.Forms.Panel panelLineComment;
        private System.Windows.Forms.TextBox review_comment;
        private System.Windows.Forms.Button buttonSubmitReview;
        private System.Windows.Forms.Button buttonClear;
    }
}