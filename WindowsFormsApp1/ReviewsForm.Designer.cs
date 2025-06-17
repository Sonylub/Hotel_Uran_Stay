namespace WindowsFormsApp1
{
    partial class ReviewsForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelMain = new System.Windows.Forms.Panel();
            this.flowLayoutPanelReviews = new System.Windows.Forms.FlowLayoutPanel();
            this.panelAddReview = new System.Windows.Forms.Panel();
            this.buttonSubmitReview = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.textBoxComment = new System.Windows.Forms.TextBox();
            this.labelRating = new System.Windows.Forms.Label();
            this.labelAddReview = new System.Windows.Forms.Label();
            this.star1 = new System.Windows.Forms.PictureBox();
            this.star2 = new System.Windows.Forms.PictureBox();
            this.star3 = new System.Windows.Forms.PictureBox();
            this.star4 = new System.Windows.Forms.PictureBox();
            this.star5 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            this.flowLayoutPanelReviews.SuspendLayout();
            this.panelAddReview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.star1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.star2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.star3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.star4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.star5)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(50)))));
            this.panelMain.Controls.Add(this.flowLayoutPanelReviews);
            this.panelMain.Controls.Add(this.panelAddReview);
            this.panelMain.Controls.Add(this.btnClose);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(800, 600);
            this.panelMain.TabIndex = 0;
            // 
            // flowLayoutPanelReviews
            // 
            this.flowLayoutPanelReviews.AutoScroll = true;
            this.flowLayoutPanelReviews.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(50)))));
            this.flowLayoutPanelReviews.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanelReviews.Name = "flowLayoutPanelReviews";
            this.flowLayoutPanelReviews.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanelReviews.Size = new System.Drawing.Size(776, 300);
            this.flowLayoutPanelReviews.TabIndex = 0;
            // 
            // panelAddReview
            // 
            this.panelAddReview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.panelAddReview.Controls.Add(this.buttonSubmitReview);
            this.panelAddReview.Controls.Add(this.buttonClose);
            this.panelAddReview.Controls.Add(this.textBoxComment);
            this.panelAddReview.Controls.Add(this.labelRating);
            this.panelAddReview.Controls.Add(this.labelAddReview);
            this.panelAddReview.Controls.Add(this.star1);
            this.panelAddReview.Controls.Add(this.star2);
            this.panelAddReview.Controls.Add(this.star3);
            this.panelAddReview.Controls.Add(this.star4);
            this.panelAddReview.Controls.Add(this.star5);
            this.panelAddReview.Location = new System.Drawing.Point(12, 320);
            this.panelAddReview.Name = "panelAddReview";
            this.panelAddReview.Size = new System.Drawing.Size(776, 268);
            this.panelAddReview.TabIndex = 1;
            // 
            // buttonSubmitReview
            // 
            this.buttonSubmitReview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(180)))), ((int)(((byte)(90)))));
            this.buttonSubmitReview.FlatAppearance.BorderSize = 0;
            this.buttonSubmitReview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSubmitReview.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.buttonSubmitReview.ForeColor = System.Drawing.Color.White;
            this.buttonSubmitReview.Location = new System.Drawing.Point(664, 228);
            this.buttonSubmitReview.Name = "buttonSubmitReview";
            this.buttonSubmitReview.Size = new System.Drawing.Size(100, 30);
            this.buttonSubmitReview.TabIndex = 7;
            this.buttonSubmitReview.Text = "Отправить";
            this.buttonSubmitReview.UseVisualStyleBackColor = false;
            this.buttonSubmitReview.Click += new System.EventHandler(this.buttonSubmitReview_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.Location = new System.Drawing.Point(552, 228);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(100, 30);
            this.buttonClose.TabIndex = 6;
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // textBoxComment
            // 
            this.textBoxComment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(64)))));
            this.textBoxComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxComment.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxComment.ForeColor = System.Drawing.Color.White;
            this.textBoxComment.Location = new System.Drawing.Point(12, 50);
            this.textBoxComment.Multiline = true;
            this.textBoxComment.Name = "textBoxComment";
            this.textBoxComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxComment.Size = new System.Drawing.Size(752, 150);
            this.textBoxComment.TabIndex = 5;
            this.textBoxComment.Text = "Введите ваш отзыв...";
            this.textBoxComment.Enter += new System.EventHandler(this.textBoxComment_Enter);
            // 
            // labelRating
            // 
            this.labelRating.AutoSize = true;
            this.labelRating.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.labelRating.ForeColor = System.Drawing.Color.White;
            this.labelRating.Location = new System.Drawing.Point(12, 210);
            this.labelRating.Name = "labelRating";
            this.labelRating.Size = new System.Drawing.Size(60, 19);
            this.labelRating.TabIndex = 4;
            this.labelRating.Text = "Оценка:";
            // 
            // labelAddReview
            // 
            this.labelAddReview.AutoSize = true;
            this.labelAddReview.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.labelAddReview.ForeColor = System.Drawing.Color.White;
            this.labelAddReview.Location = new System.Drawing.Point(12, 12);
            this.labelAddReview.Name = "labelAddReview";
            this.labelAddReview.Size = new System.Drawing.Size(150, 21);
            this.labelAddReview.TabIndex = 0;
            this.labelAddReview.Text = "Оставить отзыв";
            // 
            // star1
            // 
            this.star1.Location = new System.Drawing.Point(80, 210);
            this.star1.Name = "star1";
            this.star1.Size = new System.Drawing.Size(20, 20);
            this.star1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.star1.TabIndex = 1;
            this.star1.TabStop = false;
            this.star1.Tag = 1;
            this.star1.Click += new System.EventHandler(this.star_Click);
            // 
            // star2
            // 
            this.star2.Location = new System.Drawing.Point(105, 210);
            this.star2.Name = "star2";
            this.star2.Size = new System.Drawing.Size(20, 20);
            this.star2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.star2.TabIndex = 2;
            this.star2.TabStop = false;
            this.star2.Tag = 2;
            this.star2.Click += new System.EventHandler(this.star_Click);
            // 
            // star3
            // 
            this.star3.Location = new System.Drawing.Point(130, 210);
            this.star3.Name = "star3";
            this.star3.Size = new System.Drawing.Size(20, 20);
            this.star3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.star3.TabIndex = 3;
            this.star3.TabStop = false;
            this.star3.Tag = 3;
            this.star3.Click += new System.EventHandler(this.star_Click);
            // 
            // star4
            // 
            this.star4.Location = new System.Drawing.Point(155, 210);
            this.star4.Name = "star4";
            this.star4.Size = new System.Drawing.Size(20, 20);
            this.star4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.star4.TabIndex = 4;
            this.star4.TabStop = false;
            this.star4.Tag = 4;
            this.star4.Click += new System.EventHandler(this.star_Click);
            // 
            // star5
            // 
            this.star5.Location = new System.Drawing.Point(180, 210);
            this.star5.Name = "star5";
            this.star5.Size = new System.Drawing.Size(20, 20);
            this.star5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.star5.TabIndex = 5;
            this.star5.TabStop = false;
            this.star5.Tag = 5;
            this.star5.Click += new System.EventHandler(this.star_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(760, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // ReviewsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReviewsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Urban Stay - Отзывы";
            this.panelMain.ResumeLayout(false);
            this.flowLayoutPanelReviews.ResumeLayout(false);
            this.panelAddReview.ResumeLayout(false);
            this.panelAddReview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.star1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.star2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.star3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.star4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.star5)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelReviews;
        private System.Windows.Forms.Panel panelAddReview;
        private System.Windows.Forms.Label labelAddReview;
        private System.Windows.Forms.Label labelRating;
        private System.Windows.Forms.TextBox textBoxComment;
        private System.Windows.Forms.Button buttonSubmitReview;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.PictureBox star1;
        private System.Windows.Forms.PictureBox star2;
        private System.Windows.Forms.PictureBox star3;
        private System.Windows.Forms.PictureBox star4;
        private System.Windows.Forms.PictureBox star5;
        private System.Windows.Forms.Button btnClose;
    }
}