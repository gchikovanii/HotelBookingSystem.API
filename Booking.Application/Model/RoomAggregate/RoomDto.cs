using Booking.Application.Model.MediaAggregate;
using Booking.Domain.Entities.Constant;
using Booking.Domain.Entities.HotelAggregate;
using Booking.Domain.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Application.Model.RoomAggregate
{
    public class RoomDto
    {
        public int Id { get; set; }
        public bool Fridge { get; set; }
        public bool MiniBar { get; set; }
        public bool Sofa { get; set; }
        public bool TV { get; set; }
        public bool AirConditioner { get; set; }
        public bool CoffeMachine { get; set; }
        public bool Balcony { get; set; }
        public BedType BedType { get; set; }
        public RoomType RoomType { get; set; }
        public int NumberOfRooms { get; set; }
        public int HotelId { get; set; }
        public List<RoomImagesDto> Images { get; set; }
    }
}
