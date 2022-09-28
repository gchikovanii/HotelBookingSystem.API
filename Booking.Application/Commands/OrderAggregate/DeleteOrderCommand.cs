using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Application.Commands.OrderAggregate
{
    public class DeleteOrderCommand : IRequest<bool>
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
    }
}
