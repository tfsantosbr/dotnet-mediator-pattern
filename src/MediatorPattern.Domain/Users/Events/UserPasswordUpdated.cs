using System;

namespace MediatorPattern.Domain.Users.Events
{
    public class UserPasswordUpdated
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
    }
}