using System;

namespace MediatorPattern.Domain.Users.Events
{
    public class UserRemoved
    {
        public Guid Id { get; set; }
    }
}