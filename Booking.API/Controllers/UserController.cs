using Booking.Application.Commands.UserAggreagate.AdminAggregate;
using Booking.Application.Commands.UserAggreagate.ModeratorAggregate;
using Booking.Application.Commands.UserAggreagate.Roles;
using Booking.Application.Commands.UsersAggreagate.UserAggregate;
using Booking.Application.Queries.UserAggregate;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Booking.API.Controllers
{
    public class UserController : BaseController
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(nameof(GetRoles))]
        public async Task<IActionResult> GetRoles()
        {
            return Ok(await _mediator.Send(new GetRolesQuery()));
        }
        [HttpGet(nameof(GetUsers))]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _mediator.Send(new GetUsersQuery()));
        }

        [HttpGet(nameof(GetUserById))]
        public async Task<IActionResult> GetUserById([FromQuery]GetUserByIdQuery input)
        {
            return Ok(await _mediator.Send(input));
        }

        [HttpPost(nameof(CreateRole))]
        public async Task<IActionResult> CreateRole([FromForm]CreateRoleCommand input)
        {
            return Ok(await _mediator.Send(input));
        }

        [HttpPost(nameof(CreateAdmin))]
        public async Task<IActionResult> CreateAdmin(CreateUserAdminCommand input)
        {
            return Ok(await _mediator.Send(input));
        }

        [HttpPost(nameof(CreateModerator))]
        public async Task<IActionResult> CreateModerator(CreateModeratorCommand input)
        {
            return Ok(await _mediator.Send(input));
        }

        [HttpPost(nameof(CreateUser))]
        public async Task<IActionResult> CreateUser(CreateUserCommand input)
        {
            return Ok(await _mediator.Send(input));
        }
        [HttpPut(nameof(UpdateUser))]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand input)
        {
            return Ok(await _mediator.Send(input));
        }
      
        [HttpDelete(nameof(DeleteUser))]
        public async Task<IActionResult> DeleteUser(DeleteUserCommand input)
        {
            return Ok(await _mediator.Send(input));
        }


    }
}
