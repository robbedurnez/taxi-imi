using Microsoft.AspNetCore.Mvc;
using Taxi.API.Controllers.Base;
using Taxi.Domain.DTO;
using Taxi.Domain.Interfaces;

namespace Taxi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerDtoCrudBase<CompanyDto, IMappingRepository<CompanyDto>>
    {
        public CompaniesController(IMappingRepository<CompanyDto> companyMappingRepository) :
            base(companyMappingRepository)
        {
        }
    }
}