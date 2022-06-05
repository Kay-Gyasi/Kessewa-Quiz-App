using System.Collections.Generic;
using System.Text;
using Kessewa.Quiz.Domain.Entities;
using Kessewa.Quiz.Domain.Enums;

namespace Kessewa.Quiz.Processors.Dtos
{
    public class CourseDto
    {
        public int LecturerId { get; set; }
        public string Name { get; set; }
        public CreditHours CreditHours { get; set; }
        public LevelType Level { get; set; }
        public string Description { get; set; }
        public LecturerDto Lecturer { get; set; }
        public List<DepartmentDto> Departments { get; set; }
    }
}
