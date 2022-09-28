using Booking.Application.Model.OrdersAggregate;
using Booking.Infrastructure.Repository.Abstraction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Booking.Application.Queries.OrderAggregate
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, List<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;
        public GetOrdersQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<List<OrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetCollcetionsAsync();
            return orders.Select(i => new OrderDto()
            {
                CheckIn = i.CheckIn,
                CheckOut = i.CheckOut,
                RoomId = i.RoomId,
                UserId = i.AppUserId
            }).ToList();
        }
    }
}
