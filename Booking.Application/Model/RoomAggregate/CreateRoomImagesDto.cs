using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Model.RoomAggregate
{
    public class CreateRoomImagesDto
    {
        public int RoomId { get; set; }
        public IFormFile File { get; set; }
    }
}
