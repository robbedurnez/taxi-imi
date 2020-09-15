using AutoMapper;
using Taxi.Domain.DTO;
using Taxi.Domain.Models;

namespace Taxi.API.Services.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, UserDto>()
                .ReverseMap();
        }
    }
}