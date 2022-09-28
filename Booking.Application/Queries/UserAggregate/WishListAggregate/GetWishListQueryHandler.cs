using Booking.Application.Model.HotelAggregate;
using Booking.Domain.Entities.HotelAggregate;
using Booking.Infrastructure.Repository.Abstraction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Booking.Application.Queries.UserAggregate.WishListAggregate
{
    public class GetWishListQueryHandler : IRequestHandler<GetWishListQuery, List<HotelDto>>
    {
        private readonly IUserRepository _userRepository;
        public GetWishListQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<HotelDto>> Handle(GetWishListQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.UserId);
            if(user.Hotels.Count > 0)
            {
                return user.Hotels.Select(i => new HotelDto()
                {
                    Name = i.Name,
                    Address = i.Address,
                    Latitude = i.Latitude,
                    Longtitude = i.Longtitude,
                    MaxPrice = i.MaxPrice,
                    MinPrice = i.MinPrice
                }).ToList();
            }
            return new List<HotelDto>();
        }
    }
}
