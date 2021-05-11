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
            ServiceResponse<GetDeliveryDto> serviceResponse = new ServiceResponse<GetDeliveryDto>();

            try
            {
                Delivery delivery = await _context.Deliveries.FirstOrDefaultAsync(d => d.Id == updatedDelivery.Id);
                delivery.State = updatedDelivery.State;
                // Did not include the rest of the properties as the state will be the only thing that will need be updated.

                _context.Deliveries.Update(delivery);
                await _context.SaveChangesAsync();

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