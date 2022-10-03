using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Commands.MediaAggregate
{
    public class DeleteHotelImageCommand : IRequest<bool>
    {
        public int ImageId { get; set; }
        public int HotelId { get; set; }
    }
}
