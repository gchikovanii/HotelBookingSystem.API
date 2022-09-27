using Booking.Application.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Application.Commands.UserAggreagate.Roles
{
    public class CreateRoleCommand : IRequest<bool>
    {
        public RoleType RoleType { get; set; }
    }
}
