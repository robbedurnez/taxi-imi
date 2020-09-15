using System;
using System.Threading.Tasks;
using Taxi.Domain.DTO;
using Taxi.MobileApp.Contracts;
using Taxi.MobileApp.Models;

namespace Taxi.MobileApp.Services.Mocking
{
    public class MockUsersService : IUsersService
    {
        private static User currentUser = new User
        {
        };

        public async Task<User> GetUser()
        {
            return await Task.FromResult(currentUser);
        }

        public Task<User> SignInAsync(UserLoginDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<User> SignUpAsync(UserPostDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<User> LoadUserAsync()
        {
            throw new NotImplementedException();
        }

        public Task SignOutAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUser(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateUser(User updatedUser)
        {
            currentUser = updatedUser;
            return await Task.FromResult(true);
        }
    }
}
