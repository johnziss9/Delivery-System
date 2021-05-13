using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DeliverySystem.Data;
using DeliverySystem.Dtos.Delivery;
using DeliverySystem.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliverySystem.Services.DeliveryService
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public DeliveryService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetDeliveryDto>>> DeleteDelivery(int id)
        {
            ServiceResponse<List<GetDeliveryDto>> serviceResponse = new ServiceResponse<List<GetDeliveryDto>>();

            try
            {
                Delivery delivery = await _context.Deliveries.FirstAsync(d => d.Id == id);
                _context.Deliveries.Remove(delivery);

                await _context.SaveChangesAsync();

                serviceResponse.Data = (_context.Deliveries.Select(d => _mapper.Map<GetDeliveryDto>(d))).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetDeliveryDto>> UpdateDelivery(UpdateDeliveryDto updatedDelivery)
        {
            var currentTime = DateTime.Now;

            ServiceResponse<GetDeliveryDto> serviceResponse = new ServiceResponse<GetDeliveryDto>();

            try
            {
                Delivery delivery = await _context.Deliveries.FirstOrDefaultAsync(d => d.Id == updatedDelivery.Id);

                switch(updatedDelivery.State.ToLower())
                {
                    case "created": 
                        serviceResponse.Success = false;
                        serviceResponse.Message = "Cannot change state to created";
                        break;
                    case "approved":
                        if (delivery.State.ToLower() == "created")
                        {
                            delivery.State = updatedDelivery.State;
                            _context.Deliveries.Update(delivery);
                            await _context.SaveChangesAsync();
                            serviceResponse.Data = _mapper.Map<GetDeliveryDto>(delivery);
                        }
                        else
                        {
                            serviceResponse.Success = false;
                            serviceResponse.Message = $"Cannot change state to prroved from current {delivery.State} value";
                        }
                        break;
                    case "completed":
                        if ((delivery.State.ToLower() == "created" || delivery.State.ToLower() == "approved") && 
                        (currentTime >= delivery.AccessWindow.StartTime && currentTime <= delivery.AccessWindow.EndTime))
                        {
                            delivery.State = updatedDelivery.State;
                            _context.Deliveries.Update(delivery);
                            await _context.SaveChangesAsync();
                            serviceResponse.Data = _mapper.Map<GetDeliveryDto>(delivery);
                        }
                        else
                        {
                            serviceResponse.Success = false;
                            serviceResponse.Message = $"Cannot change state to prroved from current {delivery.State} value";
                        }
                        break;
                    case "cancelled":
                        if (delivery.State.ToLower() == "created" || delivery.State.ToLower() == "approved")
                        {
                            delivery.State = updatedDelivery.State;
                            _context.Deliveries.Update(delivery);
                            await _context.SaveChangesAsync();
                            serviceResponse.Data = _mapper.Map<GetDeliveryDto>(delivery);
                        }
                        else
                        {
                            serviceResponse.Success = false;
                            serviceResponse.Message = $"Cannot change state to prroved from current {delivery.State} value";
                        }
                        break;
                    case "expired":
                        if ((delivery.State.ToLower() == "created" || delivery.State.ToLower() == "approved") && 
                        currentTime > delivery.AccessWindow.EndTime)
                        {
                            delivery.State = updatedDelivery.State;
                            _context.Deliveries.Update(delivery);
                            await _context.SaveChangesAsync();
                            serviceResponse.Data = _mapper.Map<GetDeliveryDto>(delivery);
                        }
                        else
                        {
                            serviceResponse.Success = false;
                            serviceResponse.Message = $"Cannot change state to prroved from current {delivery.State} value";
                        }
                        break;
                    default:
                        serviceResponse.Success = false;
                        serviceResponse.Message = $"Cannot change state to incorrect value";
                        break;                  
                }
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
            await _context.Deliveries.AddAsync(delivery);
            await _context.SaveChangesAsync();
            serviceResponse.Data = (_context.Deliveries.Select(d => _mapper.Map<GetDeliveryDto>(d))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetDeliveryDto>>> GetAllDeliveries()
        {
            ServiceResponse<List<GetDeliveryDto>> serviceResponse = new ServiceResponse<List<GetDeliveryDto>>();
            List<Delivery> dbDeliveries = await _context.Deliveries.ToListAsync();
            serviceResponse.Data = (dbDeliveries.Select(d => _mapper.Map<GetDeliveryDto>(d))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetDeliveryDto>> GetDeliveryById(int id)
        {
            ServiceResponse<GetDeliveryDto> serviceResponse = new ServiceResponse<GetDeliveryDto>();
            Delivery dbDelivery = await _context.Deliveries.FirstOrDefaultAsync(d => d.Id == id);
            serviceResponse.Data = _mapper.Map<GetDeliveryDto>(dbDelivery);
            return serviceResponse;
        }
    }
}