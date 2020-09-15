using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Taxi.API.IntegrationTests.Services;
using Taxi.Domain.DTO;
using Taxi.Domain.Models;
using Xunit;

namespace Taxi.API.IntegrationTests
{
    public class UsersControllerTest : IClassFixture<TestingApiFactory<Startup>>
    {
        private readonly HttpClient _client;
        private const string BaseUri = "http://localhost:5000/api/users";

        public UsersControllerTest(TestingApiFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        #region GET

        [Fact]
        public async void Get_GetUser_WithValidId_ReturnsUser()
        {
            var id = "31588e97-5c6b-48dd-89a1-edd92deb3bcb";

            var response = await _client.GetAsync($"{BaseUri}/{id}");
            var content = await response.Content.ReadAsStringAsync();
            var returnedUserDto = JsonConvert.DeserializeObject<UserDto>(content);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(id, returnedUserDto.Id);
        }
        
        [Fact]
        public async void Get_GetUser_WithInvalidId_ReturnsNotFound()
        {
            var id = "31588e97-5c6b-48dd-89a1-edd92deb3bca";

            var response = await _client.GetAsync($"{BaseUri}/{id}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        #endregion
        
        #region POST

        [Fact]
        public async void Post_SignUp_ValidModel_ReturnsOk()
        {
            var path = $"{BaseUri}/signup";
            var dto = new UserPostDto()
            {
                FirstName = "Robbe",
                LastName = "Durnez",
                Email = "robbe.durnez@hotmail.com",
                Password = "RobeDurnez9!",
                PhoneNumber = "+32497635253",
                UserType = UserType.Customer
            };
            var json = JsonConvert.SerializeObject(dto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(path, body);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void Post_SignUp_InvalidEmail_ReturnsBadRequest()
        {
            var path = $"{BaseUri}/signup";
            var dto = new UserPostDto()
            {
                FirstName = "desire",
                LastName = "Durnez",
                Email = "robbe.durnez",
                Password = "",
                PhoneNumber = "+32497635253",
                UserType = UserType.Customer
                
            };
            var json = JsonConvert.SerializeObject(dto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(path, body);
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal($"User could not be created", responseString);
        }

        [Fact]
        public async void Post_SignUp_EmailAlreadyExists_ReturnsBadRequest()
        {
            var path = $"{BaseUri}/signup";
            var dto = new UserPostDto()
            {
                FirstName = "Robbe",
                LastName = "Durnez",
                Email = "durnez.robbe@hotmail.com",
                Password = "",
                PhoneNumber = "+32497635253",
                UserType = UserType.Customer
            };
            var json = JsonConvert.SerializeObject(dto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(path, body);
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal($"Account with email {dto.Email} already exists", responseString);
        }

        [Fact]
        public async void Post_SignIn_ValidModel_ReturnsOk_ReturnsUser()
        {
            var path = $"{BaseUri}/signin";
            var dto = new UserLoginDto()
            {
                Email = "durnez.robbe@hotmail.com",
                Password = "TaxiTest1?"
            };
            var json = JsonConvert.SerializeObject(dto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(path, body);
            var content = await response.Content.ReadAsStringAsync();
            var returnedUserDto = JsonConvert.DeserializeObject<UserDto>(content);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(dto.Email, returnedUserDto.Email);
        }

        [Fact]
        public async void Post_SignIn_InvalidEmail_ReturnsNotFound()
        {
            var path = $"{BaseUri}/signin";
            var dto = new UserLoginDto()
            {
                Email = "durnez.robbe@gmail.com",
                Password = "RobeDurnez88è"
            };
            var json = JsonConvert.SerializeObject(dto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(path, body);
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            Assert.Equal($"User with email {dto.Email} not found", responseString);
        }

        [Fact]
        public async void Post_SignIn_InvalidPassword_ReturnsUnauthorized()
        {
            var path = $"{BaseUri}/signin";
            var dto = new UserLoginDto()
            {
                Email = "durnez.robbe@hotmail.com",
                Password = "TaxiTest1!"
            };
            var json = JsonConvert.SerializeObject(dto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(path, body);
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            Assert.Equal("Wrong password", responseString);
        }

        #endregion
        
        #region PUT

        [Fact]
        public async void Put_ValidModel_ReturnsOk_ReturnsUser()
        {
            const string id = "31588e97-5c6b-48dd-89a1-edd92deb3bcb";
            var path = $"{BaseUri}/update/{id}";
            var dto = new UserPutDto()
            {
                Id = id,
                Email = "durnez.robbe@hotmail.com",
                PhoneNumber = "+32496304944"
            };
            var json = JsonConvert.SerializeObject(dto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(path, body);
            var content = await response.Content.ReadAsStringAsync();
            var returnedUserDto = JsonConvert.DeserializeObject<UserDto>(content);
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(dto.PhoneNumber, returnedUserDto.PhoneNumber);
        }
        
        [Fact]
        public async void Put_IdNotEqual_ReturnsBadRequest_WithMessage()
        {
            const string id = "31588e97-5c6b-48dd-89a1-edd92deb3bcb";
            var path = $"{BaseUri}/update/{id}";
            var dto = new UserPutDto()
            {
                Id = "31588e97-5c6b-48dd-89a1-edd92deb3bca",
                Email = "durnez.robbe@hotmail.com",
                PhoneNumber = "+32496304944"
            };
            var json = JsonConvert.SerializeObject(dto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(path, body);
            var responseString = await response.Content.ReadAsStringAsync();
            
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal($"Route id {id} doesn't match ApplicationUser id {dto.Id}", responseString);
        }
        
        [Fact]
        public async void Put_InvalidId_ReturnsNotFound_WithMessage()
        {
            const string id = "31588e97-5c6b-48dd-89a1-edd92deb3bca";
            var path = $"{BaseUri}/update/{id}";
            var dto = new UserPutDto()
            {
                Id = id,
                Email = "durnez.robbe@hotmail.com",
                PhoneNumber = "+32496304944"
            };
            var json = JsonConvert.SerializeObject(dto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(path, body);
            var responseString = await response.Content.ReadAsStringAsync();
            
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal($"User with id {id} does not exist", responseString);
        }
        
        #endregion
        
        #region DELETE

        [Fact]
        public async void Delete_ValidId_ReturnsOk_ReturnsUser()
        {
            const string id = "00000000-0000-0000-0000-000000000001";
            var path = $"{BaseUri}/delete/{id}";

            var response = await _client.DeleteAsync(path);
            var responseString = await response.Content.ReadAsStringAsync();
            var dto = JsonConvert.DeserializeObject<UserDto>(responseString);
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("durnez.anthony@gmail.com", dto.Email);
        }
        
        [Fact]
        public async void Delete_InvalidId_ReturnsNotFound_WithMessage()
        {
            const string id = "31588e97-5c6b-48dd-89a1-edd92deb3bcc";
            var path = $"{BaseUri}/delete/{id}";
            
            var response = await _client.DeleteAsync(path);
            var responseString = await response.Content.ReadAsStringAsync();
            
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            Assert.Equal("User with id 31588e97-5c6b-48dd-89a1-edd92deb3bcc could not be found", responseString);
        }

        #endregion
    }
}
