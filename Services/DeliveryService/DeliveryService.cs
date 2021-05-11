using System.Collections.Generic;
using System.Linq;
using DeliverySystem.Models;

namespace DeliverySystem.Services.DeliveryService
{
    public class DeliveryService : IDeliveryService
    {
        private static List<Delivery> deliveries = new List<Delivery>
        {
            new Delivery(),
            new Delivery { Id = 1, State = "Expired" }
        };

        public List<Delivery> AddDelivery(Delivery delivery)
        {
            deliveries.Add(delivery);
            return deliveries;
        }

        public List<Delivery> GetAllDeliveries()
        {
            return deliveries;
        }

        public Delivery GetDeliveryById(int id)
        {
            return deliveries.FirstOrDefault(d => d.Id == id);
        }
    }
}