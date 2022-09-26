using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Application.Commands.RoomAggregate
{
    public class DeleteRoomCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
