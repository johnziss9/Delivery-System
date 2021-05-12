using System.Threading.Tasks;
using DeliverySystem.Models;

namespace DeliverySystem.Services.AuthService
{
    public class IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}