using Booking.Domain.Entities.HotelAggregate;
using Booking.Infrastructure.Context;
using Booking.Infrastructure.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.Repository.Implementation
{
    public class HotelImageRepository : Repository<HotelImages>, IHotelImageRepository
    {
        public HotelImageRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
