using Booking.Application.Model.RoomAggregate;
using Booking.Domain.Entities.RoomAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Application.Queries.RoomAggregate
{
    public class GetRoomsQuery : IRequest<List<RoomDto>>
    {
    }
}
