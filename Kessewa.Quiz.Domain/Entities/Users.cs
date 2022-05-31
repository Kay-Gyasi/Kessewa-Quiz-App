using System.Collections.Generic;
using System.Linq;
using Kessewa.Quiz.Domain.Entities.Base;
using Kessewa.Quiz.Domain.Enums;
using Kessewa.Quiz.Domain.ValueObjects;

namespace Kessewa.Quiz.Domain.Entities
{
    public class Users : ClassBase
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string DisplayName { get; private set; }
        public UserType Type { get; private set; }
        public Email Email { get; private set; }
        public Phone Phone { get; private set; }
        public Address Address { get; private set; }
        public byte[] Password { get; private set; }
        public byte[] PasswordKey { get; private set; }


        private readonly HashSet<Lecturers> _lecturers = new HashSet<Lecturers>();
        public IEnumerable<Lecturers> Lecturers => _lecturers.ToList().AsReadOnly();
        private readonly HashSet<Students> _students = new HashSet<Students>();
        public IEnumerable<Students> Students => _students.ToList().AsReadOnly();

        
        
        private Users() { }

        private Users(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public static Users Create(string firstName, string lastName)
        {
            return new Users(firstName, lastName);
        }

        public Users WithFirstName(string firstName)
        {
            FirstName = firstName;
            return this;
        }

        public Users WithLastName(string lastName)
        {
            LastName = lastName;
            return this;
        }

        public Users WithDisplayName(string displayName)
        {
            DisplayName = displayName;
            return this;
        }

        public Users WithEmail(Email email)
        {
            Email = email;
            return this;
        }

        public Users WithPassword(byte[] password)
        {
            Password = password;
            return this;
        }

        public Users WithPasswordKey(byte[] passwordKey)
        {
            PasswordKey = passwordKey;
            return this;
        }

        public Users OfType(UserType type)
        {
            Type = type;
            return this;
        }

        public Users WithPhone(Phone phone)
        {
            Phone = phone;
            return this;
        }

        public Users WithAddress(Address address)
        {
            Address = address;
            return this;
        }



    }
}