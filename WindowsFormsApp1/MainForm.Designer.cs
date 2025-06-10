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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.labelWelcome = new System.Windows.Forms.Label();
            this.buttonAvailableRooms = new System.Windows.Forms.Button();
            this.buttonMyBookings = new System.Windows.Forms.Button();
            this.buttonMyServices = new System.Windows.Forms.Button();
            this.buttonOrderServices = new System.Windows.Forms.Button();
            this.buttonReviews = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWelcome.Location = new System.Drawing.Point(146, 149);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(199, 23);
            this.labelWelcome.TabIndex = 1;
            this.labelWelcome.Text = "Добро пожаловать, Гость!";
            // 
            // buttonAvailableRooms
            // 
            this.buttonAvailableRooms.BackColor = System.Drawing.Color.LightCoral;
            this.buttonAvailableRooms.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAvailableRooms.Location = new System.Drawing.Point(100, 190);
            this.buttonAvailableRooms.Name = "buttonAvailableRooms";
            this.buttonAvailableRooms.Size = new System.Drawing.Size(263, 35);
            this.buttonAvailableRooms.TabIndex = 2;
            this.buttonAvailableRooms.Text = "Доступные номера";
            this.buttonAvailableRooms.UseVisualStyleBackColor = false;
            this.buttonAvailableRooms.Click += new System.EventHandler(this.buttonAvailableRooms_Click);
            // 
            // buttonMyBookings
            // 
            this.buttonMyBookings.BackColor = System.Drawing.Color.LightCoral;
            this.buttonMyBookings.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMyBookings.Location = new System.Drawing.Point(100, 231);
            this.buttonMyBookings.Name = "buttonMyBookings";
            this.buttonMyBookings.Size = new System.Drawing.Size(263, 35);
            this.buttonMyBookings.TabIndex = 3;
            this.buttonMyBookings.Text = "Мои бронирования";
            this.buttonMyBookings.UseVisualStyleBackColor = false;
            this.buttonMyBookings.Click += new System.EventHandler(this.buttonMyBookings_Click);
            // 
            // buttonMyServices
            // 
            this.buttonMyServices.BackColor = System.Drawing.Color.LightCoral;
            this.buttonMyServices.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMyServices.Location = new System.Drawing.Point(100, 272);
            this.buttonMyServices.Name = "buttonMyServices";
            this.buttonMyServices.Size = new System.Drawing.Size(263, 35);
            this.buttonMyServices.TabIndex = 4;
            this.buttonMyServices.Text = "Мои услуги";
            this.buttonMyServices.UseVisualStyleBackColor = false;
            this.buttonMyServices.Click += new System.EventHandler(this.buttonMyServices_Click);
            // 
            // buttonOrderServices
            // 
            this.buttonOrderServices.BackColor = System.Drawing.Color.LightCoral;
            this.buttonOrderServices.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOrderServices.Location = new System.Drawing.Point(100, 313);
            this.buttonOrderServices.Name = "buttonOrderServices";
            this.buttonOrderServices.Size = new System.Drawing.Size(263, 35);
            this.buttonOrderServices.TabIndex = 5;
            this.buttonOrderServices.Text = "Заказать дополнительные услуги";
            this.buttonOrderServices.UseVisualStyleBackColor = false;
            this.buttonOrderServices.Click += new System.EventHandler(this.buttonOrderServices_Click);
            // 
            // buttonReviews
            // 
            this.buttonReviews.BackColor = System.Drawing.Color.LightCoral;
            this.buttonReviews.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonReviews.Location = new System.Drawing.Point(100, 354);
            this.buttonReviews.Name = "buttonReviews";
            this.buttonReviews.Size = new System.Drawing.Size(263, 35);
            this.buttonReviews.TabIndex = 6;
            this.buttonReviews.Text = "Отзывы";
            this.buttonReviews.UseVisualStyleBackColor = false;
            this.buttonReviews.Click += new System.EventHandler(this.buttonReviews_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.BackColor = System.Drawing.Color.LightGray;
            this.buttonLogout.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLogout.Location = new System.Drawing.Point(286, 395);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(77, 35);
            this.buttonLogout.TabIndex = 7;
            this.buttonLogout.Text = "Выход";
            this.buttonLogout.UseVisualStyleBackColor = false;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(150, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(163, 123);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(463, 451);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.buttonReviews);
            this.Controls.Add(this.buttonOrderServices);
            this.Controls.Add(this.buttonMyServices);
            this.Controls.Add(this.buttonMyBookings);
            this.Controls.Add(this.buttonAvailableRooms);
            this.Controls.Add(this.labelWelcome);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MainForm";
            this.Text = "Hotel Urban Stay - Гость";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Button buttonAvailableRooms;
        private System.Windows.Forms.Button buttonMyBookings;
        private System.Windows.Forms.Button buttonMyServices;
        private System.Windows.Forms.Button buttonOrderServices;
        private System.Windows.Forms.Button buttonReviews;
        private System.Windows.Forms.Button buttonLogout;
    }
}