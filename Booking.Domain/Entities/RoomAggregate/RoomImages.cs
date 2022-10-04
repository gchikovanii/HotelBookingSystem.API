using Booking.Domain.Entities.Base;
using Booking.Domain.Entities.HotelAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Entities.RoomAggregate
{
    public class RoomImages : Entity
    {
        public string PublicId { get; set; }
        public string Url { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
