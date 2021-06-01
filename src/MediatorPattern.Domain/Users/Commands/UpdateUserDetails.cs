using System;

namespace MediatorPattern.Domain.Users.Commands
{
    public class UpdateUserDetails
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
