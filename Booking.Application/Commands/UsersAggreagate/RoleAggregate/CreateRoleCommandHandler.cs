using Booking.Domain.Entities.UserAggregate;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Booking.Application.Commands.UserAggreagate.Roles
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, bool>
    {
        private readonly RoleManager<AppRole> _roleManager;
        public CreateRoleCommandHandler(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<bool> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var existRole = await _roleManager.FindByNameAsync(request.RoleType.ToString());
            if(existRole == null)
            {
                await _roleManager.CreateAsync(new AppRole()
                {
                    Name = request.RoleType.ToString()
                });
                return true;
            }
            else
            {
                return false;
            }

            
        }
    }
}
