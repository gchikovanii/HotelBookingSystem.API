using Booking.Domain.Entities.OrderAggregate;
using Booking.Infrastructure.Repository.Abstraction;
using MediatR;
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
        public MakeOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<bool> Handle(MakeOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order()
            {
                CheckOut = request.CheckOut,
                CheckIn = request.CheckIn,
                RoomId = request.RoomId,
            };
            if (request.CheckIn.Day == request.CheckOut.Day && request.CheckIn.Hour < request.CheckOut.Hour ||
                request.CheckIn.Day < request.CheckOut.Day)
            {
                await _orderRepository.CreateAsync(order);
            }
            return await _orderRepository.SaveChangesAsync();
        }
    }
}
