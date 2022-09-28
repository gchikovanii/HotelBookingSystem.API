using Booking.Application.Commands.UsersAggreagate.WishListAggregate;
using Booking.Application.Queries.UserAggregate.WishListAggregate;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Booking.API.Controllers
{
    public class WishListController : BaseController
    {
        private readonly IMediator _mediator;
        public WishListController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetWishedHotel([FromQuery] GetWishListQuery input)
        {
            return Ok(await _mediator.Send(input));
        }

        [HttpPost]
        public async Task<IActionResult> AddToWishList(CreateWishListCommand input)
        {
            return Ok(await _mediator.Send(input));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFromWishList(DeleteWishListCommand input)
        {
            return Ok(await _mediator.Send(input));
        }
    }
}
