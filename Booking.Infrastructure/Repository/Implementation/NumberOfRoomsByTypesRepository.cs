using Booking.Domain.Entities.RoomAggregate;
using Booking.Infrastructure.Context;
using Booking.Infrastructure.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Infrastructure.Repository.Implementation
{
    public class NumberOfRoomsByTypesRepository : Repository<NumberOfRoomsByTypes>, INumberOfRoomsByTypesRepository
    {
        public NumberOfRoomsByTypesRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
