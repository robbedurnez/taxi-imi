using AutoMapper;
using Taxi.Domain.DTO;
using Taxi.MobileApp.Models;

namespace Taxi.MobileApp.Services.AutoMapper
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