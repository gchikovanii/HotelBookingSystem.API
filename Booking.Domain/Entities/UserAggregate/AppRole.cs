using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Domain.Entities.UserAggregate
{
    public class AppRole : IdentityRole<int>
    {
        public ICollection<AppUserRole> AppUserRoles { get; set; }
    }
}
