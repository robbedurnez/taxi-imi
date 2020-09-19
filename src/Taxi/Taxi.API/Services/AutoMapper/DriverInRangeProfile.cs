using AutoMapper;
using Taxi.Domain.DTO;

namespace Taxi.API.Services.AutoMapper
{
    public class DriverInRangeProfile : Profile
    {
        public DriverInRangeProfile()
        {
            CreateMap<DriverDto, DriverInRangeDto>()
                .ForMember(d => d.DriverId, opt => opt.MapFrom(dir => dir.Id))
                .ReverseMap();
        }
    }
}