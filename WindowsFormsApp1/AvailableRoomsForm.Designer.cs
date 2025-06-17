namespace WindowsFormsApp1
{
    partial class AvailableRoomsForm
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
            this.flowLayoutPanelRooms = new System.Windows.Forms.FlowLayoutPanel();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonBookRoom = new System.Windows.Forms.Button();
            this.textBoxComment = new System.Windows.Forms.TextBox();
            this.labelComment = new System.Windows.Forms.Label();
            this.dateTimePickerCheckOut = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerCheckIn = new System.Windows.Forms.DateTimePicker();
            this.labelCheckOut = new System.Windows.Forms.Label();
            this.labelCheckIn = new System.Windows.Forms.Label();
            this.lblSelectedRoom = new System.Windows.Forms.Label();
            this.btnNextImage = new System.Windows.Forms.Button();
            this.btnPrevImage = new System.Windows.Forms.Button();
            this.lblImageCounter = new System.Windows.Forms.Label();
            this.pictureBoxSlider = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(50)))));
            this.panelMain.Controls.Add(this.label1);
            this.panelMain.Controls.Add(this.btnClose);
            this.panelMain.Controls.Add(this.flowLayoutPanelRooms);
            this.panelMain.Controls.Add(this.panelDetails);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(800, 596);
            this.panelMain.TabIndex = 0;
            // 
            // flowLayoutPanelRooms
            // 
            this.flowLayoutPanelRooms.AutoScroll = true;
            this.flowLayoutPanelRooms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(50)))));
            this.flowLayoutPanelRooms.Location = new System.Drawing.Point(12, 31);
            this.flowLayoutPanelRooms.Name = "flowLayoutPanelRooms";
            this.flowLayoutPanelRooms.Size = new System.Drawing.Size(776, 279);
            this.flowLayoutPanelRooms.TabIndex = 0;
            // 
            // panelDetails
            // 
            this.panelDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.panelDetails.Controls.Add(this.buttonExit);
            this.panelDetails.Controls.Add(this.buttonBookRoom);
            this.panelDetails.Controls.Add(this.textBoxComment);
            this.panelDetails.Controls.Add(this.labelComment);
            this.panelDetails.Controls.Add(this.dateTimePickerCheckOut);
            this.panelDetails.Controls.Add(this.dateTimePickerCheckIn);
            this.panelDetails.Controls.Add(this.labelCheckOut);
            this.panelDetails.Controls.Add(this.labelCheckIn);
            this.panelDetails.Controls.Add(this.lblSelectedRoom);
            this.panelDetails.Controls.Add(this.btnNextImage);
            this.panelDetails.Controls.Add(this.btnPrevImage);
            this.panelDetails.Controls.Add(this.lblImageCounter);
            this.panelDetails.Controls.Add(this.pictureBoxSlider);
            this.panelDetails.Location = new System.Drawing.Point(12, 316);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Size = new System.Drawing.Size(785, 277);
            this.panelDetails.TabIndex = 1;
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.buttonExit.FlatAppearance.BorderSize = 0;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.buttonExit.ForeColor = System.Drawing.Color.White;
            this.buttonExit.Location = new System.Drawing.Point(207, 226);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(100, 30);
            this.buttonExit.TabIndex = 7;
            this.buttonExit.Text = "Выход";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // buttonBookRoom
            // 
            this.buttonBookRoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(180)))), ((int)(((byte)(90)))));
            this.buttonBookRoom.FlatAppearance.BorderSize = 0;
            this.buttonBookRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBookRoom.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.buttonBookRoom.ForeColor = System.Drawing.Color.White;
            this.buttonBookRoom.Location = new System.Drawing.Point(55, 226);
            this.buttonBookRoom.Name = "buttonBookRoom";
            this.buttonBookRoom.Size = new System.Drawing.Size(133, 30);
            this.buttonBookRoom.TabIndex = 6;
            this.buttonBookRoom.Text = "Забронировать";
            this.buttonBookRoom.UseVisualStyleBackColor = false;
            this.buttonBookRoom.Click += new System.EventHandler(this.buttonBookRoom_Click);
            // 
            // textBoxComment
            // 
            this.textBoxComment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(64)))));
            this.textBoxComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxComment.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxComment.ForeColor = System.Drawing.Color.White;
            this.textBoxComment.Location = new System.Drawing.Point(28, 46);
            this.textBoxComment.Multiline = true;
            this.textBoxComment.Name = "textBoxComment";
            this.textBoxComment.Size = new System.Drawing.Size(353, 81);
            this.textBoxComment.TabIndex = 5;
            // 
            // labelComment
            // 
            this.labelComment.AutoSize = true;
            this.labelComment.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.labelComment.ForeColor = System.Drawing.Color.White;
            this.labelComment.Location = new System.Drawing.Point(24, 24);
            this.labelComment.Name = "labelComment";
            this.labelComment.Size = new System.Drawing.Size(98, 19);
            this.labelComment.TabIndex = 11;
            this.labelComment.Text = "Комментарий";
            // 
            // dateTimePickerCheckOut
            // 
            this.dateTimePickerCheckOut.CalendarFont = new System.Drawing.Font("Segoe UI", 10F);
            this.dateTimePickerCheckOut.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dateTimePickerCheckOut.Location = new System.Drawing.Point(232, 175);
            this.dateTimePickerCheckOut.Name = "dateTimePickerCheckOut";
            this.dateTimePickerCheckOut.Size = new System.Drawing.Size(147, 25);
            this.dateTimePickerCheckOut.TabIndex = 4;
            // 
            // dateTimePickerCheckIn
            // 
            this.dateTimePickerCheckIn.CalendarFont = new System.Drawing.Font("Segoe UI", 10F);
            this.dateTimePickerCheckIn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dateTimePickerCheckIn.Location = new System.Drawing.Point(50, 175);
            this.dateTimePickerCheckIn.Name = "dateTimePickerCheckIn";
            this.dateTimePickerCheckIn.Size = new System.Drawing.Size(176, 25);
            this.dateTimePickerCheckIn.TabIndex = 3;
            // 
            // labelCheckOut
            // 
            this.labelCheckOut.AutoSize = true;
            this.labelCheckOut.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.labelCheckOut.ForeColor = System.Drawing.Color.White;
            this.labelCheckOut.Location = new System.Drawing.Point(228, 153);
            this.labelCheckOut.Name = "labelCheckOut";
            this.labelCheckOut.Size = new System.Drawing.Size(90, 19);
            this.labelCheckOut.TabIndex = 9;
            this.labelCheckOut.Text = "Дата выезда";
            // 
            // labelCheckIn
            // 
            this.labelCheckIn.AutoSize = true;
            this.labelCheckIn.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.labelCheckIn.ForeColor = System.Drawing.Color.White;
            this.labelCheckIn.Location = new System.Drawing.Point(51, 153);
            this.labelCheckIn.Name = "labelCheckIn";
            this.labelCheckIn.Size = new System.Drawing.Size(84, 19);
            this.labelCheckIn.TabIndex = 8;
            this.labelCheckIn.Text = "Дата заезда";
            // 
            // lblSelectedRoom
            // 
            this.lblSelectedRoom.AutoSize = true;
            this.lblSelectedRoom.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblSelectedRoom.ForeColor = System.Drawing.Color.White;
            this.lblSelectedRoom.Location = new System.Drawing.Point(515, 12);
            this.lblSelectedRoom.Name = "lblSelectedRoom";
            this.lblSelectedRoom.Size = new System.Drawing.Size(137, 19);
            this.lblSelectedRoom.TabIndex = 8;
            this.lblSelectedRoom.Text = "Просмотр картинок";
            // 
            // btnNextImage
            // 
            this.btnNextImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(180)))), ((int)(((byte)(90)))));
            this.btnNextImage.FlatAppearance.BorderSize = 0;
            this.btnNextImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextImage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNextImage.ForeColor = System.Drawing.Color.White;
            this.btnNextImage.Location = new System.Drawing.Point(738, 124);
            this.btnNextImage.Name = "btnNextImage";
            this.btnNextImage.Size = new System.Drawing.Size(40, 40);
            this.btnNextImage.TabIndex = 2;
            this.btnNextImage.Text = ">";
            this.btnNextImage.UseVisualStyleBackColor = false;
            this.btnNextImage.Click += new System.EventHandler(this.btnNextImage_Click);
            // 
            // btnPrevImage
            // 
            this.btnPrevImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(180)))), ((int)(((byte)(90)))));
            this.btnPrevImage.FlatAppearance.BorderSize = 0;
            this.btnPrevImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevImage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPrevImage.ForeColor = System.Drawing.Color.White;
            this.btnPrevImage.Location = new System.Drawing.Point(411, 124);
            this.btnPrevImage.Name = "btnPrevImage";
            this.btnPrevImage.Size = new System.Drawing.Size(40, 40);
            this.btnPrevImage.TabIndex = 1;
            this.btnPrevImage.Text = "<";
            this.btnPrevImage.UseVisualStyleBackColor = false;
            this.btnPrevImage.Click += new System.EventHandler(this.btnPrevImage_Click);
            // 
            // lblImageCounter
            // 
            this.lblImageCounter.AutoSize = true;
            this.lblImageCounter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblImageCounter.ForeColor = System.Drawing.Color.White;
            this.lblImageCounter.Location = new System.Drawing.Point(585, 240);
            this.lblImageCounter.Name = "lblImageCounter";
            this.lblImageCounter.Size = new System.Drawing.Size(30, 19);
            this.lblImageCounter.TabIndex = 3;
            this.lblImageCounter.Text = "0/0";
            // 
            // pictureBoxSlider
            // 
            this.pictureBoxSlider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(64)))));
            this.pictureBoxSlider.Location = new System.Drawing.Point(457, 46);
            this.pictureBoxSlider.Name = "pictureBoxSlider";
            this.pictureBoxSlider.Size = new System.Drawing.Size(275, 191);
            this.pictureBoxSlider.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSlider.TabIndex = 0;
            this.pictureBoxSlider.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(760, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(26, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 19);
            this.label1.TabIndex = 12;
            this.label1.Text = "Доступные номера:";
            // 
            // AvailableRoomsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 596);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AvailableRoomsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Доступные номера";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSlider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelRooms;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pictureBoxSlider;
        private System.Windows.Forms.Label lblImageCounter;
        private System.Windows.Forms.Button btnPrevImage;
        private System.Windows.Forms.Button btnNextImage;
        private System.Windows.Forms.Label lblSelectedRoom;
        private System.Windows.Forms.Button buttonBookRoom;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label labelCheckIn;
        private System.Windows.Forms.Label labelCheckOut;
        private System.Windows.Forms.DateTimePicker dateTimePickerCheckIn;
        private System.Windows.Forms.DateTimePicker dateTimePickerCheckOut;
        private System.Windows.Forms.Label labelComment;
        private System.Windows.Forms.TextBox textBoxComment;
        private System.Windows.Forms.Label label1;
    }
}