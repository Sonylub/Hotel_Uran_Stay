using System.Drawing;

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
            this.flowLayoutPanelReviews = new System.Windows.Forms.FlowLayoutPanel();
            this.panelAddReview = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelRating = new System.Windows.Forms.Label();
            this.numericUpDownRating = new System.Windows.Forms.NumericUpDown();
            this.labelComment = new System.Windows.Forms.Label();
            this.textBoxComment = new System.Windows.Forms.TextBox();
            this.buttonSubmitReview = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panelAddReview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRating)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanelReviews
            // 
            this.flowLayoutPanelReviews.AutoScroll = true;
            this.flowLayoutPanelReviews.BackColor = Color.FromArgb(245, 245, 220);
            this.flowLayoutPanelReviews.Location = new System.Drawing.Point(12, 50);
            this.flowLayoutPanelReviews.Name = "flowLayoutPanelReviews";
            this.flowLayoutPanelReviews.Size = new System.Drawing.Size(600, 410);
            this.flowLayoutPanelReviews.TabIndex = 0;
            // 
            // panelAddReview
            // 
            this.panelAddReview.BackColor = Color.FromArgb(243, 244, 246);
            this.panelAddReview.Controls.Add(this.buttonClose);
            this.panelAddReview.Controls.Add(this.buttonSubmitReview);
            this.panelAddReview.Controls.Add(this.textBoxComment);
            this.panelAddReview.Controls.Add(this.labelComment);
            this.panelAddReview.Controls.Add(this.numericUpDownRating);
            this.panelAddReview.Controls.Add(this.labelRating);
            this.panelAddReview.Location = new System.Drawing.Point(618, 50);
            this.panelAddReview.Name = "panelAddReview";
            this.panelAddReview.Size = new System.Drawing.Size(280, 410);
            this.panelAddReview.TabIndex = 1;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTitle.ForeColor = Color.FromArgb(31, 41, 55);
            this.labelTitle.Location = new System.Drawing.Point(12, 12);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(171, 30);
            this.labelTitle.TabIndex = 2;
            this.labelTitle.Text = "Отзывы об отеле";
            // 
            // labelRating
            // 
            this.labelRating.AutoSize = true;
            this.labelRating.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRating.ForeColor = Color.FromArgb(31, 41, 55);
            this.labelRating.Location = new System.Drawing.Point(10, 10);
            this.labelRating.Name = "labelRating";
            this.labelRating.Size = new System.Drawing.Size(100, 19);
            this.labelRating.TabIndex = 0;
            this.labelRating.Text = "Рейтинг (1-5):";
            // 
            // numericUpDownRating
            // 
            this.numericUpDownRating.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownRating.Location = new System.Drawing.Point(10, 30);
            this.numericUpDownRating.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            this.numericUpDownRating.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numericUpDownRating.Name = "numericUpDownRating";
            this.numericUpDownRating.Size = new System.Drawing.Size(100, 26);
            this.numericUpDownRating.TabIndex = 1;
            this.numericUpDownRating.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.numericUpDownRating.ValueChanged += new System.EventHandler(this.numericUpDownRating_ValueChanged);
            // 
            // labelComment
            // 
            this.labelComment.AutoSize = true;
            this.labelComment.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelComment.ForeColor = Color.FromArgb(31, 41, 55);
            this.labelComment.Location = new System.Drawing.Point(10, 70);
            this.labelComment.Name = "labelComment";
            this.labelComment.Size = new System.Drawing.Size(100, 19);
            this.labelComment.TabIndex = 2;
            this.labelComment.Text = "Комментарий:";
            // 
            // textBoxComment
            // 
            this.textBoxComment.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxComment.Location = new System.Drawing.Point(10, 90);
            this.textBoxComment.Multiline = true;
            this.textBoxComment.Name = "textBoxComment";
            this.textBoxComment.Size = new System.Drawing.Size(260, 250);
            this.textBoxComment.TabIndex = 3;
            this.textBoxComment.TextChanged += new System.EventHandler(this.textBoxComment_TextChanged);
            // 
            // buttonSubmitReview
            // 
            this.buttonSubmitReview.BackColor = Color.FromArgb(30, 64, 175);
            this.buttonSubmitReview.FlatAppearance.BorderSize = 0;
            this.buttonSubmitReview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSubmitReview.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSubmitReview.ForeColor = Color.White;
            this.buttonSubmitReview.Location = new System.Drawing.Point(10, 350);
            this.buttonSubmitReview.Name = "buttonSubmitReview";
            this.buttonSubmitReview.Size = new System.Drawing.Size(125, 35);
            this.buttonSubmitReview.TabIndex = 4;
            this.buttonSubmitReview.Text = "Оставить отзыв";
            this.buttonSubmitReview.UseVisualStyleBackColor = false;
            this.buttonSubmitReview.Click += new System.EventHandler(this.buttonSubmitReview_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = Color.FromArgb(107, 114, 128);
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClose.ForeColor = Color.White;
            this.buttonClose.Location = new System.Drawing.Point(145, 350);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(125, 35);
            this.buttonClose.TabIndex = 5;
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // ReviewsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(245, 245, 220);
            this.ClientSize = new System.Drawing.Size(910, 470);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.panelAddReview);
            this.Controls.Add(this.flowLayoutPanelReviews);
            this.Name = "ReviewsForm";
            this.Text = "Отзывы об отеле";
            this.panelAddReview.ResumeLayout(false);
            this.panelAddReview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRating)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelReviews;
        private System.Windows.Forms.Panel panelAddReview;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelRating;
        private System.Windows.Forms.NumericUpDown numericUpDownRating;
        private System.Windows.Forms.Label labelComment;
        private System.Windows.Forms.TextBox textBoxComment;
        private System.Windows.Forms.Button buttonSubmitReview;
        private System.Windows.Forms.Button buttonClose;
    }
}