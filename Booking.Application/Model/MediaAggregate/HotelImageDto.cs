using Booking.Domain.Entities.HotelAggregate;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Model.MediaAggregate
{
    public class HotelImageDto
    {
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public string PublicId { get; set; }
        public string Url { get; set; }
    }
}
