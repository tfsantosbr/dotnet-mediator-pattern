using System;
using MediatR;
using MediatorPattern.Domain.Entities;

namespace MediatorPattern.Domain.Users.Commands
{
    public class CreateUser : IRequest<User>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
