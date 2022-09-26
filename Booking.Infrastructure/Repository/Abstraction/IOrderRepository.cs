using Booking.Domain.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Infrastructure.Repository.Abstraction
{
    public interface IOrderRepository : IRepository<Order>
    {
    }
}
