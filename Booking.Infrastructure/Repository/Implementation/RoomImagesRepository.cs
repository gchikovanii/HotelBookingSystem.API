using Booking.Domain.Entities.RoomAggregate;
using Booking.Infrastructure.Context;
using Booking.Infrastructure.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.Repository.Implementation
{
    public class RoomImagesRepository : Repository<RoomImages>, IRoomImagesRepository
    {
        public RoomImagesRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
