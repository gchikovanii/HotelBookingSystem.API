﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Booking.Domain.Entities.UserAggregate
{
    public class AppUser : IdentityUser<int>
    {
        public ICollection<AppUserRole> AppUserRoles { get; set; }
    }
}
