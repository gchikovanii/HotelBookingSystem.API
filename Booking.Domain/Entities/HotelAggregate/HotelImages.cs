using Booking.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Entities.HotelAggregate
{
    public class HotelImages : Entity
    {
        public string PublicId { get; set; }
        public string Url { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
