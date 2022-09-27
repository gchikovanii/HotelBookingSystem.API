using Booking.Infrastructure.Repository.Abstraction;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Booking.Application.Commands.RoomAggregate
{
    public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, bool>
    {
        private readonly IRoomRepository _roomRepository;
        public UpdateRoomCommandHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<bool> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            var room = await _roomRepository.GetQuery(i => i.Id == request.Id).SingleOrDefaultAsync();
            if(room != null)
            {
                room.AirConditioner = request.AirConditioner;
                room.Balcony = request.Balcony;
                room.BedType = request.BedType;
                room.RoomType = request.RoomType;
                room.Fridge = request.Fridge;
                room.MiniBar = request.MiniBar;
                room.Sofa = request.Sofa;
                room.TV = request.TV;
                if(room.HotelId != 0)
                    room.HotelId = request.HotelId;
                if(room.NumberOfRooms != 0)
                    room.NumberOfRooms = request.NumberOfRooms;

                _roomRepository.Update(room);
                return await _roomRepository.SaveChangesAsync();
            }
            return false;
        }
    }
}
