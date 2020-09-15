using AutoMapper;
using Taxi.Domain.DTO;
using Taxi.Domain.Models;

namespace Taxi.API.Services.AutoMapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>()
                .ReverseMap();
        }
    }
}