using MediatorPattern.Domain.Users.Commands;
using MediatorPattern.Domain.Users.Events;
using MediatorPattern.Domain.Users.Repository;
using NotificationPattern.Domain.Entities;
using System;

namespace MediatorPattern.Domain.Users.Handlers
{
    public class UserCommandsHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly UserEventsHandler _userEventsHandler;

        public UserCommandsHandler(IUserRepository userRepository, UserEventsHandler userEventsHandler)
        {
            _userRepository = userRepository;
            _userEventsHandler = userEventsHandler;
        }

        public User Handle(CreateUser request)
        {
            // validations...

            // business logic...

            var user = new User(
                firstName: request.FirstName,
                lastName: request.LastName,
                email: request.Email,
                password: request.Password,
                birthDate: request.BirthDate
                );

            _userRepository.Add(user);

            // send event

            var userCreated = new UserCreated
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate,
                Email = user.Email,
                Password = user.Password  
            };

            _userEventsHandler.Handle(userCreated);

            return user;
        }

        public void Handle(UpdateUserDetails request)
        {
            // validations...

            // business logic

            var user = _userRepository.GetById(request.Id);

            if (user is null)
                throw new ArgumentNullException(nameof(user));

            user.UpdateDetails(
                firstName: request.FirstName,
                lastName: request.LastName,
                email: request.Email,
                birthDate: request.BirthDate
            );

            _userRepository.Update(user);

            // send event

            var userDetailsUpdated = new UserDetailsUpdated
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate,
                Email = user.Email
            };

            _userEventsHandler.Handle(userDetailsUpdated);
        }

        public void Handle(UpdateUserPassword request)
        {
            // validations

            var user = _userRepository.GetById(request.Id);

            if (user is null)
                throw new ArgumentNullException(nameof(user));

            user.UpdatePassword(request.Password);

            _userRepository.Update(user);

            // send event

            var userPasswordUpdated = new UserPasswordUpdated
            {
                Id = user.Id,
                Password = user.Password  
            };

            _userEventsHandler.Handle(userPasswordUpdated);
        }

        public void Handle(RemoveUser request)
        {
            // validations

            var user = _userRepository.GetById(request.Id);

            if (user is null)
                throw new ArgumentNullException(nameof(user));

            _userRepository.Remove(user);

            // send event

            var userRemoved = new UserRemoved
            {
                Id = user.Id
            };

            _userEventsHandler.Handle(userRemoved);
        }
    }
}
