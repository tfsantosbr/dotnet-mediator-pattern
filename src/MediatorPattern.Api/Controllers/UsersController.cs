using System;
using MediatorPattern.Domain.Users.Commands;
using MediatorPattern.Domain.Users.Models;
using MediatorPattern.Domain.Users.Repository;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;

namespace MediatorPattern.Api.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserRepository _userRepository;

        public UsersController(IMediator mediator, IUserRepository userRepository)
        {
            _mediator = mediator;
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUser request)
        {
            var user = await _mediator.Send(request);

            var userDetails = new UserDetails
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = $"{user.BirthDate:yyyy-MM-dd}",
                Email = user.Email
            };

            return Created($"users/{userDetails.Id}", userDetails);
        }

        [HttpGet]
        public IActionResult GetUserById(Guid userId)
        {
            var user = _userRepository.GetById(userId);

            if (user is null)
                return NotFound();

            var userDetails = new UserDetails
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = $"{user.BirthDate:yyyy-MM-dd}",
                Email = user.Email
            };

            return Ok(userDetails);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveUser(Guid userId)
        {
            if (!_userRepository.AnyUser(userId))
                return NotFound();

            await _mediator.Send(new RemoveUser { Id = userId });

            return NoContent();
        }

        [HttpPut("details")]
        public async Task<IActionResult> UpdateUserDetails(UpdateUserDetails request)
        {
            if (!_userRepository.AnyUser(request.Id))
            {
                return NotFound();
            }

            await _mediator.Send(request);

            return NoContent();
        }

        [HttpPut("password")]
        public async Task<IActionResult> UpdateUserPassword(UpdateUserPassword request)
        {
            if (!_userRepository.AnyUser(request.Id))
            {
                return NotFound();
            }

            await _mediator.Send(request);

            return NoContent();
        }
    }
}
