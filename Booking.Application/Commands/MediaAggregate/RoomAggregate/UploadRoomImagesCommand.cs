using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Commands.MediaAggregate.RoomAggregate
{
    public class UploadRoomImagesCommand : IRequest<bool>
    {
        public int RoomId { get; set; }
        public IFormFile File { get; set; }
    }
}
