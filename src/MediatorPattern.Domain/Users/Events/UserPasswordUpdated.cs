using System;
using MediatR;

namespace MediatorPattern.Domain.Users.Events
{
    public class UserPasswordUpdated : INotification
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
    }
}