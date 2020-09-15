using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Taxi.API.Controllers.Base;
using Taxi.API.Hubs;
using Taxi.Domain.Constants;
using Taxi.Domain.DTO;
using Taxi.Domain.Interfaces;
using Taxi.Domain.Models;

namespace Taxi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerDtoCrudBase<OrderDto, IMappingRepository<OrderDto>>
    {
        private readonly IHubContext<TaxiHub> _hub;
        public OrdersController(IMappingRepository<OrderDto> orderMappingRepository, IHubContext<TaxiHub> hub) : base(orderMappingRepository)
        {
            _hub = hub;
        }

        [HttpGet("GetByCompanyId/{id}")]
        public async Task<IActionResult> GetByCompanyId(string id)
        {
            var orders = await _mappingRepository.ListFiltered(o => o.CompanyId == id);

            if (orders == null)
            {
                return NotFound($"No orders found for company with id {id}");
            }

            return Ok(orders);
        }

        [HttpPost("TryPlaceOrder")]
        public async Task<IActionResult> TryPlaceOrder([FromBody] OrderDto model)
        {
            model.State = OrderState.Requested;
            var order = await _mappingRepository.Add(model);
            await _hub.Clients.All.SendAsync(SignalRMessages.OrderRequested, model);
            
            return CreatedAtAction("Get", new { id = order.Id }, order);
        }

        [HttpPut("AcceptOrder")]
        public async Task<IActionResult> AcceptOrder([FromBody] string id)
        {
            var order = await _mappingRepository.GetById(id);

            if (order == null)
            {
                return NotFound($"Order with id {id} could not be found");
            }

            if (order.State != OrderState.Requested)
            {
                return BadRequest($"Order with id {id} has already been handled");
            }

            order.State = OrderState.Handled;
            
            var updatedOrder = await _mappingRepository.Update(order);
            await _hub.Clients.All.SendAsync(SignalRMessages.OrderAccepted, updatedOrder);
            
            return Ok(updatedOrder);
        }

        [HttpPut("RefuseOrder")]
        public async Task<IActionResult> RefuseOrder([FromBody] string id)
        {
            var order = await _mappingRepository.GetById(id);

            if (order == null)
            {
                return NotFound($"Order with id {id} could not be found");
            }
            
            if (order.State != OrderState.Requested)
            {
                return BadRequest($"Order with id {id} has already been handled");
            }

            order.State = OrderState.Refused;
            
            var result = await _mappingRepository.Update(order);
            
            await _hub.Clients.All.SendAsync(SignalRMessages.OrderRefused, result);
            
            return Ok(result);
        }

        [HttpPut("FinalizeOrder")]
        public async Task<IActionResult> FinalizeOrder([FromBody] string id)
        {
            var order = await _mappingRepository.GetById(id);

            if (order == null)
            {
                return NotFound($"Order with id {id} could not be found");
            }
            
            if (order.State != OrderState.Handled)
            {
                return BadRequest($"Order with id {id} has already been handled");
            }

            order.State = OrderState.Finalized;

            var result = await _mappingRepository.Update(order);

            await _hub.Clients.All.SendAsync(SignalRMessages.OrderFinalized, result);

            return Ok(result);
        }
    }
}