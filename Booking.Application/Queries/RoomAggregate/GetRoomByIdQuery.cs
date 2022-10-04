using Booking.Application.Model.MediaAggregate;
using Booking.Application.Model.RoomAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Application.Queries.RoomAggregate
{
    public class GetRoomByIdQuery : IRequest<RoomDto>
    {
        public int Id { get; set; }
    }
}
