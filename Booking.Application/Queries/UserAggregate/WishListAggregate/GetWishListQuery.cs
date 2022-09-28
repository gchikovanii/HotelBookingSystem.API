using Booking.Application.Model.HotelAggregate;
using Booking.Domain.Entities.HotelAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Queries.UserAggregate.WishListAggregate
{
    public class GetWishListQuery : IRequest<List<HotelDto>>
    {
        public int UserId { get; set; }
    }
}
