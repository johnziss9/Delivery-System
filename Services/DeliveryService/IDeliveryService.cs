using System.Collections.Generic;
using System.Threading.Tasks;
using DeliverySystem.Models;

namespace DeliverySystem.Services.DeliveryService
{
    public interface IDeliveryService
    {
        Task<List<Delivery>> AddDelivery(Delivery delivery);

        Task<List<Delivery>> GetAllDeliveries();

        Task<Delivery> GetDeliveryById(int id);
    }
}