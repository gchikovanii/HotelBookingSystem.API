using Booking.Application.Constants;
using Booking.Domain.Entities.UserAggregate;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Booking.Application.Commands.UserAggreagate.ModeratorAggregate
{
    public class CreateModeratorCommandHandler : IRequestHandler<CreateModeratorCommand, bool>
    {
        private readonly UserManager<AppUser> _userManager;
        public CreateModeratorCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<bool> Handle(CreateModeratorCommand request, CancellationToken cancellationToken)
        {
            var userNameExist = await _userManager.FindByNameAsync(request.UserName);
            var userEmailExist = await _userManager.FindByEmailAsync(request.Email);
            if (userEmailExist == null && userEmailExist == null)
            {
                var currentUser = new AppUser()
                {
                    UserName = request.UserName,
                    Email = request.UserName,
                    PhoneNumber = request.PhoneNumber
                };
                var userCreated = await _userManager.CreateAsync(currentUser, request.Password);
                if (userCreated.Succeeded)
                {
                    await _userManager.AddToRoleAsync(currentUser, RoleType.Moderator.ToString());
                    return true;
                }
            }
            return false;
        }
    }
}
