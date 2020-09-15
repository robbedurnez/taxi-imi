using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Taxi.Domain.DTO;

namespace Taxi.API.Hubs
{
    public class TaxiHub : Hub
    {
        public async Task SendLocation(DriverInRangeDto dto)
        {
            await Clients.All.SendAsync("ReceiveLocation", dto);
        }
    }
}