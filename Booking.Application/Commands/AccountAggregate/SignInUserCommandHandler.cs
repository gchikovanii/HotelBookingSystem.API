using Booking.Application.Services.Abstraction.JwtAuthAggregate;
using Booking.Domain.Entities.UserAggregate;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Booking.Application.Commands.AccountAggregate
{
    public class SignInUserCommandHandler : IRequestHandler<SignInUserCommand, string>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IJwtAuthenticationManager _jwtAuthentication;
        public SignInUserCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IJwtAuthenticationManager jwtAuthentication)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtAuthentication = jwtAuthentication;
        }
        public async Task<string> Handle(SignInUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            var checkPassword = await _signInManager.PasswordSignInAsync(user, request.Password, true, false);
            var roles = await _userManager.GetRolesAsync(user);
            return _jwtAuthentication.Authenticate(checkPassword.Succeeded, request.Email, roles.ToList());
        }
    }
}
