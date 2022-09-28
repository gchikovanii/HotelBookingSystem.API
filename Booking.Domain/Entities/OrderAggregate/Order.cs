using Booking.Domain.Entities.Base;
using Booking.Domain.Entities.RoomAggregate;
using Booking.Domain.Entities.UserAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Domain.Entities.OrderAggregate
{
    public class Order : Entity
    {
        public DateTimeOffset CheckIn { get; set; }
        public DateTimeOffset CheckOut { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
