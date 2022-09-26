using Booking.Application.Commands.OrderAggregate;
using Booking.Application.Model.OrdersAggregate;
using Booking.Application.Queries.OrderAggregate;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Threading.Tasks;

namespace Booking.API.Controllers
{
    public class OrdersController : BaseController
    {
        private readonly IMediator _mediator;
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _mediator.Send(new GetOrdersQuery());
            return Ok(orders);
        }
        [HttpGet(nameof(GetOrdersByRoomId))]
        public async Task<IActionResult> GetOrdersByRoomId([FromQuery] GetOrdersByRoomIdQuery input)
        {
            return Ok(await _mediator.Send(input));
        }

        [HttpPost]
        public async Task<IActionResult> MakeOrder(MakeOrderCommand input)
        {
            var result = await _mediator.Send(input);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrder(UpdateOrderCommand input)
        {
            var result = await _mediator.Send(input);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(DeleteOrderCommand input)
        {
            var result = await _mediator.Send(input);
            return Ok(result);
        }
    }
}
