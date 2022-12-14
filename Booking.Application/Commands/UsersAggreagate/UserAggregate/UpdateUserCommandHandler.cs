using Booking.Domain.Entities.UserAggregate;
using Booking.Infrastructure.Repository.Abstraction;
using Booking.Infrastructure.Repository.Implementation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Booking.Application.Commands.UsersAggreagate.UserAggregate
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<AppUser> _userManager;
        public UpdateUserCommandHandler(IUserRepository userRepository, UserManager<AppUser> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }
        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetQuery(i => i.Id == request.Id).FirstOrDefaultAsync();
            if (user != null)
            {
                //Check if updated username or email exists!
                var emailExist = await _userRepository.GetQuery(i => i.Email == request.Email).FirstOrDefaultAsync();
                var userNameExist = await _userRepository.GetQuery(i => i.UserName == request.UserName).FirstOrDefaultAsync();
                if (request.Email != null)
                    user.Email = request.Email;
                if (request.UserName != null)
                    user.UserName = request.UserName;
                if (request.Password != null)
                {
                    await _userManager.ChangePasswordAsync(user, user.PasswordHash, request.Password);
                }
                if (request.PhoneNumber != null)
                    user.PhoneNumber = request.PhoneNumber;
                _userRepository.Update(user);
                return await _userRepository.SaveChangesAsync();

            }
            return false;
        }
    }
}
