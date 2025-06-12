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
            this.dataGridViewReviews = new System.Windows.Forms.DataGridView();
            this.labelTitle = new System.Windows.Forms.Label();
            this.numericUpDownRating = new System.Windows.Forms.NumericUpDown();
            this.labelRating = new System.Windows.Forms.Label();
            this.textBoxComment = new System.Windows.Forms.TextBox();
            this.labelComment = new System.Windows.Forms.Label();
            this.buttonSubmitReview = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReviews)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRating)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewReviews
            // 
            this.dataGridViewReviews.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReviews.Location = new System.Drawing.Point(20, 60);
            this.dataGridViewReviews.Name = "dataGridViewReviews";
            this.dataGridViewReviews.Size = new System.Drawing.Size(600, 300);
            this.dataGridViewReviews.TabIndex = 0;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTitle.Location = new System.Drawing.Point(20, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(171, 23);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Отзывы об отеле";
            // 
            // numericUpDownRating
            // 
            this.numericUpDownRating.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownRating.Location = new System.Drawing.Point(640, 100);
            this.numericUpDownRating.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            this.numericUpDownRating.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numericUpDownRating.Name = "numericUpDownRating";
            this.numericUpDownRating.Size = new System.Drawing.Size(100, 29);
            this.numericUpDownRating.TabIndex = 2;
            this.numericUpDownRating.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // labelRating
            // 
            this.labelRating.AutoSize = true;
            this.labelRating.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRating.Location = new System.Drawing.Point(637, 80);
            this.labelRating.Name = "labelRating";
            this.labelRating.Size = new System.Drawing.Size(100, 23);
            this.labelRating.TabIndex = 3;
            this.labelRating.Text = "Рейтинг (1-5):";
            // 
            // textBoxComment
            // 
            this.textBoxComment.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxComment.Location = new System.Drawing.Point(640, 160);
            this.textBoxComment.Multiline = true;
            this.textBoxComment.Name = "textBoxComment";
            this.textBoxComment.Size = new System.Drawing.Size(250, 100);
            this.textBoxComment.TabIndex = 4;
            // 
            // labelComment
            // 
            this.labelComment.AutoSize = true;
            this.labelComment.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelComment.Location = new System.Drawing.Point(637, 140);
            this.labelComment.Name = "labelComment";
            this.labelComment.Size = new System.Drawing.Size(100, 23);
            this.labelComment.TabIndex = 5;
            this.labelComment.Text = "Комментарий:";
            // 
            // buttonSubmitReview
            // 
            this.buttonSubmitReview.BackColor = System.Drawing.Color.LightCoral;
            this.buttonSubmitReview.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSubmitReview.Location = new System.Drawing.Point(640, 280);
            this.buttonSubmitReview.Name = "buttonSubmitReview";
            this.buttonSubmitReview.Size = new System.Drawing.Size(120, 35);
            this.buttonSubmitReview.TabIndex = 6;
            this.buttonSubmitReview.Text = "Оставить отзыв";
            this.buttonSubmitReview.UseVisualStyleBackColor = false;
            this.buttonSubmitReview.Click += new System.EventHandler(this.buttonSubmitReview_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.LightGray;
            this.buttonClose.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClose.Location = new System.Drawing.Point(770, 280);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(120, 35);
            this.buttonClose.TabIndex = 7;
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // ReviewsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(910, 480);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSubmitReview);
            this.Controls.Add(this.labelComment);
            this.Controls.Add(this.textBoxComment);
            this.Controls.Add(this.labelRating);
            this.Controls.Add(this.numericUpDownRating);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.dataGridViewReviews);
            this.Name = "ReviewsForm";
            this.Text = "Отзывы об отеле";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReviews)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRating)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewReviews;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.NumericUpDown numericUpDownRating;
        private System.Windows.Forms.Label labelRating;
        private System.Windows.Forms.TextBox textBoxComment;
        private System.Windows.Forms.Label labelComment;
        private System.Windows.Forms.Button buttonSubmitReview;
        private System.Windows.Forms.Button buttonClose;
    }
}