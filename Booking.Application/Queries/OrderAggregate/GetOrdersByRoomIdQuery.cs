using Booking.Application.Model.OrdersAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Application.Queries.OrderAggregate
{
    public class GetOrdersByRoomIdQuery : IRequest<List<OrderDto>>
    {
        public int RoomId { get; set; }
    }
}
