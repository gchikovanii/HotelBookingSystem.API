using Booking.Infrastructure.Repository.Abstraction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Booking.Application.Commands.UsersAggreagate.WishListAggregate
{
    public class CreateWishListCommandHandler : IRequestHandler<CreateWishListCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        public CreateWishListCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> Handle(CreateWishListCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.CreateWishList(request.UserId, request.HotelId);
            return await _userRepository.SaveChangesAsync();
        }
    }
}
