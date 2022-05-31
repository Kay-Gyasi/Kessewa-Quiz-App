using System.Collections.Generic;
using System.Linq;
using Kessewa.Quiz.Domain.Entities.Base;
using Kessewa.Quiz.Domain.Enums;

namespace Kessewa.Quiz.Domain.Entities
{
    public class Courses : EntityBase
    {

        public int LecturerId { get; private set; }
        public string Name { get; private set; }
        public CreditHours CreditHours { get; private set; }
        public LevelType Level { get; private set; }
        public string Description { get; private set; }
        public Lecturers Lecturer { get; private set; }

        private readonly List<Departments> departments = new List<Departments>();
        public IReadOnlyList<Departments> Departments => departments.ToList().AsReadOnly();        
        
        private Courses() { }

        private Courses(string name)
        {
            Name = name;
        }

        public static Courses Create(string name)
        {
            return new Courses(name);
        }

        public Courses SetId(int id)
        {
            Id = id;
            return this;
        }
        
        public Courses WithName(string name)
        {
            Name = name;
            return this;
        }

        public Courses WithLecturerId(int lecturerId)
        {
            LecturerId = lecturerId;
            return this;
        }

        public Courses HasCreditHours(CreditHours creditHours)
        {
            CreditHours = creditHours;
            return this;
        }

        public Courses ForLevel(LevelType level)
        {
            Level = level;
            return this;
        }

        public Courses ForLecturer(Lecturers lecturer)
        {
            Lecturer = lecturer;
            return this;
        }

        public Courses WithDescription(string description)
        {
            Description = description;
            return this;
        }
        
    }
}