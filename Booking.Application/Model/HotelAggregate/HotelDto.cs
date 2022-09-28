using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Model.HotelAggregate
{
    public class HotelDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double MaxPrice { get; set; }
        public double MinPrice { get; set; }
        public string Longtitude { get; set; }
        public string Latitude { get; set; }
    }
}
