using Booking.Domain.Entities.OrderAggregate;
using Booking.Infrastructure.Repository.Abstraction;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Booking.Application.Commands.OrderAggregate
{
    public class MakeOrderCommandHandler : IRequestHandler<MakeOrderCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        public MakeOrderCommandHandler(IOrderRepository orderRepository, IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(MakeOrderCommand request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetById(request.UserId);
            if (user != null)
            {
                var order = new Order()
                {
                    CheckOut = request.CheckOut,
                    CheckIn = request.CheckIn,
                    RoomId = request.RoomId,
                    AppUserId = request.UserId
                };
                if (request.CheckIn.Day == request.CheckOut.Day && request.CheckIn.Hour < request.CheckOut.Hour ||
                    request.CheckIn.Day < request.CheckOut.Day)
                {
                    await _orderRepository.CreateAsync(order);
                }
                return await _orderRepository.SaveChangesAsync();
            }
            return false;
           
        }
    }
}
