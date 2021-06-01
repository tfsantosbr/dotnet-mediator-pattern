using System;
using MediatR;

namespace MediatorPattern.Domain.Users.Commands
{
    public class RemoveUser : IRequest
    {
        public Guid Id { get; set; }
    }
}