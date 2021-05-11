using System.Collections.Generic;
using DeliverySystem.Models;

namespace DeliverySystem.Services.DeliveryService
{
    public interface IDeliveryService
    {
        List<Delivery> AddDelivery(Delivery delivery);

        List<Delivery> GetAllDeliveries();
        Delivery GetDeliveryById(int id);
    }
}