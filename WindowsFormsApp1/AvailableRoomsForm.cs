using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AvailableRooms : UserControl
    {
        private string connectionString = "Data Source=DESKTOP-JEM6MVF;Initial Catalog=Hotel_Urban_Stay;Integrated Security=True";

        public AvailableRooms()
        {
            InitializeComponent(); // ← обязательно!
            this.Load += (s, e) => LoadRooms(); // ← теперь вызывается, когда все компоненты уже инициализированы
        }

        private void LoadRooms()
        {
            if (flowLayoutPanelRooms == null) return;

            flowLayoutPanelRooms.Controls.Clear();

            string query = @"
                SELECT r.room_id, r.category, r.description, r.price, r.status, r.quantity, r.booked_quantity,
                       img.image_url
                FROM ROOMS r
                OUTER APPLY (
                    SELECT TOP 1 image_url
                    FROM IMAGES
                    WHERE room_id = r.room_id
                ) img";

            var rooms = new List<RoomData>();

            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        rooms.Add(new RoomData
                        {
                            RoomId = reader.GetInt32(0),
                            Category = reader.GetString(1),
                            Description = reader.GetString(2),
                            Price = reader.GetDecimal(3),
                            Status = reader.GetString(4),
                            Quantity = reader.GetInt32(5),
                            BookedQuantity = reader.GetInt32(6),
                            ImageUrl = reader.IsDBNull(7) ? null : reader.GetString(7)
                        });
                    }
                }
            }

            foreach (var room in rooms)
            {
                var card = new RoomCard(room)
                {
                    Width = 515,
                    Height = 250
                };
                flowLayoutPanelRooms.Controls.Add(card);
            }
        }
    }

    public class RoomData
    {
        public int RoomId;
        public string Category;
        public string Description;
        public decimal Price;
        public string Status;
        public int Quantity;
        public int BookedQuantity;
        public string ImageUrl;
    }
}
