using System.Collections.Generic;
using System.Threading.Tasks;
using DeliverySystem.Dtos.Delivery;
using DeliverySystem.Models;

namespace DeliverySystem.Services.DeliveryService
{
    public interface IDeliveryService
    {
        Task<ServiceResponse<List<GetDeliveryDto>>> DeleteDelivery(int id);
        Task<ServiceResponse<GetDeliveryDto>>UpdateDelivery(UpdateDeliveryDto updatedDelivery);
        Task<ServiceResponse<List<GetDeliveryDto>>> AddDelivery(AddDeliveryDto newDelivery);
        Task<ServiceResponse<List<GetDeliveryDto>>> GetAllDeliveries();
        Task<ServiceResponse<GetDeliveryDto>> GetDeliveryById(int id);
    }
}