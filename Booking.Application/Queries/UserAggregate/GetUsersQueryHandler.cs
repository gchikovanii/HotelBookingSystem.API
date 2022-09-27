using Booking.Application.Constants;
using Booking.Application.Model.UserAggregate;
using Booking.Infrastructure.Repository.Abstraction;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Booking.Application.Queries.UserAggregate
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        public GetUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetQuery().ToListAsync();
            return users.Select(i => new UserDto()
            {
                Id = i.Id,
                Email = i.Email,
                UserName = i.UserName,
                PhoneNumber = i.PhoneNumber
            }).ToList();
        }
    }
}
