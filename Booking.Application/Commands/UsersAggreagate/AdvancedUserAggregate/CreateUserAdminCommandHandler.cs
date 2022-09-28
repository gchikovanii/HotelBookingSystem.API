using Booking.Application.Constants;
using Booking.Domain.Entities.UserAggregate;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Booking.Application.Commands.UserAggreagate.AdminAggregate
{
    public class CreateUserAdminCommandHandler : IRequestHandler<CreateUserAdminCommand, bool>
    {
        private readonly UserManager<AppUser> _userManager;

        public CreateUserAdminCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> Handle(CreateUserAdminCommand request, CancellationToken cancellationToken)
        {
            var userNameExist = await _userManager.FindByNameAsync(request.UserName);
            var userEmailExist = await _userManager.FindByEmailAsync(request.Email);
            if (userEmailExist == null && userNameExist == null)
            {
                var currentUser = new AppUser()
                {
                    UserName = request.UserName,
                    Email = request.Email
                };
                var createdUser = await _userManager.CreateAsync(currentUser, request.Password);
                if (createdUser.Succeeded)
                {
                    await _userManager.AddToRoleAsync(currentUser, RoleType.Admin.ToString());
                    return true;
                }

            }
            return false;
        }
    }
}
