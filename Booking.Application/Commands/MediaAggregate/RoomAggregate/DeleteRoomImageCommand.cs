using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Commands.MediaAggregate.RoomAggregate
{
    public class DeleteRoomImageCommand : IRequest<bool>
    {
        public int RoomImageId { get; set; }
    }
}
