using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<ServiceResponse<List<Delivery>>> AddDelivery(Delivery delivery)
        {
            ServiceResponse<List<Delivery>> serviceResponse = new ServiceResponse<List<Delivery>>();
            deliveries.Add(delivery);
            serviceResponse.Data = deliveries;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Delivery>>> GetAllDeliveries()
        {
            ServiceResponse<List<Delivery>> serviceResponse = new ServiceResponse<List<Delivery>>();
            serviceResponse.Data = deliveries;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Delivery>> GetDeliveryById(int id)
        {
            ServiceResponse<Delivery> serviceResponse = new ServiceResponse<Delivery>();
            serviceResponse.Data = deliveries.FirstOrDefault(d => d.Id == id);
            return serviceResponse;
        }
    }
}