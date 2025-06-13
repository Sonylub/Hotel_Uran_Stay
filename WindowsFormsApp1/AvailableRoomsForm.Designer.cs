using System;
using System.Drawing;
using System.Windows.Forms;

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

        private void InitializeComponent()
        {
            this.flowLayoutPanelRooms = new FlowLayoutPanel();
            this.panelBooking = new Panel();
            this.buttonClose = new Button();
            this.buttonBook = new Button();
            this.textBoxComment = new TextBox();
            this.labelComment = new Label();
            this.dateTimePickerCheckOut = new DateTimePicker();
            this.labelCheckOut = new Label();
            this.dateTimePickerCheckIn = new DateTimePicker();
            this.labelCheckIn = new Label();
            this.flowLayoutPanelThumbnails = new FlowLayoutPanel();
            this.labelTitle = new Label();
            this.pictureBoxMainImage = new PictureBox();
            this.panelBooking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMainImage)).BeginInit();
            this.SuspendLayout();

            // flowLayoutPanelRooms
            this.flowLayoutPanelRooms.AutoScroll = true;
            this.flowLayoutPanelRooms.BackColor = Color.FromArgb(245, 245, 220);
            this.flowLayoutPanelRooms.Location = new Point(12, 50);
            this.flowLayoutPanelRooms.Name = "flowLayoutPanelRooms";
            this.flowLayoutPanelRooms.Size = new Size(600, 500);
            this.flowLayoutPanelRooms.TabIndex = 0;

            // panelBooking
            this.panelBooking.BackColor = Color.FromArgb(243, 244, 246);
            this.panelBooking.Controls.Add(this.buttonClose);
            this.panelBooking.Controls.Add(this.buttonBook);
            this.panelBooking.Controls.Add(this.textBoxComment);
            this.panelBooking.Controls.Add(this.labelComment);
            this.panelBooking.Controls.Add(this.dateTimePickerCheckOut);
            this.panelBooking.Controls.Add(this.labelCheckOut);
            this.panelBooking.Controls.Add(this.dateTimePickerCheckIn);
            this.panelBooking.Controls.Add(this.labelCheckIn);
            this.panelBooking.Controls.Add(this.flowLayoutPanelThumbnails);
            this.panelBooking.Controls.Add(this.pictureBoxMainImage);
            this.panelBooking.Location = new Point(618, 50);
            this.panelBooking.Name = "panelBooking";
            this.panelBooking.Size = new Size(300, 500);
            this.panelBooking.TabIndex = 1;

            // buttonClose
            this.buttonClose.BackColor = Color.FromArgb(107, 114, 128);
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = FlatStyle.Flat;
            this.buttonClose.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.buttonClose.ForeColor = Color.White;
            this.buttonClose.Location = new Point(155, 460);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new Size(135, 35);
            this.buttonClose.TabIndex = 9;
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new EventHandler(this.buttonClose_Click);

            // buttonBook
            this.buttonBook.BackColor = Color.FromArgb(30, 64, 175);
            this.buttonBook.FlatAppearance.BorderSize = 0;
            this.buttonBook.FlatStyle = FlatStyle.Flat;
            this.buttonBook.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.buttonBook.ForeColor = Color.White;
            this.buttonBook.Location = new Point(10, 460);
            this.buttonBook.Name = "buttonBook";
            this.buttonBook.Size = new Size(135, 35);
            this.buttonBook.TabIndex = 8;
            this.buttonBook.Text = "Бронировать";
            this.buttonBook.UseVisualStyleBackColor = false;
            this.buttonBook.Click += new EventHandler(this.buttonBook_Click);

            // textBoxComment
            this.textBoxComment.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.textBoxComment.Location = new Point(10, 410);
            this.textBoxComment.Multiline = true;
            this.textBoxComment.Name = "textBoxComment";
            this.textBoxComment.Size = new Size(280, 40);
            this.textBoxComment.TabIndex = 7;
            this.textBoxComment.TextChanged += new EventHandler(this.textBoxComment_TextChanged);

            // labelComment
            this.labelComment.AutoSize = true;
            this.labelComment.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.labelComment.ForeColor = Color.FromArgb(31, 41, 55);
            this.labelComment.Location = new Point(10, 390);
            this.labelComment.Name = "labelComment";
            this.labelComment.Size = new Size(100, 19);
            this.labelComment.TabIndex = 6;
            this.labelComment.Text = "Комментарий:";

            // dateTimePickerCheckOut
            this.dateTimePickerCheckOut.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerCheckOut.Location = new Point(10, 360);
            this.dateTimePickerCheckOut.Name = "dateTimePickerCheckOut";
            this.dateTimePickerCheckOut.Size = new Size(280, 25);
            this.dateTimePickerCheckOut.TabIndex = 5;
            this.dateTimePickerCheckOut.ValueChanged += new EventHandler(this.dateTimePickerCheckOut_ValueChanged);

            // labelCheckOut
            this.labelCheckOut.AutoSize = true;
            this.labelCheckOut.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.labelCheckOut.ForeColor = Color.FromArgb(31, 41, 55);
            this.labelCheckOut.Location = new Point(10, 340);
            this.labelCheckOut.Name = "labelCheckOut";
            this.labelCheckOut.Size = new Size(91, 19);
            this.labelCheckOut.TabIndex = 4;
            this.labelCheckOut.Text = "Дата выезда:";

            // dateTimePickerCheckIn
            this.dateTimePickerCheckIn.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerCheckIn.Location = new Point(10, 310);
            this.dateTimePickerCheckIn.Name = "dateTimePickerCheckIn";
            this.dateTimePickerCheckIn.Size = new Size(280, 25);
            this.dateTimePickerCheckIn.TabIndex = 3;
            this.dateTimePickerCheckIn.ValueChanged += new EventHandler(this.dateTimePickerCheckIn_ValueChanged);

            // labelCheckIn
            this.labelCheckIn.AutoSize = true;
            this.labelCheckIn.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.labelCheckIn.ForeColor = Color.FromArgb(31, 41, 55);
            this.labelCheckIn.Location = new Point(10, 290);
            this.labelCheckIn.Name = "labelCheckIn";
            this.labelCheckIn.Size = new Size(87, 19);
            this.labelCheckIn.TabIndex = 2;
            this.labelCheckIn.Text = "Дата заезда:";

            // flowLayoutPanelThumbnails
            this.flowLayoutPanelThumbnails.AutoScroll = true;
            this.flowLayoutPanelThumbnails.Location = new Point(10, 200);
            this.flowLayoutPanelThumbnails.Name = "flowLayoutPanelThumbnails";
            this.flowLayoutPanelThumbnails.Size = new Size(280, 80);
            this.flowLayoutPanelThumbnails.TabIndex = 1;

            // labelTitle
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            this.labelTitle.ForeColor = Color.FromArgb(31, 41, 55);
            this.labelTitle.Location = new Point(12, 12);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new Size(219, 30);
            this.labelTitle.TabIndex = 2;
            this.labelTitle.Text = "Доступные номера";

            // pictureBoxMainImage
            this.pictureBoxMainImage.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBoxMainImage.Location = new Point(10, 10);
            this.pictureBoxMainImage.Name = "pictureBoxMainImage";
            this.pictureBoxMainImage.Size = new Size(280, 180);
            this.pictureBoxMainImage.SizeMode = PictureBoxSizeMode.Zoom;
            this.pictureBoxMainImage.TabIndex = 0;
            this.pictureBoxMainImage.TabStop = false;

            // AvailableRoomsForm
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(245, 245, 220);
            this.ClientSize = new Size(930, 575);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.panelBooking);
            this.Controls.Add(this.flowLayoutPanelRooms);
            this.Name = "AvailableRoomsForm";
            this.Text = "Доступные номера";
            this.panelBooking.ResumeLayout(false);
            this.panelBooking.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMainImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private FlowLayoutPanel flowLayoutPanelRooms;
        private Panel panelBooking;
        private Label labelTitle;
        private PictureBox pictureBoxMainImage;
        private FlowLayoutPanel flowLayoutPanelThumbnails;
        private Label labelCheckIn;
        private DateTimePicker dateTimePickerCheckIn;
        private Label labelCheckOut;
        private DateTimePicker dateTimePickerCheckOut;
        private Label labelComment;
        private TextBox textBoxComment;
        private Button buttonBook;
        private Button buttonClose;
    }
}