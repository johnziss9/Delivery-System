namespace DeliverySystem.Models
{
    public class Recipient
    {
        public int Id { get; set; }
        public int DeliveryId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}