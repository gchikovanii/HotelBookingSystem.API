using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Application.Model.UserAggregate
{
    public class AdminDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
