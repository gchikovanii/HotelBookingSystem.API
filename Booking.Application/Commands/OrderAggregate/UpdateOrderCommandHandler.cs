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
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;
        public UpdateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<bool> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetQuery(i => i.Id == request.Id).SingleOrDefaultAsync();
            if(order != null)
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
            return false;
        }
    }
}
