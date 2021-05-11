using AutoMapper;
using DeliverySystem.Dtos.Delivery;
using DeliverySystem.Models;

namespace DeliverySystem
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Delivery, GetDeliveryDto>();
            CreateMap<AddDeliveryDto, Delivery>();
        }
    }
}