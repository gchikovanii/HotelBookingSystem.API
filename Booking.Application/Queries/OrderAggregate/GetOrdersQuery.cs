using Booking.Application.Model.OrdersAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Application.Queries.OrderAggregate
{
    public class GetOrdersQuery : IRequest<List<OrderDto>>
    {
    }
}
