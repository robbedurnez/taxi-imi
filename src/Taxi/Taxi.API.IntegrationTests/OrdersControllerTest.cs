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
    public class OrdersControllerTest : IClassFixture<TestingApiFactory<Startup>>
    {
        private readonly HttpClient _client;
        private const string BaseUri = "http://localhost:5000/api/orders";

        public OrdersControllerTest(TestingApiFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        #region GET

        [Fact]
        public async void Get_Get_ValidId_ReturnsOk_ReturnsOrder()
        {
            var id = "00000000-0000-0000-0000-000000000100";
            var path = $"{BaseUri}/{id}";

            var response = await _client.GetAsync(path);
            var content = await response.Content.ReadAsStringAsync();
            var order = JsonConvert.DeserializeObject<OrderDto>(content);
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(id, order.Id);
        }
        
        [Fact]
        public async void Get_Get_InvalidId_ReturnsNotFound()
        {
            var id = "00000000-0000-0000-0000-000000000800";
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
            var dto = new OrderDto()
            {
                Id = "00000000-0000-0000-0000-000000000600",
                DriverId = "00000000-0000-0000-0000-000000000002",
                UserId = "31588e97-5c6b-48dd-89a1-edd92deb3bcb",
                FromId = "31588e97-5c6b-48dd-89a1-edd92deb3bbb",
                ToId = "31588e97-5c6b-48dd-89a1-edd92deb3ccc",
                Date = DateTime.Now
            };
            var json = JsonConvert.SerializeObject(dto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(path, body);
            var content = await response.Content.ReadAsStringAsync();
            var order = JsonConvert.DeserializeObject<OrderDto>(content);
            
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(dto.Id, order.Id);
        }
        
        [Fact]
        public async void Post_Add_InvalidModel_ReturnsBadRequest()
        {
            var path = $"{BaseUri}";
            var dto = new OrderDto()
            {
                Id = "00000000-0000-0000-0000-000000000101",
                UserId = "31588e97-5c6b-48dd-89a1-edd92deb3bcb",
                FromId = "31588e97-5c6b-48dd-89a1-edd92deb3bbb",
                ToId = "31588e97-5c6b-48dd-89a1-edd92deb3ccc",
                Date = DateTime.Now
            };
            var json = JsonConvert.SerializeObject(dto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(path, body);
            
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async void Post_TryPlaceOrder_ValidModel_ReturnsCreated()
        {
            var path = $"{BaseUri}/TryPlaceOrder";
            var dto = new OrderDto()
            {
                Id = "00000000-0000-0000-0000-000000000101",
                DriverId = "00000000-0000-0000-0000-000000000002",
                UserId = "31588e97-5c6b-48dd-89a1-edd92deb3bcb",
                FromId = "31588e97-5c6b-48dd-89a1-edd92deb3bbb",
                ToId = "31588e97-5c6b-48dd-89a1-edd92deb3ccc",
                Date = DateTime.Now
            };
            var json = JsonConvert.SerializeObject(dto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(path, body);
            var content = await response.Content.ReadAsStringAsync();
            var order = JsonConvert.DeserializeObject<OrderDto>(content);
            
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(dto.Id, order.Id);
        }
        
        [Fact]
        public async void Post_TryPlaceOrder_InvalidModel_ReturnsBadRequest()
        {
            var path = $"{BaseUri}/TryPlaceOrder";
            var dto = new OrderDto()
            {
                Id = "00000000-0000-0000-0000-000000000101",
                DriverId = "00000000-0000-0000-0000-000000000002",
                FromId = "31588e97-5c6b-48dd-89a1-edd92deb3bbb",
                ToId = "31588e97-5c6b-48dd-89a1-edd92deb3ccc",
                Date = DateTime.Now
            };
            var json = JsonConvert.SerializeObject(dto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(path, body);
            
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        
        #endregion

        #region PUT

        [Fact]
        public async void Put_Put_ValidModel_ReturnsOk_ReturnsOrder()
        {
            var id = "00000000-0000-0000-0000-000000000100";
            var path = $"{BaseUri}/{id}";
            var dto = new OrderDto()
            {
                Id = id,
                DriverId = "00000000-0000-0000-0000-000000000003",
                UserId = "31588e97-5c6b-48dd-89a1-edd92deb3bcb",
                FromId = "31588e97-5c6b-48dd-89a1-edd92deb3bbb",
                ToId = "31588e97-5c6b-48dd-89a1-edd92deb3ccc",
                Date = DateTime.Now
            };
            var json = JsonConvert.SerializeObject(dto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(path, body);
            var content = await response.Content.ReadAsStringAsync();
            var order = JsonConvert.DeserializeObject<OrderDto>(content);
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(dto.Id, order.Id);
        }

        [Fact]
        public async void Put_Put_IdsNotEqual_ReturnsBadRequest()
        {
            var id = "00000000-0000-0000-0000-000000000100";
            var path = $"{BaseUri}/{id}";
            var dto = new OrderDto()
            {
                Id = "00000000-0000-0000-0000-000000000103",
                DriverId = "00000000-0000-0000-0000-000000000003",
                UserId = "31588e97-5c6b-48dd-89a1-edd92deb3bcb",
                FromId = "31588e97-5c6b-48dd-89a1-edd92deb3bbb",
                ToId = "31588e97-5c6b-48dd-89a1-edd92deb3ccc",
                Date = DateTime.Now
            };
            var json = JsonConvert.SerializeObject(dto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(path, body);
            var content = await response.Content.ReadAsStringAsync();
            
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("No matching ID's", content);
        }
        
        [Fact]
        public async void Put_Put_InvalidModel_ReturnsBadRequest()
        {
            var id = "00000000-0000-0000-0000-000000000100";
            var path = $"{BaseUri}/{id}";
            var dto = new OrderDto()
            {
                Id = id,
                DriverId = "00000000-0000-0000-0000-000000000003",
                UserId = "31588e97-5c6b-48dd-89a1-edd92deb3bcb",
                FromId = "31588e97-5c6b-48dd-89a1-edd92deb3bbb",
                Date = DateTime.Now
            };
            var json = JsonConvert.SerializeObject(dto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(path, body);
            var content = await response.Content.ReadAsStringAsync();
            
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async void Put_AcceptOrder_ValidModel_ReturnsOk()
        {
            var id = "00000000-0000-0000-0000-000000000100";
            var path = $"{BaseUri}/AcceptOrder";
            var json = JsonConvert.SerializeObject(id);
            var body = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await _client.PutAsync(path, body);
            var content = await response.Content.ReadAsStringAsync();
            var order = JsonConvert.DeserializeObject<OrderDto>(content);
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(OrderState.Handled, order.State);
        }
        
        [Fact]
        public async void Put_AcceptOrder_InvalidModel_ReturnsNotFound()
        {
            var id = "00000000-0000-0000-0000-000000000111";
            var path = $"{BaseUri}/AcceptOrder";
            var json = JsonConvert.SerializeObject(id);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(path, body);
            var content = await response.Content.ReadAsStringAsync();
            
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            Assert.Equal($"Order with id {id} could not be found", content);
        }
        
        [Fact]
        public async void Put_AcceptOrder_InvalidOrderState_ReturnsBadRequest()
        {
            var id = "00000000-0000-0000-0000-000000000500";
            var path = $"{BaseUri}/AcceptOrder";
            var json = JsonConvert.SerializeObject(id);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(path, body);
            var content = await response.Content.ReadAsStringAsync();
            
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal($"Order with id {id} has already been handled", content);
        }
        
        [Fact]
        public async void Put_RefuseOrder_ValidModel_ReturnsOk()
        {
            var id = "00000000-0000-0000-0000-000000000100";
            var path = $"{BaseUri}/RefuseOrder";
            var json = JsonConvert.SerializeObject(id);
            var body = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await _client.PutAsync(path, body);
            var content = await response.Content.ReadAsStringAsync();
            var order = JsonConvert.DeserializeObject<OrderDto>(content);
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(OrderState.Refused, order.State);
        }
        
        [Fact]
        public async void Put_RefuseOrder_InvalidModel_ReturnsNotFound()
        {
            var id = "00000000-0000-0000-0000-000000000101";
            var path = $"{BaseUri}/RefuseOrder";
            var json = JsonConvert.SerializeObject(id);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(path, body);
            var content = await response.Content.ReadAsStringAsync();
            
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            Assert.Equal($"Order with id {id} could not be found", content);
        }
        
        [Fact]
        public async void Put_RefuseOrder_InvalidOrderState_ReturnsBadRequest()
        {
            var id = "00000000-0000-0000-0000-000000000500";
            var path = $"{BaseUri}/RefuseOrder";
            var json = JsonConvert.SerializeObject(id);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(path, body);
            var content = await response.Content.ReadAsStringAsync();
            
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal($"Order with id {id} has already been handled", content);
        }
        
        [Fact]
        public async void Put_FinalizeOrder_ValidModel_ReturnsOk()
        {
            var id = "00000000-0000-0000-0000-000000000300";
            var path = $"{BaseUri}/FinalizeOrder";
            var json = JsonConvert.SerializeObject(id);
            var body = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await _client.PutAsync(path, body);
            var content = await response.Content.ReadAsStringAsync();
            var order = JsonConvert.DeserializeObject<OrderDto>(content);
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(OrderState.Finalized, order.State);
        }
        
        [Fact]
        public async void Put_FinalizeOrder_InvalidModel_ReturnsNotFound()
        {
            var id = "00000000-0000-0000-0000-000000000101";
            var path = $"{BaseUri}/FinalizeOrder";
            var json = JsonConvert.SerializeObject(id);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(path, body);
            var content = await response.Content.ReadAsStringAsync();
            
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            Assert.Equal($"Order with id {id} could not be found", content);
        }
        
        [Fact]
        public async void Put_FinalizeOrder_InvalidOrderState_ReturnsBadRequest()
        {
            var id = "00000000-0000-0000-0000-000000000400";
            var path = $"{BaseUri}/FinalizeOrder";
            var json = JsonConvert.SerializeObject(id);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(path, body);
            var content = await response.Content.ReadAsStringAsync();
            
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal($"Order with id {id} has already been handled", content);
        }
        
        #endregion

        #region DELETE

        [Fact]
        public async void Delete_Delete_ValidId_ReturnsOk_ReturnsOrder()
        {
            var id = "00000000-0000-0000-0000-000000000200";
            var path = $"{BaseUri}/{id}";


            var response = await _client.DeleteAsync(path);
            var content = await response.Content.ReadAsStringAsync();
            var order = JsonConvert.DeserializeObject<OrderDto>(content);
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(id, order.Id);
        }
        
        [Fact]
        public async void Delete_Delete_InvalidId_ReturnsNotFound()
        {
            var id = "00000000-0000-0000-0000-000000000201";
            var path = $"{BaseUri}/{id}";


            var response = await _client.DeleteAsync(path);
            var content = await response.Content.ReadAsStringAsync();
            
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            Assert.Equal($"Entity with id {id} was not found!", content);
        }

        #endregion
    }
}