using System.Drawing;

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
            this.panelProfile = new System.Windows.Forms.Panel();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.btnEditProfile = new System.Windows.Forms.Button();
            this.labelBookingsTitle = new System.Windows.Forms.Label();
            this.flowLayoutPanelBookings = new System.Windows.Forms.FlowLayoutPanel();
            this.labelServicesTitle = new System.Windows.Forms.Label();
            this.flowLayoutPanelServices = new System.Windows.Forms.FlowLayoutPanel();
            this.panelProfile.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelProfile
            // 
            this.panelProfile.BackColor = Color.FromArgb(243, 244, 246);
            this.panelProfile.Controls.Add(this.btnEditProfile);
            this.panelProfile.Controls.Add(this.lblPhone);
            this.panelProfile.Controls.Add(this.lblEmail);
            this.panelProfile.Controls.Add(this.lblName);
            this.panelProfile.Controls.Add(this.lblUsername);
            this.panelProfile.Location = new System.Drawing.Point(12, 12);
            this.panelProfile.Name = "panelProfile";
            this.panelProfile.Size = new System.Drawing.Size(760, 150);
            this.panelProfile.TabIndex = 0;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblUsername.ForeColor = Color.FromArgb(31, 41, 55);
            this.lblUsername.Location = new System.Drawing.Point(10, 10);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(150, 21);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Имя пользователя: Гость";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblName.ForeColor = Color.FromArgb(31, 41, 55);
            this.lblName.Location = new System.Drawing.Point(10, 40);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 19);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Имя: Не указано";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblEmail.ForeColor = Color.FromArgb(31, 41, 55);
            this.lblEmail.Location = new System.Drawing.Point(10, 70);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(100, 19);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "Email: Не указан";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPhone.ForeColor = Color.FromArgb(31, 41, 55);
            this.lblPhone.Location = new System.Drawing.Point(10, 100);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(100, 19);
            this.lblPhone.TabIndex = 3;
            this.lblPhone.Text = "Телефон: Не указан";
            // 
            // btnEditProfile
            // 
            this.btnEditProfile.BackColor = Color.FromArgb(30, 64, 175);
            this.btnEditProfile.FlatAppearance.BorderSize = 0;
            this.btnEditProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditProfile.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEditProfile.ForeColor = Color.White;
            this.btnEditProfile.Location = new System.Drawing.Point(650, 110);
            this.btnEditProfile.Name = "btnEditProfile";
            this.btnEditProfile.Size = new System.Drawing.Size(100, 30);
            this.btnEditProfile.TabIndex = 4;
            this.btnEditProfile.Text = "Редактировать";
            this.btnEditProfile.UseVisualStyleBackColor = false;
            this.btnEditProfile.Click += new System.EventHandler(this.btnEditProfile_Click);
            // 
            // labelBookingsTitle
            // 
            this.labelBookingsTitle.AutoSize = true;
            this.labelBookingsTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBookingsTitle.ForeColor = Color.FromArgb(31, 41, 55);
            this.labelBookingsTitle.Location = new System.Drawing.Point(12, 172);
            this.labelBookingsTitle.Name = "labelBookingsTitle";
            this.labelBookingsTitle.Size = new System.Drawing.Size(150, 25);
            this.labelBookingsTitle.TabIndex = 1;
            this.labelBookingsTitle.Text = "Ваши бронирования";
            // 
            // flowLayoutPanelBookings
            // 
            this.flowLayoutPanelBookings.AutoScroll = true;
            this.flowLayoutPanelBookings.BackColor = Color.FromArgb(245, 245, 220);
            this.flowLayoutPanelBookings.Location = new System.Drawing.Point(12, 202);
            this.flowLayoutPanelBookings.Name = "flowLayoutPanelBookings";
            this.flowLayoutPanelBookings.Size = new System.Drawing.Size(760, 250);
            this.flowLayoutPanelBookings.TabIndex = 2;
            // 
            // labelServicesTitle
            // 
            this.labelServicesTitle.AutoSize = true;
            this.labelServicesTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelServicesTitle.ForeColor = Color.FromArgb(31, 41, 55);
            this.labelServicesTitle.Location = new System.Drawing.Point(12, 462);
            this.labelServicesTitle.Name = "labelServicesTitle";
            this.labelServicesTitle.Size = new System.Drawing.Size(150, 25);
            this.labelServicesTitle.TabIndex = 3;
            this.labelServicesTitle.Text = "Ваши услуги";
            // 
            // flowLayoutPanelServices
            // 
            this.flowLayoutPanelServices.AutoScroll = true;
            this.flowLayoutPanelServices.BackColor = Color.FromArgb(245, 245, 220);
            this.flowLayoutPanelServices.Location = new System.Drawing.Point(12, 492);
            this.flowLayoutPanelServices.Name = "flowLayoutPanelServices";
            this.flowLayoutPanelServices.Size = new System.Drawing.Size(760, 250);
            this.flowLayoutPanelServices.TabIndex = 4;
            // 
            // FormLK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(245, 245, 220);
            this.ClientSize = new System.Drawing.Size(784, 761);
            this.Controls.Add(this.flowLayoutPanelServices);
            this.Controls.Add(this.labelServicesTitle);
            this.Controls.Add(this.flowLayoutPanelBookings);
            this.Controls.Add(this.labelBookingsTitle);
            this.Controls.Add(this.panelProfile);
            this.Name = "FormLK";
            this.Text = "Личный кабинет";
            this.panelProfile.ResumeLayout(false);
            this.panelProfile.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelProfile;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Button btnEditProfile;
        private System.Windows.Forms.Label labelBookingsTitle;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelBookings;
        private System.Windows.Forms.Label labelServicesTitle;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelServices;
    }
}