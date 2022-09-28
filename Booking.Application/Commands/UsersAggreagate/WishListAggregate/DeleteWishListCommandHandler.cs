using Booking.Infrastructure.Repository.Abstraction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Booking.Application.Commands.UsersAggreagate.WishListAggregate
{
    public class DeleteWishListCommandHandler : IRequestHandler<DeleteWishListCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        public DeleteWishListCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> Handle(DeleteWishListCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.UserId);
            var currentHotel = user.Hotels.SingleOrDefault(i => i.Id == request.HotelId);
            if(currentHotel != null)
            {
                user.Hotels.Remove(currentHotel);
                return await _userRepository.SaveChangesAsync();
            }
            return false;
        }
    }
}
