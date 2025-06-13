namespace WindowsFormsApp1
{
    partial class MainForm
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
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.buttonReviews = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.buttonOrderServices = new System.Windows.Forms.Button();
            this.buttonPersonalAccount = new System.Windows.Forms.Button();
            this.buttonAvailableRooms = new System.Windows.Forms.Button();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.panelContent = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.reviewsControl1 = new WindowsFormsApp1.ReviewsControl();
            this.panelMain.SuspendLayout();
            this.panelSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(50)))));
            this.panelMain.Controls.Add(this.panelSidebar);
            this.panelMain.Controls.Add(this.panelContent);
            this.panelMain.Controls.Add(this.btnClose);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(800, 600);
            this.panelMain.TabIndex = 0;
            // 
            // panelSidebar
            // 
            this.panelSidebar.AllowDrop = true;
            this.panelSidebar.AutoScroll = true;
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.panelSidebar.Controls.Add(this.buttonReviews);
            this.panelSidebar.Controls.Add(this.buttonLogout);
            this.panelSidebar.Controls.Add(this.buttonOrderServices);
            this.panelSidebar.Controls.Add(this.buttonPersonalAccount);
            this.panelSidebar.Controls.Add(this.buttonAvailableRooms);
            this.panelSidebar.Controls.Add(this.pictureBoxLogo);
            this.panelSidebar.Cursor = System.Windows.Forms.Cursors.Default;
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(256, 600);
            this.panelSidebar.TabIndex = 1;
            // 
            // buttonReviews
            // 
            this.buttonReviews.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(180)))), ((int)(((byte)(90)))));
            this.buttonReviews.FlatAppearance.BorderSize = 0;
            this.buttonReviews.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReviews.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.buttonReviews.ForeColor = System.Drawing.Color.White;
            this.buttonReviews.Location = new System.Drawing.Point(20, 360);
            this.buttonReviews.Name = "buttonReviews";
            this.buttonReviews.Size = new System.Drawing.Size(210, 40);
            this.buttonReviews.TabIndex = 4;
            this.buttonReviews.Text = "Отзывы";
            this.buttonReviews.UseVisualStyleBackColor = false;
            this.buttonReviews.Click += new System.EventHandler(this.buttonReviews_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.BackColor = System.Drawing.Color.Gray;
            this.buttonLogout.FlatAppearance.BorderSize = 0;
            this.buttonLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogout.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.buttonLogout.ForeColor = System.Drawing.Color.White;
            this.buttonLogout.Location = new System.Drawing.Point(68, 502);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(120, 40);
            this.buttonLogout.TabIndex = 5;
            this.buttonLogout.Text = "Выход";
            this.buttonLogout.UseVisualStyleBackColor = false;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // buttonOrderServices
            // 
            this.buttonOrderServices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(180)))), ((int)(((byte)(90)))));
            this.buttonOrderServices.FlatAppearance.BorderSize = 0;
            this.buttonOrderServices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOrderServices.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.buttonOrderServices.ForeColor = System.Drawing.Color.White;
            this.buttonOrderServices.Location = new System.Drawing.Point(20, 300);
            this.buttonOrderServices.Name = "buttonOrderServices";
            this.buttonOrderServices.Size = new System.Drawing.Size(210, 40);
            this.buttonOrderServices.TabIndex = 3;
            this.buttonOrderServices.Text = "Заказать услуги";
            this.buttonOrderServices.UseVisualStyleBackColor = false;
            this.buttonOrderServices.Click += new System.EventHandler(this.buttonOrderServices_Click);
            // 
            // buttonPersonalAccount
            // 
            this.buttonPersonalAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(180)))), ((int)(((byte)(90)))));
            this.buttonPersonalAccount.FlatAppearance.BorderSize = 0;
            this.buttonPersonalAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPersonalAccount.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.buttonPersonalAccount.ForeColor = System.Drawing.Color.White;
            this.buttonPersonalAccount.Location = new System.Drawing.Point(20, 240);
            this.buttonPersonalAccount.Name = "buttonPersonalAccount";
            this.buttonPersonalAccount.Size = new System.Drawing.Size(210, 40);
            this.buttonPersonalAccount.TabIndex = 2;
            this.buttonPersonalAccount.Text = "Личный кабинет";
            this.buttonPersonalAccount.UseVisualStyleBackColor = false;
            this.buttonPersonalAccount.Click += new System.EventHandler(this.buttonPersonalAccount_Click);
            // 
            // buttonAvailableRooms
            // 
            this.buttonAvailableRooms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(180)))), ((int)(((byte)(90)))));
            this.buttonAvailableRooms.FlatAppearance.BorderSize = 0;
            this.buttonAvailableRooms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAvailableRooms.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.buttonAvailableRooms.ForeColor = System.Drawing.Color.White;
            this.buttonAvailableRooms.Location = new System.Drawing.Point(20, 180);
            this.buttonAvailableRooms.Name = "buttonAvailableRooms";
            this.buttonAvailableRooms.Size = new System.Drawing.Size(210, 40);
            this.buttonAvailableRooms.TabIndex = 1;
            this.buttonAvailableRooms.Text = "Доступные номера";
            this.buttonAvailableRooms.UseVisualStyleBackColor = false;
            this.buttonAvailableRooms.Click += new System.EventHandler(this.buttonAvailableRooms_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxLogo.Location = new System.Drawing.Point(85, 30);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(78, 80);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // panelContent
            // 
            this.panelContent.AutoSize = true;
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(50)))));
            this.panelContent.Controls.Add(this.reviewsControl1);
            this.panelContent.Cursor = System.Windows.Forms.Cursors.Default;
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(800, 600);
            this.panelContent.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(760, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // reviewsControl1
            // 
            this.reviewsControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(50)))));
            this.reviewsControl1.Location = new System.Drawing.Point(262, 3);
            this.reviewsControl1.Name = "reviewsControl1";
            this.reviewsControl1.Size = new System.Drawing.Size(550, 600);
            this.reviewsControl1.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hotel Urban Stay - Гость";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.panelContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Button buttonAvailableRooms;
        private System.Windows.Forms.Button buttonPersonalAccount;
        private System.Windows.Forms.Button buttonOrderServices;
        private System.Windows.Forms.Button buttonReviews;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button btnClose;
        private ReviewsControl reviewsControl1;
    }
}