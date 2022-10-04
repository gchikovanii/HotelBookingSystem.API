using Booking.Application.Commands.MediaAggregate.HotelAggregate;
using Booking.Application.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpPost(nameof(UploadHotelImage))]
        public async Task<IActionResult> UploadHotelImage([FromForm]UploadHotelImageCommand input)
        {
            try
            {
                var result = await _mediator.Send(input);
                return Ok(result);
            }
            catch (ImageNotUplaodedException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost(nameof(UplaodRoomImage))]
        public async Task<IActionResult> UplaodRoomImage([FromForm]UploadHotelImageCommand input)
        {
            try
            {
                var result = await _mediator.Send(input);
                return Ok(result);
            }
            catch (ImageNotUplaodedException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete(nameof(DeleteHotelImage))]
        public async Task<IActionResult> DeleteHotelImage(DeleteHotelImageCommand input)
        {
            try
            {
                var result = await _mediator.Send(input);
                return Ok(result);
            }
            catch (ImageNotDeletedException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete(nameof(DeletRoomImage))]
        public async Task<IActionResult> DeletRoomImage(DeleteHotelImageCommand input)
        {
            try
            {
                var result = await _mediator.Send(input);
                return Ok(result);
            }
            catch (ImageNotDeletedException ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
