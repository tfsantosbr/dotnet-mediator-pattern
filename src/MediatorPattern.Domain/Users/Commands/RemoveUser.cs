using System;

namespace MediatorPattern.Domain.Users.Commands
{
    public class RemoveUser
    {
        public Guid Id { get; set; }
    }
}