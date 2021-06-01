using System;
using MediatR;

namespace MediatorPattern.Domain.Users.Commands
{
    public class UpdateUserPassword : IRequest
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}