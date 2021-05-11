using System.Threading.Tasks;
using DeliverySystem.Dtos.Delivery;
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