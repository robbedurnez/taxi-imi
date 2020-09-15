using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Taxi.API.IntegrationTests.Services;
using Taxi.Domain.DTO;
using Xunit;

namespace Taxi.API.IntegrationTests
{
    public class AddressesControllerTest : IClassFixture<TestingApiFactory<Startup>>
    {
        private readonly HttpClient _client;
        private const string BaseUri = "http://localhost:5000/api/addresses";

        public AddressesControllerTest(TestingApiFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        #region GET

        [Fact]
        public async void Get_GetByUserId_ValidId_ReturnsOk_ReturnsModel()
        {
            var id = "31588e97-5c6b-48dd-89a1-edd92deb3bcb";
            var path = $"{BaseUri}/GetByUserId/{id}";

            var result = await _client.GetAsync(path);
            var content = await result.Content.ReadAsStringAsync();
            var addresses = JsonConvert.DeserializeObject<List<AddressDto>>(content);
            
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            addresses.ForEach(a => Assert.Equal(id, a.UserId));
        }

        [Fact]
        public async void Get_GetByUserId_InvalidId_ReturnsNotFound()
        {
            var id = Guid.NewGuid().ToString();
            var path = $"{BaseUri}/GetByUserId/{id}";

            var result = await _client.GetAsync(path);
            var content = await result.Content.ReadAsStringAsync();
            
            Assert.Equal($"No addresses found for user with id {id}", content);
            Assert.Equal(HttpStatusCode.NotFound, result.StatusCode);
        }

        #endregion

        #region POST

        [Fact]
        public async void Post_Add_ValidModel_ReturnsCreated_ReturnsModel()
        {
            var path = $"{BaseUri}";
            var dto = new AddressDto()
            {
                Id = Guid.NewGuid().ToString(),
                AddressLine1 = "Teststraat 1",
                AddressLine2 = "",
                City = "TestStad",
                PostalCode = "0000",
                UserId = "31588e97-5c6b-48dd-8ba1-edd92deb3bca",
                Latitude = 10,
                Longitude = 5
            };
            var json = JsonConvert.SerializeObject(dto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(path, body);
            var content = await response.Content.ReadAsStringAsync();
            var address = JsonConvert.DeserializeObject<AddressDto>(content);
            
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(dto.Id, address.Id);
        }

        [Fact]
        public async void Post_Add_InvalidModel_ReturnsBadRequest()
        {
            var path = $"{BaseUri}";
            var dto = new AddressDto()
            {
                Id = Guid.NewGuid().ToString(),
                AddressLine1 = "Teststraat 1",
                AddressLine2 = "",
                City = "TestStad",
                PostalCode = "",
                UserId = "31588e97-5c6b-48dd-8ba1-edd92deb3bca",
                Latitude = 10,
                Longitude = 5
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
            var id = Guid.NewGuid().ToString();
            var path = $"{BaseUri}/{id}";
            var dto = new AddressDto()
            {
                Id = Guid.NewGuid().ToString(),
                AddressLine1 = "Teststraat 1",
                AddressLine2 = "",
                City = "TestStad",
                PostalCode = "0000",
                UserId = "31588e97-5c6b-48dd-8ba1-edd92deb3bca",
                Latitude = 10,
                Longitude = 5
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
            var id = Guid.NewGuid().ToString();
            var path = $"{BaseUri}/{id}";
            var dto = new AddressDto()
            {
                Id = id,
                AddressLine1 = "Teststraat 1",
                AddressLine2 = "",
                City = "TestStad",
                PostalCode = "",
                UserId = "31588e97-5c6b-48dd-8ba1-edd92deb3bca",
                Latitude = 10,
                Longitude = 5
            };
            var json = JsonConvert.SerializeObject(dto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync(path, body);
            var responseString = await response.Content.ReadAsStringAsync();
            
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async void Put_Put_ValidModel_ReturnsOk_ReturnsAddress()
        {
            var id = "31588e97-5c6b-48dd-89a1-edd92deb3bbb";
            var path = $"{BaseUri}/{id}";
            var dto = new AddressDto()
            {
                Id = id,
                AddressLine1 = "Teststraat 1",
                AddressLine2 = "",
                City = "TestStad",
                PostalCode = "9999",
                UserId = "31588e97-5c6b-48dd-8ba1-edd92deb3bca",
                Latitude = 10,
                Longitude = 5
            };
            var json = JsonConvert.SerializeObject(dto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync(path, body);
            var content = await response.Content.ReadAsStringAsync();
            var address = JsonConvert.DeserializeObject<AddressDto>(content);
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(dto.Id, address.Id);
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
        public async void Delete_Delete_ValidId_ReturnsOk_ReturnsAddress()
        {
            var id = "31588e97-5c6b-48dd-89a1-edd92deb3ccc";
            var path = $"{BaseUri}/{id}";
            var result = await _client.DeleteAsync(path);
            var content = await result.Content.ReadAsStringAsync();
            var address = JsonConvert.DeserializeObject<AddressDto>(content);
            
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal(id, address.Id);
        }

        #endregion
    }
}