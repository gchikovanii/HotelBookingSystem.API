using Booking.Infrastructure.Repository.Abstraction;
using Booking.Infrastructure.Repository.Implementation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Booking.Application.Commands.OrderAggregate
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        public UpdateOrderCommandHandler(IOrderRepository orderRepository, IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
        }
        public async Task<bool> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetById(request.UserId);
            if(user != null)
            {
                var order = await _orderRepository.GetQuery(i => i.Id == request.Id).SingleOrDefaultAsync();
                if (user != null && order != null)
                {
                    if (request.CheckIn.Day == request.CheckOut.Day && request.CheckIn.Hour < request.CheckOut.Hour ||
                    request.CheckIn.Day < request.CheckOut.Day)
                    {
                        order.CheckIn = request.CheckIn;
                        order.CheckOut = request.CheckOut;
                        order.RoomId = request.RoomId;
                        _orderRepository.Update(order);
                        return await _orderRepository.SaveChangesAsync();
                    }
                }
            }
            return false;
        }
    }
}
