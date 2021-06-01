using System.Threading;
using System.Threading.Tasks;
using MediatorPattern.Domain.Users.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace MediatorPattern.Domain.Users.Handlers
{
    public class UserEventsHandler : 
        INotificationHandler<UserCreated>,
        INotificationHandler<UserDetailsUpdated>,
        INotificationHandler<UserPasswordUpdated>,
        INotificationHandler<UserRemoved>
    {
        private readonly ILogger<UserEventsHandler> _logger;

        public UserEventsHandler(ILogger<UserEventsHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(UserCreated notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("USER CREATED");

            // send user created e-mail...
            // send user created message to a message broker...
            // etc ...

            return Task.CompletedTask;
        }

        public Task Handle(UserDetailsUpdated notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("USER DETAILS UPDATED");

            // send user details updated e-mail...
            // send user details updated message to a message broker...
            // etc ...

            return Task.CompletedTask;
        }

        public Task Handle(UserPasswordUpdated notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("USER PASSWORD UPDATED");

            // send user password updated e-mail...
            // send user password updated message to a message broker...
            // etc ...
            
            return Task.CompletedTask;
        }

        public Task Handle(UserRemoved notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("USER REMOVED");

            // send user removed e-mail...
            // send user removed message to a message broker...
            // etc ...
            
            return Task.CompletedTask;
        }
    }
}