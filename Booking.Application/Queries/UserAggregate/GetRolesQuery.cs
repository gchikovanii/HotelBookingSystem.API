using Booking.Application.Model.UserAggregate;
using Booking.Domain.Entities.UserAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Application.Queries.UserAggregate
{
    public class GetRolesQuery : IRequest<List<RoleDto>>
    {
    }
}
