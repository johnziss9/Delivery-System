using System;

namespace DeliverySystem.Models
{
    public class AccessWindow
    {
        public int Id { get; set; }
        public int DeliveryId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}