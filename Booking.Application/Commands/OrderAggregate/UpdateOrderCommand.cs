using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Application.Commands.OrderAggregate
{
    public class UpdateOrderCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public DateTimeOffset CheckIn { get; set; }
        public DateTimeOffset CheckOut { get; set; }
        public int RoomId { get; set; }
    }
}
