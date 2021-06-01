using System;
using MediatR;

namespace MediatorPattern.Domain.Users.Events
{
    public class UserCreated : INotification
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
    }
}