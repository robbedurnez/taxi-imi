using System;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Taxi.API.IntegrationTests.Services;
using Taxi.Domain.DTO;
using Xunit;

namespace Taxi.API.IntegrationTests
{
    public class CustomersControllerTest : IClassFixture<TestingApiFactory<Startup>>
    {
        private readonly HttpClient _client;
        private const string BaseUri = "http://localhost:5000/api/customers";

        public CustomersControllerTest(TestingApiFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }
        
        #region GET

        [Fact]
        public async void Get_Get_ValidId_ReturnsOk_ReturnsCustomer()
        {
            var id = "00000000-0000-0000-0000-000000000020";
            var path = $"{BaseUri}/{id}";

            var response = await _client.GetAsync(path);
            var content = await response.Content.ReadAsStringAsync();
            var customer = JsonConvert.DeserializeObject<CustomerDto>(content);
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(customer.Id, id);
        }
        
        [Fact]
        public async void Get_Get_InvalidId_ReturnsNotFound()
        {
            var id = "00000000-0000-0000-0000-000000001234";
            var path = $"{BaseUri}/{id}";

            var response = await _client.GetAsync(path);
            var content = await response.Content.ReadAsStringAsync();
            
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            Assert.Equal($"Entity with id {id} was not found!", content);
        }

        #endregion

        #region POST

        [Fact]
        public async void Post_Add_ValidModel_ReturnsCreated_ReturnsModel()
        {
            var path = $"{BaseUri}";
            var dto = new CustomerDto()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Willy",
                LastName = "Naessens",
                PhoneNumber = "123456789012",
                Email = "willynaessens@taxi.com"
            };
            var json = JsonConvert.SerializeObject(dto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(path, body);
            var content = await response.Content.ReadAsStringAsync();
            var customer = JsonConvert.DeserializeObject<CustomerDto>(content);
            
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(dto.Id, customer.Id);
        }
        
        [Fact]
        public async void Post_Add_InvalidModel_ReturnsBadRequest()
        {
            var path = $"{BaseUri}";
            var dto = new CustomerDto()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Willy",
                PhoneNumber = "123456789012",
                Email = "willynaessens@taxi.com"
            };
            var json = JsonConvert.SerializeObject(dto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(path, body);
            
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        #endregion

        #region PUT

        [Fact]
        public async void Put_Put_IdsDontMatch_ReturnsBadRequest()
        {
            var id = "00000000-0000-0000-0000-000000000020";
            var path = $"{BaseUri}/{id}";
            var dto = new CustomerDto()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Customer7",
                LastName = "Taxi",
                Email = "customer7@taxi.com"
            };
            var json = JsonConvert.SerializeObject(dto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await _client.PutAsync(path, body);
            var responseString = await response.Content.ReadAsStringAsync();
            
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("No matching ID's", responseString);
        }
        
        [Fact]
        public async void Put_Put_InvalidModel_ReturnsBadRequest()
        {
            var id = "00000000-0000-0000-0000-0000000000020";
            var path = $"{BaseUri}/{id}";
            var dto = new CustomerDto()
            {
                Id = "00000000-0000-0000-0000-0000000000020",
                FirstName = "Willy",
                Email = "willynaessens@taxi.com"
            };
            var json = JsonConvert.SerializeObject(dto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync(path, body);
            
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async void Put_Put_ValidModel_ReturnsOk_ReturnsCustomer()
        {
            var id = "00000000-0000-0000-0000-000000000020";
            var path = $"{BaseUri}/{id}";
            var dto = new CustomerDto()
            {
                Id = "00000000-0000-0000-0000-000000000020",
                FirstName = "Customer7",
                LastName = "Taxi",
                PhoneNumber = "0473645362",
                Email = "customer7@taxi.com"
            };
            var json = JsonConvert.SerializeObject(dto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await _client.PutAsync(path, body);
            var content = await response.Content.ReadAsStringAsync();
            var customer = JsonConvert.DeserializeObject<CustomerDto>(content);
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(dto.Id, customer.Id);
        }

        #endregion
        
        #region DELETE

        [Fact]
        public async void Delete_Delete_InvalidId_ReturnsNotFound()
        {
            var id = Guid.NewGuid().ToString();
            var path = $"{BaseUri}/{id}";
            
            var result = await _client.DeleteAsync(path);
            var content = await result.Content.ReadAsStringAsync();
            
            Assert.Equal(HttpStatusCode.NotFound, result.StatusCode);
            Assert.Equal($"Entity with id {id} was not found!", content);
        }
        
        [Fact]
        public async void Delete_Delete_ValidId_ReturnsOk_ReturnsCompany()
        {
            var id = "00000000-0000-0000-0000-000000000021";
            var path = $"{BaseUri}/{id}";
            
            var response = await _client.DeleteAsync(path);
            var content = await response.Content.ReadAsStringAsync();
            var customer = JsonConvert.DeserializeObject<CustomerDto>(content);
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(id, customer.Id);
        }

        #endregion
    }
}