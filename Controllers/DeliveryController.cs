using System.Linq;
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

        [HttpPost]
        public IActionResult AddDelivery(Delivery delivery)
        {
            return Ok(_deliveryService.AddDelivery(delivery));
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(_deliveryService.GetAllDeliveries());
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            return Ok(_deliveryService.GetDeliveryById(id));
        }
    }
}