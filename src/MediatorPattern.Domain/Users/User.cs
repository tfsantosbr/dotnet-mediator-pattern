using System;

namespace NotificationPattern.Domain.Entities
{
    public class User
    {
        public User(string firstName, string lastName, string email, string password, DateTime birthDate, Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            BirthDate = birthDate;
        }

        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public void UpdateDetails(string firstName, string lastName, string email, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
        }

        public void UpdatePassword(string password)
        {
            Password = password;
        }
    }
}
