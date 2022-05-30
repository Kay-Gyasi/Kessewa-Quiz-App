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


        private readonly HashSet<Lecturers> lecturers  = new HashSet<Lecturers>();
        public IReadOnlyList<Lecturers> Lecturers => lecturers.ToList().AsReadOnly();
        private readonly HashSet<Students> students = new HashSet<Students>();
        public IReadOnlyList<Students> Students => students.ToList().AsReadOnly();
    }
}