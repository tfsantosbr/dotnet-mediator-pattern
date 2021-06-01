using MediatorPattern.Domain.Users.Commands;
using MediatorPattern.Domain.Users.Events;
using MediatorPattern.Domain.Users.Repository;
using MediatorPattern.Domain.Entities;
using System;
using MediatR;
using System.Threading.Tasks;
using System.Threading;

namespace MediatorPattern.Domain.Users.Handlers
{
    public class UserCommandsHandler :
        IRequestHandler<CreateUser, User>,
        IRequestHandler<UpdateUserDetails>,
        IRequestHandler<UpdateUserPassword>,
        IRequestHandler<RemoveUser>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;

        public UserCommandsHandler(IUserRepository userRepository, IMediator mediator)
        {
            _userRepository = userRepository;
            _mediator = mediator;
        }

        public Task<User> Handle(CreateUser request, CancellationToken cancellationToken)
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

            _mediator.Publish(userCreated);

            return Task.FromResult(user);
        }

        public Task<Unit> Handle(UpdateUserDetails request, CancellationToken cancellationToken)
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

            _mediator.Publish(userDetailsUpdated);

            return Task.FromResult(Unit.Value);
        }

        public Task<Unit> Handle(UpdateUserPassword request, CancellationToken cancellationToken)
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

            _mediator.Publish(userPasswordUpdated);

            return Task.FromResult(Unit.Value);
        }

        public Task<Unit> Handle(RemoveUser request, CancellationToken cancellationToken)
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

            _mediator.Publish(userRemoved);
            
            return Task.FromResult(Unit.Value);
        }
    }
}
