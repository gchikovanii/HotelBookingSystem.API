using Booking.Application.Model.MediaAggregate;
using Booking.Application.Model.RoomAggregate;
using Booking.Infrastructure.Repository.Abstraction;
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
    public class GetRoomByIdQueryHandler : IRequestHandler<GetRoomByIdQuery, RoomDto>
    {
        private readonly IRoomRepository _roomRepository;
        public GetRoomByIdQueryHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public async Task<RoomDto> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
        {
            var room = await _roomRepository.GetQuery(i => i.Id == request.Id).Include(i => i.Images).FirstOrDefaultAsync();
            if(room != null)
            {
                return new RoomDto()
                {
                    Id = room.Id,
                    Sofa = room.Sofa,
                    AirConditioner = room.AirConditioner,
                    Balcony = room.Balcony,
                    BedType = room.BedType,
                    CoffeMachine = room.CoffeMachine,
                    Fridge = room.Fridge,
                    MiniBar = room.MiniBar,
                    RoomType = room.RoomType,
                    TV = room.TV,
                    HotelId = room.HotelId,
                    Images = room.Images.Select(o => new RoomImagesDto()
                    {
                        PublicId = o.PublicId,
                        Url = o.Url
                    }).ToList()
                };
            }
            return null;
            
        }
    }
}
