using DeliverySystem.Models;

namespace DeliverySystem.Dtos.Delivery
{
    public class GetDeliveryDto
    {
        public int Id { get; set; }
        public string State { get; set; }
        public AccessWindow AccessWindow { get; set; }
        public Recipient Recipient { get; set; }
        public Order Order { get; set; }
    }
}