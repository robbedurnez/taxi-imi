using System.Threading.Tasks;
using Taxi.MobileApp.Models;

namespace Taxi.MobileApp.Contracts
{
    public interface IOrdersService
    {
        public Task<Order> Get(string id);
        public Task<Order> PlaceOrder(Order order);
        public Task<Order> AcceptOrder(Order order);
        public Task<Order> RefuseOrder(Order order);
        public Task<Order> FinalizeOrder(Order order);
    }
}