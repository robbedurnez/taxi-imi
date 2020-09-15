using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Taxi.API.Controllers.Base;
using Taxi.API.Hubs;
using Taxi.Domain.Constants;
using Taxi.Domain.DTO;
using Taxi.Domain.Interfaces;
using Xamarin.Essentials;
// ReSharper disable CompareOfFloatsByEqualityOperator

namespace Taxi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerDtoCrudBase<DriverDto, IMappingRepository<DriverDto>>
    {
        private readonly IHubContext<TaxiHub> _hub;
        private readonly IMapper _mapper;
        
        public DriversController(IMappingRepository<DriverDto> driverMappingRepository, IMapper mapper, IHubContext<TaxiHub> hub) : base(driverMappingRepository)
        {
            _hub = hub;
            _mapper = mapper;
        }
        
        [HttpGet("GetByCompanyId/{id}")]
        public async Task<IActionResult> GetByCompanyId(string id)
        {
            var drivers = await _mappingRepository.ListFiltered(o => o.CompanyId == id);

            if (drivers == null)
            {
                return NotFound($"No drivers found for company with id {id}");
            }

            return Ok(drivers);
        }

        [HttpPost("GetInRange")]
        public async Task<IActionResult> GetInRange([FromBody] DriverInRangeDto model)
        {
            var availableDrivers = await _mappingRepository
                .GetFiltered(d => d.IsActive)
                .ToListAsync();

            if (availableDrivers == null)
            {
                return BadRequest("No drivers found");
            }
            
            if (model.Latitude == 0 || model.Longitude == 0)
            {
                return BadRequest("Invalid model");
            }

            var customerLocation = new Location()
            {
                Latitude = model.Latitude,
                Longitude = model.Longitude
            };
            
            var driverDtos = availableDrivers.Where(d =>
            {
                var driverLocation = new Location()
                {
                    Latitude = d.Latitude,
                    Longitude = d.Longitude
                };

                var distance = customerLocation.CalculateDistance(driverLocation, DistanceUnits.Kilometers);

                return distance <= model.MaxDistanceInKm;
            }).ToList();

            return Ok(driverDtos);
        }

        [HttpPut("ToggleActive")]
        public async Task<IActionResult> ToggleActive([FromBody] DriverDto model)
        {
            var driver = await _mappingRepository.GetById(model.Id);
            
            if (driver == null)
            {
                return BadRequest($"Driver with id {model.Id} not found");
            }

            driver.IsActive = !driver.IsActive;
            driver.IsAvailable = driver.IsActive;
            driver.Latitude = model.Latitude;
            driver.Longitude = model.Longitude;
            
            var updatedDriver = await _mappingRepository.Update(driver);
            var dto = _mapper.Map<DriverInRangeDto>(updatedDriver);

            if (updatedDriver.IsActive)
            {
                await _hub.Clients.All.SendAsync(SignalRMessages.GetDriverLocation, dto);
            }
            else
            {
                await _hub.Clients.All.SendAsync(SignalRMessages.RemoveDriverLocation, dto);
            }
            
            return Ok(updatedDriver);
        }
        
        [HttpPut("ToggleAvailable")]
        public async Task<IActionResult> ToggleAvailable([FromBody] DriverDto model)
        {
            var driver = await _mappingRepository.GetById(model.Id);
            
            if (driver == null)
            {
                return BadRequest($"Driver with id {model.Id} not found");
            }

            driver.IsAvailable = !driver.IsAvailable;
            
            var updatedDriver = await _mappingRepository.Update(driver);
            var dto = _mapper.Map<DriverInRangeDto>(updatedDriver);

            await _hub.Clients.All.SendAsync(SignalRMessages.UpdateDriverLocation, dto);
            
            return Ok(updatedDriver);
        }

        [HttpPut("UpdateLocation")]
        public async Task<IActionResult> UpdateLocation([FromBody] DriverDto model)
        {
            if (model.Latitude == 0 || model.Longitude == 0)
            {
                return BadRequest("Invalid model");
            } 
            
            var driver = await _mappingRepository.GetById(model.Id);

            if (driver == null)
            {
                return BadRequest($"Driver with id {model.Id} not found");
            }

            driver.Latitude = model.Latitude;
            driver.Longitude = model.Longitude;
            
            var updatedDriver = await _mappingRepository.Update(driver);
            var dto = _mapper.Map<DriverInRangeDto>(updatedDriver);

            if (updatedDriver.IsActive)
            {
                await _hub.Clients.All.SendAsync(SignalRMessages.UpdateDriverLocation, dto);
            }

            return Ok(updatedDriver);
        }
    }
}