using AutoMapper;
using Taxi.Domain.DTO;
using Taxi.Domain.Models;

namespace Taxi.API.Services.AutoMapper
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>()
                .ReverseMap();
        }
    }
}