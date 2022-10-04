using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Filters
{
    public class ImageNotUplaodedException : Exception
    {
        public ImageNotUplaodedException(string message): base(message)
        {
        }
    }
}
