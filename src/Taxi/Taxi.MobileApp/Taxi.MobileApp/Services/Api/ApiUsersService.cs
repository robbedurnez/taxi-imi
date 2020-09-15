using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Taxi.Domain.Constants;
using Taxi.Domain.DTO;
using Taxi.Domain.Models;
using Taxi.MobileApp.Contracts;
using Xamarin.Essentials;
using Xamarin.Forms;
using User = Taxi.MobileApp.Models.User;

namespace Taxi.MobileApp.Services.Api
{
    public class ApiUsersService : IUsersService
    {
        private readonly string _baseUri = $"{Connection.ApiHome}/api/users";
        private readonly IMapper _mapper;

        public ApiUsersService()
        {
            _mapper = App.CreateMapper();
        }

        public async Task<User> GetUser(string id)
        {
            var path = $"{_baseUri}/{id}";

            try
            {
                var userDto = await WebApiClient.GetApiResult<UserDto>(path);

                return userDto == null ? null : _mapper.Map<User>(userDto);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<User> SignInAsync(UserLoginDto dto)
        {
            var path = $"{_baseUri}/signin";

            try
            {
                var userDto = await WebApiClient.PostCallApi<UserDto, UserLoginDto>(path, dto);

                if (userDto == null)
                {
                    return null;
                }

                var user = _mapper.Map<User>(userDto);

                await SaveUserAsync(user);

                return user;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<User> SignUpAsync(UserPostDto dto)
        {
            var path = $"{_baseUri}/signup";

            try
            {
                var userDto = await WebApiClient.PostCallApi<UserDto, UserPostDto>(path, dto);

                var user = _mapper.Map<User>(userDto);

                await SaveUserAsync(user);

                return user;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public Task<bool> UpdateUser(User updatedUser)
        {
            throw new NotImplementedException();
        }

        private static async Task SaveUserAsync(User user)
        {
            var jsonUser = JsonConvert.SerializeObject(user);
            var folder = FileSystem.AppDataDirectory;
            var fullPath = Path.Combine(folder, "user.json");

            await File.WriteAllTextAsync(fullPath, jsonUser);
        }

        public async Task<User> LoadUserAsync()
        {
            var path = Path.Combine(FileSystem.AppDataDirectory, "user.json");
            var json = await File.ReadAllTextAsync(path);
            var user = JsonConvert.DeserializeObject<User>(json);

            return user;
        }

        public async Task SignOutAsync()
        {
            var user = await LoadUserAsync();
            var path = Path.Combine(FileSystem.AppDataDirectory, "user.json");

            if (user.UserType == UserType.Driver)
            {
                MessagingCenter.Send<object, string>(this, MessagingCenterMessages.DriverSignOut, user.Id);
            }

            File.Delete(path);
        }
    }
}
