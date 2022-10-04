using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Commands.MediaAggregate.HotelAggregate
{
    public class DeleteHotelImageCommand : IRequest<bool>
    {
        public int HotelImageId { get; set; }
    }
}
