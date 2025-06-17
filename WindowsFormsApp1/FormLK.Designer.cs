namespace WindowsFormsApp1
{
    partial class FormLK
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
            this.panelProfile = new System.Windows.Forms.Panel();
            this.btnCloseLK = new System.Windows.Forms.Button();
            this.btnEditProfile = new System.Windows.Forms.Button();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.labelBookingsTitle = new System.Windows.Forms.Label();
            this.flowLayoutPanelBookings = new System.Windows.Forms.FlowLayoutPanel();
            this.labelServicesTitle = new System.Windows.Forms.Label();
            this.flowLayoutPanelServices = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            this.panelProfile.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(50)))));
            this.panelMain.Controls.Add(this.panelProfile);
            this.panelMain.Controls.Add(this.labelBookingsTitle);
            this.panelMain.Controls.Add(this.flowLayoutPanelBookings);
            this.panelMain.Controls.Add(this.labelServicesTitle);
            this.panelMain.Controls.Add(this.flowLayoutPanelServices);
            this.panelMain.Controls.Add(this.btnClose);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(800, 600);
            this.panelMain.TabIndex = 0;
            // 
            // panelProfile
            // 
            this.panelProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.panelProfile.Controls.Add(this.btnCloseLK);
            this.panelProfile.Controls.Add(this.btnEditProfile);
            this.panelProfile.Controls.Add(this.lblPhone);
            this.panelProfile.Controls.Add(this.lblEmail);
            this.panelProfile.Controls.Add(this.lblName);
            this.panelProfile.Controls.Add(this.lblUsername);
            this.panelProfile.Location = new System.Drawing.Point(12, 12);
            this.panelProfile.Name = "panelProfile";
            this.panelProfile.Size = new System.Drawing.Size(776, 150);
            this.panelProfile.TabIndex = 0;
            // 
            // btnCloseLK
            // 
            this.btnCloseLK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btnCloseLK.FlatAppearance.BorderSize = 0;
            this.btnCloseLK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseLK.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnCloseLK.ForeColor = System.Drawing.Color.White;
            this.btnCloseLK.Location = new System.Drawing.Point(552, 110);
            this.btnCloseLK.Name = "btnCloseLK";
            this.btnCloseLK.Size = new System.Drawing.Size(100, 30);
            this.btnCloseLK.TabIndex = 5;
            this.btnCloseLK.Text = "Закрыть";
            this.btnCloseLK.UseVisualStyleBackColor = false;
            this.btnCloseLK.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEditProfile
            // 
            this.btnEditProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(180)))), ((int)(((byte)(90)))));
            this.btnEditProfile.FlatAppearance.BorderSize = 0;
            this.btnEditProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditProfile.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditProfile.ForeColor = System.Drawing.Color.White;
            this.btnEditProfile.Location = new System.Drawing.Point(664, 110);
            this.btnEditProfile.Name = "btnEditProfile";
            this.btnEditProfile.Size = new System.Drawing.Size(100, 30);
            this.btnEditProfile.TabIndex = 4;
            this.btnEditProfile.Text = "Редактировать";
            this.btnEditProfile.UseVisualStyleBackColor = false;
            this.btnEditProfile.Click += new System.EventHandler(this.btnEditProfile_Click);
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPhone.ForeColor = System.Drawing.Color.White;
            this.lblPhone.Location = new System.Drawing.Point(12, 90);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(100, 19);
            this.lblPhone.TabIndex = 3;
            this.lblPhone.Text = "Телефон: Не указан";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEmail.ForeColor = System.Drawing.Color.White;
            this.lblEmail.Location = new System.Drawing.Point(12, 60);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(100, 19);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "Email: Не указан";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(12, 30);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 19);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Имя: Не указано";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblUsername.ForeColor = System.Drawing.Color.White;
            this.lblUsername.Location = new System.Drawing.Point(12, 12);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(150, 21);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Имя пользователя: Гость";
            // 
            // labelBookingsTitle
            // 
            this.labelBookingsTitle.AutoSize = true;
            this.labelBookingsTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.labelBookingsTitle.ForeColor = System.Drawing.Color.White;
            this.labelBookingsTitle.Location = new System.Drawing.Point(12, 170);
            this.labelBookingsTitle.Name = "labelBookingsTitle";
            this.labelBookingsTitle.Size = new System.Drawing.Size(150, 25);
            this.labelBookingsTitle.TabIndex = 1;
            this.labelBookingsTitle.Text = "Ваши бронирования";
            // 
            // flowLayoutPanelBookings
            // 
            this.flowLayoutPanelBookings.AutoScroll = true;
            this.flowLayoutPanelBookings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(50)))));
            this.flowLayoutPanelBookings.Location = new System.Drawing.Point(12, 200);
            this.flowLayoutPanelBookings.Name = "flowLayoutPanelBookings";
            this.flowLayoutPanelBookings.Size = new System.Drawing.Size(776, 190);
            this.flowLayoutPanelBookings.TabIndex = 2;
            // 
            // labelServicesTitle
            // 
            this.labelServicesTitle.AutoSize = true;
            this.labelServicesTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.labelServicesTitle.ForeColor = System.Drawing.Color.White;
            this.labelServicesTitle.Location = new System.Drawing.Point(12, 400);
            this.labelServicesTitle.Name = "labelServicesTitle";
            this.labelServicesTitle.Size = new System.Drawing.Size(150, 25);
            this.labelServicesTitle.TabIndex = 3;
            this.labelServicesTitle.Text = "Ваши услуги";
            // 
            // flowLayoutPanelServices
            // 
            this.flowLayoutPanelServices.AutoScroll = true;
            this.flowLayoutPanelServices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(50)))));
            this.flowLayoutPanelServices.Location = new System.Drawing.Point(12, 430);
            this.flowLayoutPanelServices.Name = "flowLayoutPanelServices";
            this.flowLayoutPanelServices.Size = new System.Drawing.Size(776, 158);
            this.flowLayoutPanelServices.TabIndex = 4;
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
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormLK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Личный кабинет";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelProfile.ResumeLayout(false);
            this.panelProfile.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelProfile;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Button btnEditProfile;
        private System.Windows.Forms.Button btnCloseLK;
        private System.Windows.Forms.Label labelBookingsTitle;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelBookings;
        private System.Windows.Forms.Label labelServicesTitle;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelServices;
        private System.Windows.Forms.Button btnClose;
    }
}