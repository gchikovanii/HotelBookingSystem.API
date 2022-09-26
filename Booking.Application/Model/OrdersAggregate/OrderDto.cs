using Booking.Domain.Entities.RoomAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Application.Model.OrdersAggregate
{
    public class OrderDto
    {
        public DateTimeOffset CheckIn { get; set; }
        public DateTimeOffset CheckOut { get; set; }
        public int RoomId { get; set; }
    }
}
