using System;
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
    public class CompaniesControllerTest : IClassFixture<TestingApiFactory<Startup>>
    {
        private readonly HttpClient _client;
        private const string BaseUri = "http://localhost:5000/api/companies";

        public CompaniesControllerTest(TestingApiFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }
        
        #region GET

        [Fact]
        public async void Get_Get_ValidId_ReturnsOk_ReturnsCompany()
        {
            var id = "00000000-0000-0000-0000-000000000004";
            var path = $"{BaseUri}/{id}";

            var response = await _client.GetAsync(path);
            var content = await response.Content.ReadAsStringAsync();
            var company = JsonConvert.DeserializeObject<CompanyDto>(content);
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(company.Id, id);
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
            var dto = new CompanyDto()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Company2",
                Email = "company2@taxi.com",
                PhoneNumber = "0498767854",
                StartPrice = 5m,
                PricePerKm = 2.5m,
                UserType = UserType.Company
            };
            var json = JsonConvert.SerializeObject(dto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(path, body);
            var content = await response.Content.ReadAsStringAsync();
            var company = JsonConvert.DeserializeObject<CompanyDto>(content);
            
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(dto.Id, company.Id);
        }
        
        [Fact]
        public async void Post_Add_InvalidModel_ReturnsBadRequest()
        {
            var path = $"{BaseUri}";
            var dto = new CompanyDto()
            {
                Id = Guid.NewGuid().ToString(),
                Email = "company2@taxi.com",
                PhoneNumber = "0498767854",
                StartPrice = 5m,
                UserType = UserType.Company
            };
            var json = JsonConvert.SerializeObject(dto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(path, body);
            var content = await response.Content.ReadAsStringAsync();
            
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        #endregion

        #region PUT

        [Fact]
        public async void Put_Put_IdsDontMatch_ReturnsBadRequest()
        {
            var id = "00000000-0000-0000-0000-00000000004";
            var path = $"{BaseUri}/{id}";
            var dto = new CompanyDto()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Company2",
                Email = "company2@taxi.com",
                PhoneNumber = "0498767854",
                StartPrice = 5m,
                PricePerKm = 2.5m,
                UserType = UserType.Company
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
            var id = "00000000-0000-0000-0000-000000000004";
            var path = $"{BaseUri}/{id}";
            var dto = new CompanyDto()
            {
                Id = "00000000-0000-0000-0000-000000000004",
                Email = "company2@taxi.com",
                PhoneNumber = "0498767854",
                StartPrice = 5m,
                PricePerKm = 2.5m
            };
            var json = JsonConvert.SerializeObject(dto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync(path, body);
            
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async void Put_Put_ValidModel_ReturnsOk_ReturnsDriver()
        {
            var id = "00000000-0000-0000-0000-000000000004";
            var path = $"{BaseUri}/{id}";
            var dto = new CompanyDto()
            {
                Id = "00000000-0000-0000-0000-000000000004",
                Name = "Company3",
                Email = "company3@taxi.com",
                PhoneNumber = "0498767854",
                StartPrice = 5m,
                PricePerKm = 2.5m,
                UserType = UserType.Company
            };
            var json = JsonConvert.SerializeObject(dto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync(path, body);
            var content = await response.Content.ReadAsStringAsync();
            var company = JsonConvert.DeserializeObject<CompanyDto>(content);
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(dto.Id, company.Id);
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
            var id = "00000000-0000-0000-0000-000000000010";
            var path = $"{BaseUri}/{id}";
            var result = await _client.DeleteAsync(path);
            var content = await result.Content.ReadAsStringAsync();
            var company = JsonConvert.DeserializeObject<CompanyDto>(content);
            
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal(id, company.Id);
        }

        #endregion
    }
}