using AutoMapper;
using Taxi.Domain.DTO;
using Taxi.Domain.Models;

namespace Taxi.API.Services.AutoMapper
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