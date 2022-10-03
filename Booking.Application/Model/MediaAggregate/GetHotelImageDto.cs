using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Model.MediaAggregate
{
    public class GetHotelImageDto
    {
        public string PublicId { get; set; }
        public string Url { get; set; }
    }
}
