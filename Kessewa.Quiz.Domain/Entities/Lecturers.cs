using System.Collections.Generic;
using System.Linq;
using Kessewa.Quiz.Domain.Entities.Base;
using Kessewa.Quiz.Domain.Enums;

namespace Kessewa.Quiz.Domain.Entities
{
    public class Lecturers : ClassBase
    {
        public int UserId { get; private set; }
        public LecturerType Type { get; private set; }

        private readonly HashSet<Courses> courses = new HashSet<Courses>();
        public IReadOnlyList<Courses> Courses => courses.ToList().AsReadOnly();
    }
}