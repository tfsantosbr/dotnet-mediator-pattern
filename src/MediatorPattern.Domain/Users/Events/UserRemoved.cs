using System;
using MediatR;

namespace MediatorPattern.Domain.Users.Events
{
    public class UserRemoved : INotification
    {
        public Guid Id { get; set; }
    }
}