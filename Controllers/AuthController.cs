using System.Threading.Tasks;
using DeliverySystem.Dtos.User;
using DeliverySystem.Models;
using DeliverySystem.Services.AuthService;
using Microsoft.AspNetCore.Mvc;

namespace DeliverySystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;

        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterDto request)
        {
            ServiceResponse<int> response = await _authRepo.Register(new User { Username = request.Username }, request.Password );

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
    }
}