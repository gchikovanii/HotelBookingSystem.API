using Booking.Domain.Entities.Base;
using Booking.Domain.Entities.Constant;
using Booking.Domain.Entities.HotelAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Domain.Entities.RoomAggregate
{
    public class NumberOfRoomsByTypes : Entity
    {
        public int NumberOfRooms { get; set; }
        public RoomType RoomType { get; set; }
        public BedType BedType { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

    }
}
