using System;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Taxi.Domain.Constants;
using Taxi.Domain.DTO;
using Taxi.MobileApp.Contracts;
using Taxi.MobileApp.Models;

namespace Taxi.MobileApp.Services.Api
{
    public class ApiOrdersService : IOrdersService
    {
        private readonly string _baseUri = $"{Connection.ApiHome}/api/orders";
        private readonly IMapper _mapper;

        public ApiOrdersService()
        {
            _mapper = App.CreateMapper();
        }

        public async Task<Order> Get(string id)
        {
            var path = $"{_baseUri}/{id}";

            try
            {
                var result = await WebApiClient.GetApiResult<OrderDto>(path);

                return result == null ? null : _mapper.Map<Order>(result);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<Order> PlaceOrder(Order order)
        {
            var path = $"{_baseUri}/TryPlaceOrder";
            var dto = _mapper.Map<OrderDto>(order);

            try
            {
                var result = await WebApiClient.PostCallApi<OrderDto, OrderDto>(path, dto);

                return result == null ? null : _mapper.Map<Order>(result);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<Order> AcceptOrder(Order order)
        {
            var path = $"{_baseUri}/AcceptOrder";
            var id = order.Id;

            try
            {
                var result = await WebApiClient.PutCallApi<OrderDto, string>(path, id);

                return result == null ? null : _mapper.Map<Order>(result);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<Order> RefuseOrder(Order order)
        {
            var path = $"{_baseUri}/RefuseOrder";
            var id = order.Id;

            try
            {
                var result = await WebApiClient.PutCallApi<OrderDto, string>(path, id);

                return result == null ? null : _mapper.Map<Order>(result);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<Order> FinalizeOrder(Order order)
        {
            var path = $"{_baseUri}/FinalizeOrder";
            var id = order.Id;

            try
            {
                var result = await WebApiClient.PutCallApi<OrderDto, string>(path, id);

                return result == null ? null : _mapper.Map<Order>(result);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}