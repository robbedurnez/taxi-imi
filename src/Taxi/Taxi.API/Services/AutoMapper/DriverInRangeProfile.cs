using AutoMapper;
using Taxi.Domain.DTO;

namespace Taxi.API.Services.AutoMapper
{
    public class DriverInRangeProfile : Profile
    {
        public DriverInRangeProfile()
        {
            CreateMap<DriverDto, DriverInRangeDto>();
        }
    }
}