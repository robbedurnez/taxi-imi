using System.Threading.Tasks;
using Taxi.Domain.DTO;
using Taxi.MobileApp.Models;

namespace Taxi.MobileApp.Contracts
{
    public interface IUsersService
    {
        Task<User> GetUser(string id);
        Task<bool> UpdateUser(User updatedUser);
        Task<User> SignInAsync(UserLoginDto dto);
        Task<User> SignUpAsync(UserPostDto dto);
        Task<User> LoadUserAsync();
        Task SignOutAsync();
    }
}
