using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Application.Commands.UsersAggreagate.WishListAggregate
{
    public class DeleteWishListCommand : IRequest<bool>
    {
        public int UserId { get; set; }
        public int HotelId { get; set; }
    }
}
