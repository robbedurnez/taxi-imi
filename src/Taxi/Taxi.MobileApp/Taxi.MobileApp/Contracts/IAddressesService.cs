using System.Collections.Generic;
using System.Threading.Tasks;
using Taxi.MobileApp.Models;

namespace Taxi.MobileApp.Contracts
{
    public interface IAddressesService
    {
        Task<Address> GetAddress(string id);
        Task<Address> UpdateAddress(Address address);
        Task<List<Address>> GetByUserId(string id);
        Task<Address> DeleteAddress(string id);
        Task<Address> Add(Address address);
    }
}
