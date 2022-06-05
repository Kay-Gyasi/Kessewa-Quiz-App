using System.Collections.Generic;
using Kessewa.Quiz.Domain.Entities;
using Kessewa.Quiz.Domain.Enums;

namespace Kessewa.Quiz.Processors.Dtos
{
    public class LecturerDto
    {
        public int UserId { get; set; }
        public LecturerType Type { get; set; }
        public UserDto User { get; set; }

        
        public List<CourseDto> Courses { get; set; }
    }
}