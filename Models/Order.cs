namespace DeliverySystem.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int DeliveryId { get; set; }
        public int OrderNumber { get; set; }
        public string Sender { get; set; }
    }
}