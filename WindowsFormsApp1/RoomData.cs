using System.Collections.Generic;

namespace WindowsFormsApp1
{
    public class RoomData
    {
        public int RoomId { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public int BookedQuantity { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<string> ImageUrls { get; set; } = new List<string>();
    }
}