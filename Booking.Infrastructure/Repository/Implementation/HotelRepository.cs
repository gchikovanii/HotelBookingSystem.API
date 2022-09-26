using Booking.Domain.Entities.HotelAggregate;
using Booking.Infrastructure.Context;
using Booking.Infrastructure.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Infrastructure.Repository.Implementation
{
    public class HotelRepository : Repository<Hotel> , IHotelRepository
    {
        public HotelRepository(ApplicationDbContext context): base(context)
        {
        }
    }
}
