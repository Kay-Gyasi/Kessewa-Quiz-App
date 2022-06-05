using System.Collections.Generic;
using Kessewa.Quiz.Domain.Entities;
using Kessewa.Quiz.Domain.ValueObjects;

namespace Kessewa.Quiz.Processors.Dtos
{
    public class DepartmentDto
    {
        public int FacultyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Email Email { get; set; }
        public Phone Phone { get; set; }
        public FacultyDto Faculty { get; set; }

        public List<UserDto> Users { get; set; }
        public List<CourseDto> Courses { get; set; }
    }
}