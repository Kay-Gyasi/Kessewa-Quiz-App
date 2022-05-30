using System.Collections.Generic;
using System.Linq;
using Kessewa.Quiz.Domain.Entities.Base;
using Kessewa.Quiz.Domain.Enums;

namespace Kessewa.Quiz.Domain.Entities
{
    public class Courses : ClassBase
    {
        public int LecturerId { get; private set; }
        public string Name { get; private set; }
        public CreditHours CreditHours { get; private set; }
        public LevelType Level { get; private set; }
        public string Description { get; private set; }

        private readonly HashSet<Departments> departments = new HashSet<Departments>();
        public IReadOnlyList<Departments> Departments => departments.ToList().AsReadOnly();
    }
}