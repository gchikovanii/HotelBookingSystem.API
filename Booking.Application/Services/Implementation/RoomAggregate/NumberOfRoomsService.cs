using Booking.Application.Services.Abstraction.RoomAggregate;
using Booking.Infrastructure.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Application.Services.Implementation.RoomAggregate
{
    public class NumberOfRoomsService : INumberOfRoomsService
    {
        private readonly INumberOfRoomsByTypesRepository _numberOfRoomsRepository;
        public NumberOfRoomsService(INumberOfRoomsByTypesRepository numberOfRoomsRepository)
        {
            _numberOfRoomsRepository = numberOfRoomsRepository;
        }


    }
}
