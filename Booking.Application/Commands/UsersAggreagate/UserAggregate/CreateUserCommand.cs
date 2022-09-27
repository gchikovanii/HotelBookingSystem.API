﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Application.Commands.UsersAggreagate.UserAggregate
{
    public class CreateUserCommand : IRequest<bool>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
}
