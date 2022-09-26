using Booking.Application.Model.RoomAggregate;
using Booking.Infrastructure.Repository.Abstraction;
using Booking.Infrastructure.Repository.Implementation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Booking.Application.Queries.RoomAggregate
{
    public class GetRoomsQueryHandler : IRequestHandler<GetRoomsQuery, List<RoomDto>>
    {
        private readonly IRoomRepository _roomRepository;
        public GetRoomsQueryHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<List<RoomDto>> Handle(GetRoomsQuery request, CancellationToken cancellationToken)
        {
            var rooms = await _roomRepository.GetQuery().ToListAsync();
            return rooms.Select(i => new RoomDto()
            {
                Id = i.Id,
                Sofa = i.Sofa,
                AirConditioner = i.AirConditioner,
                Balcony = i.Balcony,
                BedType = i.BedType,
                CoffeMachine = i.CoffeMachine,
                Fridge = i.Fridge,
                MiniBar = i.MiniBar,
                RoomType = i.RoomType,
                TV = i.TV,
                HotelId = i.HotelId
            }).ToList();
        }
    }
}
