using DeliverySystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeliverySystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeliveryController : Controller
    {
        private static Delivery delivery = new Delivery();

        public IActionResult Get()
        {
            return Ok(delivery);
        }
    }
}