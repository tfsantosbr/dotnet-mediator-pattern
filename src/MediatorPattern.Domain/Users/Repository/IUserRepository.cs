using System;
using MediatorPattern.Domain.Entities;

namespace MediatorPattern.Domain.Users.Repository
{
    public interface IUserRepository
    {
        void Add(User user);
        User GetById(Guid id);
        void Update(User user);
        bool AnyUser(Guid userId);
        void Remove(User user);
    }
}