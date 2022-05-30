using System.Collections.Generic;
using System.Linq;
using Kessewa.Quiz.Domain.Entities.Base;
using Kessewa.Quiz.Domain.ValueObjects;

namespace Kessewa.Quiz.Domain.Entities
{
    public class Departments : ClassBase
    {
        public int FacultyId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Email Email { get; private set; }
        public Phone Phone { get; private set; }
        

        private readonly HashSet<Lecturers> lecturers = new HashSet<Lecturers>();
        public IReadOnlyList<Lecturers> Lecturers => lecturers.ToList().AsReadOnly();
        private readonly HashSet<Students> students = new HashSet<Students>();
        public IReadOnlyList<Students> Students => students.ToList().AsReadOnly();
        private readonly HashSet<Courses> courses = new HashSet<Courses>();
        public IReadOnlyList<Courses> Courses => courses.ToList().AsReadOnly();
    }
}