using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Commands.MediaAggregate
{
    public class UploadHotelImagesCommand : IRequest<bool>
    {
        public int HotelId { get; set; }
        public IFormFile File { get; set; }
    }
}
