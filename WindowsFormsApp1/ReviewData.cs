using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public class ReviewData
    {
        public int ReviewID { get; set; }
        public int GuestID { get; set; }
        public string GuestName { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }

        private string connectionString = "Data Source=ADCLG1;Initial Catalog=Hotel_Urban_Stay;Integrated Security=True";

        public List<ReviewData> ReviewListData()
        {
            List<ReviewData> listData = new List<ReviewData>();

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                try
                {
                    connect.Open();
                    string selectData = @"
                        SELECT R.review_id, R.guest_id, R.rating, R.comment, R.created_at, G.name
                        FROM REVIEWS R
                        INNER JOIN GUESTS G ON R.guest_id = G.guest_id";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ReviewData rd = new ReviewData
                                {
                                    ReviewID = (int)reader["review_id"],
                                    GuestID = (int)reader["guest_id"],
                                    GuestName = reader["name"].ToString(),
                                    Rating = (int)reader["rating"],
                                    Comment = reader["comment"].ToString(),
                                    CreatedAt = (DateTime)reader["created_at"]
                                };
                                listData.Add(rd);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return listData;
        }
    }
}