using System.Collections.Generic;
using System.Threading.Tasks;
using Taxi.MobileApp.Models;

namespace Taxi.MobileApp.Contracts
{
    public interface IDriversService
    {
        public Task<List<Driver>> Get();
        public Task<List<Driver>> GetInRange(double latitude, double longitude, int km);
        public Task<Driver> GetById(string id);
        public Task<Driver> ToggleActive(Driver driver);
        public Task<Driver> ToggleAvailable(Driver driver);
        public Task<Driver> UpdateLocation(Driver driver);
    }
}