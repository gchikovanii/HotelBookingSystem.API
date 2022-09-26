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
    public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand, bool>
    {
        private readonly IRoomRepository _roomRepository;
        public DeleteRoomCommandHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<bool> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {
            var room = await _roomRepository.GetQuery(i => i.Id == request.Id).SingleOrDefaultAsync();
            if(room != null)
            {
                _roomRepository.Delete(room);
                return await _roomRepository.SaveChangesAsync();
            }
            return false;
        }
    }
}
