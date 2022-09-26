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
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;
        public DeleteOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetQuery(i => i.Id == request.Id).SingleOrDefaultAsync();
            if(order != null)
            {
                _orderRepository.Delete(order);
                return await _orderRepository.SaveChangesAsync();
            }
            return false;
        }
    }
}
