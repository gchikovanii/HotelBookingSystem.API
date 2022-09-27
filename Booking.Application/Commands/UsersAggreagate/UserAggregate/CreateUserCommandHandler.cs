using Booking.Application.Constants;
using Booking.Domain.Entities.UserAggregate;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Booking.Application.Commands.UsersAggreagate.UserAggregate
{
    internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly UserManager<AppUser> _userManager;
        public CreateUserCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var emailExist = await _userManager.FindByEmailAsync(request.Email);
            var userNameExist = await _userManager.FindByNameAsync(request.UserName);

            if (emailExist == null && userNameExist == null)
            {
                var cuurentUser = new AppUser()
                {
                    UserName = request.UserName,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber
                };

                var userCreated = await _userManager.CreateAsync(cuurentUser, request.Password);
                if (userCreated.Succeeded)
                {
                    await _userManager.AddToRoleAsync(cuurentUser, RoleType.User.ToString());
                    return true;
                }

            }
            return false;
        }
    }
}
