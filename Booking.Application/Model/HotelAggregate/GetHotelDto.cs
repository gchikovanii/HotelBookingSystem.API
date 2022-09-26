using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Application.Model.HotelAggregate
{
    public class GetHotelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double MaxPrice { get; set; }
        public double MinPrice { get; set; }
        public string Longtitude { get; set; }
        public string Latitude { get; set; }
    }
}
