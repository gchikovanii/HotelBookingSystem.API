using Booking.Application.Model.OrdersAggregate;
using Booking.Infrastructure.Repository.Abstraction;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Booking.Application.Queries.OrderAggregate
{
    internal class GetOrdersByRoomIdQueryHandler : IRequestHandler<GetOrdersByRoomIdQuery, List<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;
        public GetOrdersByRoomIdQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<List<OrderDto>> Handle(GetOrdersByRoomIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetQuery(i => i.RoomId == request.RoomId).ToListAsync();
            return order.Select(i => new OrderDto()
            {
                CheckIn = i.CheckIn,
                CheckOut = i.CheckOut,
                RoomId = i.RoomId
            }).ToList();
        }
    }
}
