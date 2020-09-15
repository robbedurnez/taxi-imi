using AutoMapper;
using Taxi.Domain.DTO;
using Taxi.MobileApp.Models;

namespace Taxi.MobileApp.Services.AutoMapper
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressDto>()
                .ReverseMap();
        }
    }
}