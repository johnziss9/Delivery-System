using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DeliverySystem.Dtos.Delivery;
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

        private readonly IMapper _mapper;

        public DeliveryService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetDeliveryDto>>> DeleteDelivery(int id)
        {
            ServiceResponse<List<GetDeliveryDto>> serviceResponse = new ServiceResponse<List<GetDeliveryDto>>();

            try
            {
                Delivery delivery = deliveries.First(d => d.Id == id);
                deliveries.Remove(delivery);

                serviceResponse.Data = (deliveries.Select(d => _mapper.Map<GetDeliveryDto>(d))).ToList();
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetDeliveryDto>> UpdateDelivery(UpdateDeliveryDto updatedDelivery)
        {
            ServiceResponse<GetDeliveryDto> serviceResponse = new ServiceResponse<GetDeliveryDto>();

            try
            {
                Delivery delivery = deliveries.FirstOrDefault(d => d.Id == updatedDelivery.Id);
                delivery.State = updatedDelivery.State;
                // Did not include the rest of the properties as the state will be the only thing that will need be updated.

                serviceResponse.Data = _mapper.Map<GetDeliveryDto>(delivery);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetDeliveryDto>>> AddDelivery(AddDeliveryDto newDelivery)
        {
            ServiceResponse<List<GetDeliveryDto>> serviceResponse = new ServiceResponse<List<GetDeliveryDto>>();
            Delivery delivery = _mapper.Map<Delivery>(newDelivery);
            // Increasing the Id each time a new delivery is added.
            delivery.Id = deliveries.Max(d => d.Id) + 1;
            deliveries.Add(delivery);
            serviceResponse.Data = (deliveries.Select(d => _mapper.Map<GetDeliveryDto>(d))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetDeliveryDto>>> GetAllDeliveries()
        {
            ServiceResponse<List<GetDeliveryDto>> serviceResponse = new ServiceResponse<List<GetDeliveryDto>>();
            serviceResponse.Data = (deliveries.Select(d => _mapper.Map<GetDeliveryDto>(d))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetDeliveryDto>> GetDeliveryById(int id)
        {
            ServiceResponse<GetDeliveryDto> serviceResponse = new ServiceResponse<GetDeliveryDto>();
            serviceResponse.Data = _mapper.Map<GetDeliveryDto>(deliveries.FirstOrDefault(d => d.Id == id));
            return serviceResponse;
        }
    }
}