using System.Collections.Generic;
using System.Linq;
using DeliverySystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeliverySystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeliveryController : Controller
    {
        private static List<Delivery> deliveries = new List<Delivery>
        {
            new Delivery(),
            new Delivery { Id = 1, State = "Expired" }
        };

        [HttpPost]
        public IActionResult AddDelivery(Delivery delivery)
        {
            deliveries.Add(delivery);
            return Ok(deliveries);
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(deliveries);
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            return Ok(deliveries.FirstOrDefault(c => c.Id == id));
        }
    }
}