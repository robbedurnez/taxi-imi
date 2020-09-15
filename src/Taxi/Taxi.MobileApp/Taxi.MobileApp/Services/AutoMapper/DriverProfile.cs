using AutoMapper;
using Taxi.Domain.DTO;
using Taxi.MobileApp.Models;

namespace Taxi.MobileApp.Services.AutoMapper
{
    public class DriverProfile : Profile
    {
        public DriverProfile()
        {
            CreateMap<Driver, DriverDto>()
                .ReverseMap();
        }
    }
}