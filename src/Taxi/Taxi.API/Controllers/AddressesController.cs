using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taxi.API.Controllers.Base;
using Taxi.Domain.DTO;
using Taxi.Domain.Interfaces;
using Taxi.Domain.Models;

namespace Taxi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerDtoCrudBase<AddressDto, IMappingRepository<AddressDto>>
    {
        public AddressesController(IRepository<Address> addressRepository,
            IMappingRepository<AddressDto> addressMappingRepository) : base(addressMappingRepository)
        {
        }

        [HttpGet("GetByUserId/{id}")]
        public async Task<IActionResult> GetByUserId(string id)
        {
            var addresses = await _mappingRepository.ListFiltered(a => a.UserId == id);

            return !addresses.Any()
                ? (IActionResult) NotFound($"No addresses found for user with id {id}")
                : Ok(addresses);
        }
    }
}