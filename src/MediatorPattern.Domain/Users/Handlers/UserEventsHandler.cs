using MediatorPattern.Domain.Users.Events;
using Microsoft.Extensions.Logging;

namespace MediatorPattern.Domain.Users.Handlers
{
    public class UserEventsHandler
    {
        private readonly ILogger<UserEventsHandler> _logger;

        public UserEventsHandler(ILogger<UserEventsHandler> logger)
        {
            _logger = logger;
        }

        public void Handle(UserCreated notification)
        {
            _logger.LogInformation("USER CREATED");

            // send user created e-mail...
            // send user created message to a message broker...
            // etc ...
        }

        public void Handle(UserDetailsUpdated notification)
        {
            _logger.LogInformation("USER DETAILS UPDATED");

            // send user details updated e-mail...
            // send user details updated message to a message broker...
            // etc ...
        }

        public void Handle(UserPasswordUpdated notification)
        {
            _logger.LogInformation("USER PASSWORD UPDATED");

            // send user password updated e-mail...
            // send user password updated message to a message broker...
            // etc ...
        }

        public void Handle(UserRemoved notification)
        {
            _logger.LogInformation("USER REMOVED");

            // send user removed e-mail...
            // send user removed message to a message broker...
            // etc ...
        }
    }
}