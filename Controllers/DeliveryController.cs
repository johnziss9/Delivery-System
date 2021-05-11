using System.Collections.Generic;
using System.Threading.Tasks;
using DeliverySystem.Dtos.Delivery;
using DeliverySystem.Models;
using DeliverySystem.Services.DeliveryService;
using Microsoft.AspNetCore.Mvc;

namespace DeliverySystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeliveryController : Controller
    {
        private readonly IDeliveryService _deliveryService;

        public DeliveryController(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ServiceResponse<List<GetDeliveryDto>> response = await _deliveryService.DeleteDelivery(id);

            if (response.Data == null)
                return NotFound(response);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDelivery(UpdateDeliveryDto updatedDelivery)
        {
            ServiceResponse<GetDeliveryDto> response = await _deliveryService.UpdateDelivery(updatedDelivery);

            if (response.Data == null)
                return NotFound(response);
            
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddDelivery(AddDeliveryDto delivery)
        {
            return Ok(await _deliveryService.AddDelivery(delivery));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _deliveryService.GetAllDeliveries());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _deliveryService.GetDeliveryById(id));
        }
    }
}