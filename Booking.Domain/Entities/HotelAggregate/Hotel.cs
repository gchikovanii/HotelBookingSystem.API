using Booking.Domain.Entities.Base;
using Booking.Domain.Entities.RoomAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Domain.Entities.HotelAggregate
{
    public class Hotel : Entity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double MaxPrice { get; set; }
        public double MinPrice { get; set; }
        public string Longtitude { get; set; }
        public string Latitude { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public ICollection<NumberOfRoomsByTypes> NumberOfRooms { get; set; }

    }
}
