using AutoMapper;
using Taxi.Domain.DTO;
using Taxi.Domain.Models;

namespace Taxi.API.Services.AutoMapper
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyDto>()
                .ReverseMap();
        }
    }
}