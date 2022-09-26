using Booking.Domain.Entities.OrderAggregate;
using Booking.Infrastructure.Context;
using Booking.Infrastructure.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Infrastructure.Repository.Implementation
{
    public class OrderRepository : Repository<Order> , IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context): base(context)
        {
        }
    }
}
