using System.Collections.Generic;
using System.Threading.Tasks;
using DeliverySystem.Dtos.Delivery;
using DeliverySystem.Models;

namespace DeliverySystem.Services.DeliveryService
{
    public interface IDeliveryService
    {
        Task<ServiceResponse<List<GetDeliveryDto>>> AddDelivery(AddDeliveryDto delivery);
        Task<ServiceResponse<List<GetDeliveryDto>>> GetAllDeliveries();
        Task<ServiceResponse<GetDeliveryDto>> GetDeliveryById(int id);
    }
}