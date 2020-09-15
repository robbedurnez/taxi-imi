using System;
using System.Collections.Generic;
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
    public class DriversControllerTest : IClassFixture<TestingApiFactory<Startup>>
    {
        private readonly HttpClient _client;
        private const string BaseUri = "http://localhost:5000/api/drivers";

        public DriversControllerTest(TestingApiFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        #region GET

        [Fact]
        public async void Get_Get_ValidId_ReturnsOk_ReturnsDriver()
        {
            var id = "00000000-0000-0000-0000-000000000002";
            var path = $"{BaseUri}/{id}";

            var response = await _client.GetAsync(path);
            var content = await response.Content.ReadAsStringAsync();
            var driver = JsonConvert.DeserializeObject<DriverDto>(content);
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(driver.Id, id);
        }
        
        [Fact]
        public async void Get_Get_InvalidId_ReturnsNotFound()
        {
            var id = "00000000-0000-0000-0000-000000000009";
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
            var dto = new DriverDto()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Driver5",
                Email = "driver5@taxi.com",
                LastName = "Taxi",
                CompanyId = "00000000-0000-0000-0000-000000000004",
                PhoneNumber = "0497635255",
                UserType = UserType.Driver
            };
            var json = JsonConvert.SerializeObject(dto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(path, body);
            var content = await response.Content.ReadAsStringAsync();
            var driver = JsonConvert.DeserializeObject<DriverDto>(content);
            
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(dto.Id, driver.Id);
        }
        
        [Fact]
        public async void Post_Add_InvalidModel_ReturnsBadRequest()
        {
            var path = "http://localhost:5000/api/drivers";
            var dto = new DriverDto()
            {
                Id = Guid.NewGuid().ToString(),
                Email = "driver3@taxi.com",
                LastName = "Taxi",
                PhoneNumber = "0497635255",
                UserType = UserType.Driver
            };
            var json = JsonConvert.SerializeObject(dto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(path, body);
            var content = await response.Content.ReadAsStringAsync();
            
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async void Post_GetInRange_ValidModel_ReturnsDrivers()
        {
            var path = $"{BaseUri}/GetInRange";
            var dto = new DriverInRangeDto()
            {
                Latitude = 51.0862,
                Longitude = 2.9764,
                DriverId = "00000000-0000-0000-0000-000000000002",
                MaxDistanceInKm = 10
            };
            var json = JsonConvert.SerializeObject(dto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(path, body);
            var content = await response.Content.ReadAsStringAsync();
            var drivers = JsonConvert.DeserializeObject<List<DriverDto>>(content);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(2, drivers.Count);
        }

        [Fact]
        public async void Post_GetInRange_InvalidModel_ReturnsBadRequest()
        {
            var path = $"{BaseUri}/GetInRange";
            var dto = new DriverInRangeDto()
            {
                Latitude = 51.0862,
                DriverId = "00000000-0000-0000-0000-000000000002",
                MaxDistanceInKm = 10
            };
            var json = JsonConvert.SerializeObject(dto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(path, body);
            var content = await response.Content.ReadAsStringAsync();
        
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("Invalid model", content);
        }

        #endregion

        #region PUT

        [Fact]
        public async void Put_Put_IdsDontMatch_ReturnsBadRequest()
        {
            var id = "00000000-0000-0000-0000-000000000045";
            var path = $"{BaseUri}/{id}";
            var dto = new DriverDto()
            {
                Id = "00000000-0000-0000-0000-000000000002",
                FirstName = "Driver3",
                Email = "driver3@taxi.com",
                LastName = "Taxi",
                CompanyId = "00000000-0000-0000-0000-000000000004",
                PhoneNumber = "0497635255",
                UserType = UserType.Driver
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
            var id = "00000000-0000-0000-0000-000000000002";
            var path = $"{BaseUri}/{id}";
            var dto = new DriverDto()
            {
                Id = id,
                FirstName = "Driver1",
                Email = "driver1@taxi.com",
                LastName = "Taxi",
                UserType = UserType.Driver
            };
            var json = JsonConvert.SerializeObject(dto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync(path, body);
            var responseString = await response.Content.ReadAsStringAsync();
            
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async void Put_Put_ValidModel_ReturnsOk_ReturnsDriver()
        {
            var id = "00000000-0000-0000-0000-000000000002";
            var path = $"{BaseUri}/{id}";
            var dto = new DriverDto()
            {
                Id = "00000000-0000-0000-0000-000000000002",
                FirstName = "Driver1",
                Email = "driver1@taxi.com",
                LastName = "Taxi",
                CompanyId = "00000000-0000-0000-0000-000000000004",
                PhoneNumber = "0497635255",
                UserType = UserType.Driver
            };
            var json = JsonConvert.SerializeObject(dto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync(path, body);
            var content = await response.Content.ReadAsStringAsync();
            var driver = JsonConvert.DeserializeObject<DriverDto>(content);
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(dto.Id, driver.Id);
        }

        [Fact]
        public async void Put_UpdateLocation_InvalidModel_ReturnsBadRequest()
        {
            var path = $"{BaseUri}/UpdateLocation";
            var dto = new DriverDto()
            {
                Id = "00000000-0000-0000-0000-000000000002",
                FirstName = "Driver1",
                LastName = "Taxi",
                Email = "driver1@taxi.com",
                PhoneNumber = "0498765432",
                CompanyId = "00000000-0000-0000-0000-00000000005",
                Latitude = 5
            };

            var json = JsonConvert.SerializeObject(dto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await _client.PutAsync(path, body);
            var content = await result.Content.ReadAsStringAsync();
            
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
            Assert.Equal("Invalid model", content);
        }
        
        [Fact]
        public async void Put_UpdateLocation_ValidModel_ReturnsOk_ReturnsDriver()
        {
            var path = $"{BaseUri}/UpdateLocation";
            var dto = new DriverDto()
            {
                Id = "00000000-0000-0000-0000-000000000002",
                FirstName = "Driver1",
                LastName = "Taxi",
                Email = "driver1@taxi.com",
                PhoneNumber = "0498765432",
                CompanyId = "00000000-0000-0000-0000-00000000005",
                Latitude = 50,
                Longitude = 5
            };

            var json = JsonConvert.SerializeObject(dto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await _client.PutAsync(path, body);
            var content = await result.Content.ReadAsStringAsync();
            var driver = JsonConvert.DeserializeObject<DriverDto>(content);
            
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal(dto.Id, driver.Id);
        }

        [Fact]
        public async void Put_ToggleActive_ValidModel_ReturnsOk_ReturnsDriver()
        {
            var path = $"{BaseUri}/ToggleActive";
            var dto = new DriverDto()
            {
                Id = "00000000-0000-0000-0000-000000000003",
                CompanyId = "00000000-0000-0000-0000-00000000004",
                Latitude = 51.08374,
                Longitude = 2.97635
            };
            var json = JsonConvert.SerializeObject(dto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await _client.PutAsync(path, body);
            var content = await response.Content.ReadAsStringAsync();
            var driver = JsonConvert.DeserializeObject<DriverDto>(content);
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.False(driver.IsActive);
        }

        [Fact]
        public async void Put_ToggleActive_InvalidDriverId_ReturnsBadRequest()
        {
            var path = $"{BaseUri}/ToggleActive";
            var dto = new DriverDto()
            {
                Id = "00000000-0000-0000-0000-00000000012",
                CompanyId = "00000000-0000-0000-0000-00000000005",
                Latitude = 51.08619,
                Longitude = 2.97639
            };
            var json = JsonConvert.SerializeObject(dto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await _client.PutAsync(path, body);
            var content = await response.Content.ReadAsStringAsync();
            
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal($"Driver with id {dto.Id} not found", content);
        }
        
        [Fact]
        public async void Put_ToggleActive_InvalidModel_ReturnsBadRequest()
        {
            var path = $"{BaseUri}/ToggleActive";
            var dto = new DriverDto()
            {
                Id = "00000000-0000-0000-0000-00000000002",
                Latitude = 51.08619,
                Longitude = 2.97639
            };
            var json = JsonConvert.SerializeObject(dto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await _client.PutAsync(path, body);
            
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async void Put_ToggleAvailable_ValidModel_ReturnsOk_ReturnsDriver()
        {
            var path = $"{BaseUri}/ToggleAvailable";
            var dto = new DriverDto()
            {
                Id = "00000000-0000-0000-0000-000000000003",
                CompanyId = "00000000-0000-0000-0000-00000000004",
                Latitude = 51.08374,
                Longitude = 2.97635
            };
            var json = JsonConvert.SerializeObject(dto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await _client.PutAsync(path, body);
            var content = await response.Content.ReadAsStringAsync();
            var driver = JsonConvert.DeserializeObject<DriverDto>(content);
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(driver.IsAvailable);
        }

        [Fact]
        public async void Put_ToggleAvailable_InvalidDriverId_ReturnsBadRequest()
        {
            var path = $"{BaseUri}/ToggleAvailable";
            var dto = new DriverDto()
            {
                Id = "00000000-0000-0000-0000-00000000012",
                CompanyId = "00000000-0000-0000-0000-00000000005",
                Latitude = 51.08619,
                Longitude = 2.97639
            };
            var json = JsonConvert.SerializeObject(dto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await _client.PutAsync(path, body);
            var content = await response.Content.ReadAsStringAsync();
            
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal($"Driver with id {dto.Id} not found", content);
        }
        
        [Fact]
        public async void Put_ToggleAvailable_InvalidModel_ReturnsBadRequest()
        {
            var path = $"{BaseUri}/ToggleAvailable";
            var dto = new DriverDto()
            {
                Id = "00000000-0000-0000-0000-00000000002",
                Latitude = 51.08619,
                Longitude = 2.97639
            };
            var json = JsonConvert.SerializeObject(dto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await _client.PutAsync(path, body);
            
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
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
        public async void Delete_Delete_ValidId_ReturnsOk_ReturnsDriver()
        {
            var id = "00000000-0000-0000-0000-000000000002";
            var path = $"{BaseUri}/{id}";
            var result = await _client.DeleteAsync(path);
            var content = await result.Content.ReadAsStringAsync();
            var driver = JsonConvert.DeserializeObject<DriverDto>(content);
            
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal(id, driver.Id);
        }

        #endregion
    }
}