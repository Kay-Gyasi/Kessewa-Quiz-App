using System.Collections.Generic;
using System.Linq;
using Kessewa.Quiz.Domain.Entities.Base;
using Kessewa.Quiz.Domain.ValueObjects;

namespace Kessewa.Quiz.Domain.Entities
{
    public class Departments : EntityBase
    {


        public int FacultyId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Email Email { get; private set; }
        public Phone Phone { get; private set; }
        public Faculties Faculty { get; private set; }


        
        private readonly List<Users> _users = new List<Users>();
        public IReadOnlyList<Users> Users => _users.AsReadOnly();
        private readonly List<Courses> _courses = new List<Courses>();
        public IReadOnlyList<Courses> Courses => _courses.AsReadOnly();        

        
        private Departments() { }

        private Departments(string name, int facultyId)
        {
            Name = name;
            FacultyId = facultyId;
        }

        public static Departments Create(string name, int facultyId)
        {
            return new Departments(name, facultyId);
        }

        public Departments SetId(int id)
        {
            Id = id;
            return this;
        }

        public Departments WithName(string name)
        {
            Name = name;
            return this;
        }

        public Departments WithFacultyId(int facultyId)
        {
            FacultyId = facultyId;
            return this;
        }

        public Departments WithDescription(string description)
        {
            Description = description;
            return this;
        }

        public Departments WithEmail(Email email)
        {
            Email = email;
            return this;
        }

        public Departments WithPhone(Phone phone)
        {
            Phone = phone;
            return this;
        }

        public Departments ForFaculty(Faculties faculty)
        {
            Faculty = faculty;
            return this;
        }
        
    }
}