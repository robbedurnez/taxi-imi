using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi.Domain.Constants;
using Taxi.MobileApp.Contracts;
using Taxi.MobileApp.Models;

namespace Taxi.MobileApp.Services.Mocking
{
    public class MockAddressesService : IAddressesService
    {
        private static List<Address> addresses = new List<Address>()
        {
        };

        public async Task<Address> GetAddress(string id)
        {
            var address = addresses.FirstOrDefault(a => a.Id == id);

            return await Task.FromResult(address);
        }

        public async Task<Address> UpdateAddress(Address updatedAddress)
        {
            await Task.Delay(Mock.FakeDelay);

            var oldAddress = addresses.FirstOrDefault(e => e.Id == updatedAddress.Id);
            addresses.Remove(oldAddress);
            addresses.Add(updatedAddress);
            return await Task.FromResult(updatedAddress);
        }

        public async Task<List<Address>> GetByUserId(string id)
        {
            var result = addresses.Where(a => a.UserId == id).ToList();

            return await Task.FromResult(result);
        }

        public async Task<Address> DeleteAddress(string id)
        {
            var oldAddress = addresses.FirstOrDefault(e => e.Id == id);

            addresses.Remove(oldAddress);

            return await Task.FromResult(oldAddress);
        }

        public async Task<Address> Add(Address address)
        {
            await Task.Delay(Mock.FakeDelay);

            addresses.Add(address);

            return await Task.FromResult(address);
        }
    }
}
