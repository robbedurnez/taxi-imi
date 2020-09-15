using AutoMapper;
using Taxi.API.Data;
using Taxi.API.Repositories.Base;
using Taxi.Domain.DTO;
using Taxi.Domain.Models;

namespace Taxi.API.Repositories
{
    public class DriversRepository : MappingRepository<Driver, DriverDto>
    {
        public DriversRepository(TaxiContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}