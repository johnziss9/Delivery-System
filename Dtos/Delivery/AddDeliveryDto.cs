namespace DeliverySystem.Dtos.Delivery
{
    public class AddDeliveryDto
    {
        public string State { get; set; }
        public AccessWindowDto AccessWindow { get; set; }
        public RecipientDto Recipient { get; set; }
        public OrderDto Order { get; set; }
    }
}