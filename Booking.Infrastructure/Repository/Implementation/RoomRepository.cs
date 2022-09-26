using Booking.Domain.Entities.RoomAggregate;
using Booking.Infrastructure.Context;
using Booking.Infrastructure.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Infrastructure.Repository.Implementation
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(ApplicationDbContext context): base(context)
        {
        }
    }
}
