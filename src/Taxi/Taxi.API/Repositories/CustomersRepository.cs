using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Taxi.API.Data;
using Taxi.API.Repositories.Base;
using Taxi.Domain.DTO;
using Taxi.Domain.Models;

namespace Taxi.API.Repositories
{
    public class CustomersRepository : MappingRepository<Customer, CustomerDto>
    {
        public CustomersRepository(TaxiContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public new async Task<UserDto> GetById(string id)
        {
            return await _taxiContext.Set<Customer>()
                .Include(c => c.Addresses)
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(d => d.Id == id);
        }
    }
}