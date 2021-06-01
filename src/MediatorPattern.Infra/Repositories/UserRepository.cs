using MediatorPattern.Domain.Users.Repository;
using NotificationPattern.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NotificationPattern.Domain.Users.Repository
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new();

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User GetById(Guid id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public void Update(User user)
        {
            var currentUser = GetById(user.Id);

            if (currentUser != null) currentUser = user;
        }

        public bool AnyUser(Guid userId)
        {
            return _users.Any(u => u.Id == userId);
        }

        public void Remove(User user)
        {
            _users.Remove(user);
        }
    }
}
