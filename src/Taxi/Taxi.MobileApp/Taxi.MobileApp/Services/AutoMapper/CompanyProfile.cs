using AutoMapper;
using Taxi.Domain.DTO;
using Taxi.MobileApp.Models;

namespace Taxi.MobileApp.Services.AutoMapper
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