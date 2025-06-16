using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class RoomCard : UserControl
    {
        private PictureBox picRoom;
        private Label lblCategory, lblPrice, lblDesc, lblStatus;
        private DateTimePicker dtpFrom, dtpTo;
        private TextBox txtComment;
        private Button btnBook;

        public RoomCard(RoomData room)
        {
            BackColor = Color.FromArgb(52, 52, 52);
            BorderStyle = BorderStyle.None;

            InitializeComponents();
            Populate(room);
        }

        private void InitializeComponents()
        {
            picRoom = new PictureBox
            {
                Size = new Size(150, 100),
                Location = new Point(10, 10),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Black
            };

            lblCategory = new Label
            {
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(170, 10),
                AutoSize = true
            };

            lblPrice = new Label
            {
                ForeColor = Color.FromArgb(47, 180, 90),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(170, 35),
                AutoSize = true
            };

            lblStatus = new Label
            {
                ForeColor = Color.LightGray,
                Font = new Font("Segoe UI", 9),
                Location = new Point(170, 60),
                AutoSize = true
            };

            lblDesc = new Label
            {
                ForeColor = Color.LightGray,
                Font = new Font("Segoe UI", 8),
                Location = new Point(170, 80),
                Size = new Size(350, 40),
                AutoEllipsis = true
            };

            dtpFrom = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Location = new Point(170, 125),
                Size = new Size(100, 20)
            };

            dtpTo = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Location = new Point(280, 125),
                Size = new Size(100, 20)
            };

            txtComment = new TextBox
            {
                Location = new Point(170, 150),
                Size = new Size(260, 40),
                Multiline = true,
                ForeColor = Color.White,
                BackColor = Color.FromArgb(64, 64, 64),
                Font = new Font("Segoe UI", 8),
                MaxLength = 200,
                //PlaceholderText = "Комментарий (необязательно)"
            };

            btnBook = new Button
            {
                Text = "Забронировать",
                ForeColor = Color.White,
                BackColor = Color.FromArgb(47, 180, 90),
                FlatStyle = FlatStyle.Flat,
                Location = new Point(440, 150),
                Size = new Size(80, 40)
            };
            btnBook.FlatAppearance.BorderSize = 0;
            btnBook.Click += BtnBook_Click;

            Controls.AddRange(new Control[]
            {
                picRoom, lblCategory, lblPrice, lblStatus, lblDesc,
                dtpFrom, dtpTo, txtComment, btnBook
            });
        }

        private void Populate(RoomData room)
        {
            lblCategory.Text = $"Категория: {room.Category}";
            lblPrice.Text = $"Цена: {room.Price:C0}";
            lblStatus.Text = $"Свободно: {room.Quantity - room.BookedQuantity} из {room.Quantity}";
            lblDesc.Text = room.Description;

            if (!string.IsNullOrEmpty(room.ImageUrl))
            {
                try
                {
                    var req = WebRequest.Create(room.ImageUrl);
                    using (var resp = req.GetResponse())
                        picRoom.Image = Bitmap.FromStream(resp.GetResponseStream());
                }
                catch { /* если не удалось загрузить, оставляем фон */ }
            }

            // можно сохранить room.RoomId в Tag, чтобы при клике знать, что бронировать
            btnBook.Tag = room.RoomId;
        }

        private void BtnBook_Click(object sender, EventArgs e)
        {
            int roomId = (int)((Button)sender).Tag;
            DateTime from = dtpFrom.Value.Date;
            DateTime to = dtpTo.Value.Date;
            string comment = txtComment.Text.Trim();

            // TODO: добавить логику бронирования через INSERT в БД
            MessageBox.Show(
                $"Бронирование комнаты {roomId} с {from:d} по {to:d}.",
                "Бронирование",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
