using Booking.Application.Commands.RoomAggregate;
using Booking.Application.Queries.RoomAggregate;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Booking.API.Controllers
{
    public class RoomController : BaseController
    {
        private readonly IMediator _mediator;
        public RoomController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetRooms()
        {
            var rooms = await _mediator.Send(new GetRoomByIdQuery());
            return Ok(rooms);
        }

        [HttpGet(nameof(GetRoom))]
        public async Task<IActionResult> GetRoom([FromQuery] GetRoomByIdQuery input)
        {
            var room = await _mediator.Send(input);
            return Ok(room);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom([FromBody] CreateRoomCommand input)
        {
            var result = await _mediator.Send(input);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateRoom([FromForm]UpdateRoomCommand input)
        {
            var result = await _mediator.Send(input);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteRoom(DeleteRoomCommand input)
        {
            var result = await _mediator.Send(input);
            return Ok(result);
        }


    }
}
