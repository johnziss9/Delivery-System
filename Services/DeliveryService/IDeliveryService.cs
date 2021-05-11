using System.Collections.Generic;
using System.Threading.Tasks;
using DeliverySystem.Models;

namespace DeliverySystem.Services.DeliveryService
{
    public interface IDeliveryService
    {
        Task<ServiceResponse<List<Delivery>>> AddDelivery(Delivery delivery);
        Task<ServiceResponse<List<Delivery>>> GetAllDeliveries();
        Task<ServiceResponse<Delivery>> GetDeliveryById(int id);
    }
}