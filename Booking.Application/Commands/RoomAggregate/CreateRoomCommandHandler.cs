using Booking.Domain.Entities.RoomAggregate;
using Booking.Infrastructure.Repository.Abstraction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Booking.Application.Commands.RoomAggregate
{
    internal class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, bool>
    {
        private readonly IRoomRepository _roomRepository;
        public CreateRoomCommandHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public async Task<bool> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            var room = new Room()
            {
                Sofa = request.Sofa,
                AirConditioner = request.AirConditioner,
                Balcony = request.Balcony,
                BedType = request.BedType,
                RoomType = request.RoomType,
                CoffeMachine = request.CoffeMachine,
                TV = request.TV,
                Fridge = request.Fridge,
                MiniBar = request.MiniBar,
                HotelId = request.HotelId,
                NumberOfRooms = request.NumberOfRooms
            };
            await _roomRepository.CreateAsync(room);
            return await _roomRepository.SaveChangesAsync();
        }
    }
}
