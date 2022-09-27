using Booking.Domain.Entities.UserAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Infrastructure.Repository.Abstraction
{
    public interface IUserRepository : IRepository<AppUser>
    {
    }
}
