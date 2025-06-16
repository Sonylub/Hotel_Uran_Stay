using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class AvailableRoomsForm : UserControl
    {
        private readonly string connectionString = "Data Source=DESKTOP-JEM6MVF;Initial Catalog=Hotel_Urban_Stay;Integrated Security=True";
        private readonly int userId;
        private string userName;
        private string userEmail;
        private string userPhone;
        private bool isRefreshing;

        public AvailableRoomsForm()
        {
            InitializeComponent();
        }

        public AvailableRoomsForm(int userId)
        {
            this.userId = userId;
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            if (DesignMode) return;
            File.AppendAllText("debug.log", $"{DateTime.Now}: InitializeData started for userId {userId}\n");
            LoadUserData();
            RefreshData();
        }

        public void RefreshData()
        {
            if (DesignMode || isRefreshing || InvokeRequired)
            {
                if (!DesignMode && InvokeRequired)
                {
                    Invoke((MethodInvoker)RefreshData);
                }
                return;
            }
            isRefreshing = true;
            File.AppendAllText("debug.log", $"{DateTime.Now}: RefreshData started\n");
            LoadRooms();
            isRefreshing = false;
            File.AppendAllText("debug.log", $"{DateTime.Now}: RefreshData completed\n");
        }

        private void LoadUserData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT name, email, phone FROM GUESTS WHERE user_id = @userId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                userName = reader["name"].ToString();
                                userEmail = reader["email"].ToString();
                                userPhone = reader["phone"].ToString();
                                File.AppendAllText("debug.log", $"{DateTime.Now}: User data loaded: {userName}\n");
                            }
                            else
                            {
                                File.AppendAllText("debug.log", $"{DateTime.Now}: Guest not found for userId {userId}\n");
                                MessageBox.Show("Гость не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText("error.log", $"{DateTime.Now}: LoadUserData error: {ex.Message}\n");
                MessageBox.Show("Ошибка загрузки данных пользователя.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRooms()
        {
            flowLayoutPanel.Controls.Clear();
            List<RoomData> rooms = new List<RoomData>();
            Dictionary<int, List<string>> roomImages = new Dictionary<int, List<string>>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string roomQuery = @"
                        SELECT r.room_id, r.category, r.quantity, r.booked_quantity, r.description, r.price
                        FROM ROOMS r
                        WHERE r.quantity > r.booked_quantity AND r.status = 'Available'";
                    using (SqlCommand cmd = new SqlCommand(roomQuery, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                RoomData room = new RoomData
                                {
                                    RoomId = reader.GetInt32(0),
                                    Category = reader.GetString(1),
                                    Quantity = reader.GetInt32(2),
                                    BookedQuantity = reader.GetInt32(3),
                                    Description = reader.IsDBNull(4) ? "" : reader.GetString(4),
                                    Price = reader.GetDecimal(5)
                                };
                                rooms.Add(room);
                                roomImages[room.RoomId] = new List<string>();
                            }
                        }
                    }

                    string imageQuery = "SELECT room_id, image_url FROM IMAGES WHERE room_id IN (SELECT room_id FROM ROOMS WHERE quantity > booked_quantity AND status = 'Available')";
                    using (SqlCommand cmd = new SqlCommand(imageQuery, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int roomId = reader.GetInt32(0);
                                string imageUrl = reader.IsDBNull(1) ? null : reader.GetString(1);
                                if (!string.IsNullOrEmpty(imageUrl) && roomImages.ContainsKey(roomId))
                                {
                                    roomImages[roomId].Add(imageUrl);
                                }
                            }
                        }
                    }
                }

                foreach (var room in rooms)
                {
                    room.ImageUrls = roomImages.ContainsKey(room.RoomId) ? roomImages[room.RoomId] : new List<string>();
                }

                File.AppendAllText("debug.log", $"{DateTime.Now}: Loaded {rooms.Count} rooms\n");
            }
            catch (Exception ex)
            {
                File.AppendAllText("error.log", $"{DateTime.Now}: LoadRooms error: {ex.Message}\n");
                MessageBox.Show("Ошибка загрузки номеров.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (rooms.Count == 0)
            {
                File.AppendAllText("debug.log", $"{DateTime.Now}: No rooms available\n");
                Label lblNoRooms = new Label
                {
                    Text = "Нет доступных номеров.",
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 12),
                    AutoSize = true,
                    Location = new Point(10, 10)
                };
                flowLayoutPanel.Controls.Add(lblNoRooms);
                return;
            }

            foreach (var room in rooms)
            {
                var card = new RoomCard(room, userId, userName, userEmail, userPhone, connectionString);
                card.Location = new Point(0, 0);
                flowLayoutPanel.Controls.Add(card);
                File.AppendAllText("debug.log", $"{DateTime.Now}: Added RoomCard for RoomId {room.RoomId}\n");
            }
        }
    }
}