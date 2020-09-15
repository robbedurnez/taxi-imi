using System.Threading.Tasks;
using Taxi.MobileApp.Models;

namespace Taxi.MobileApp.Contracts
{
    public interface ICompaniesService
    {
        public Task<Company> Get(string id);
    }
}