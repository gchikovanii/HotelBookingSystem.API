using Booking.Application.Commands.MediaAggregate;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Booking.API.Controllers
{
    public class MediaController : BaseController
    {
        private readonly IMediator _mediator;
        public MediaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> UploadHotelImage([FromForm]UploadHotelImagesCommand input)
        {
            var result = await _mediator.Send(input);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteHotelImage(DeleteHotelImageCommand input)
        {
            var result = await _mediator.Send(input);
            return Ok(result);
        }

    }
}
