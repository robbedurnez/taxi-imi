using Microsoft.AspNetCore.Mvc;
using Taxi.API.Controllers.Base;
using Taxi.Domain.DTO;
using Taxi.Domain.Interfaces;

namespace Taxi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerDtoCrudBase<CustomerDto, IMappingRepository<CustomerDto>>
    {
        public CustomersController(IMappingRepository<CustomerDto> customerMappingRepository) : base(customerMappingRepository)
        {
        }
    }
}