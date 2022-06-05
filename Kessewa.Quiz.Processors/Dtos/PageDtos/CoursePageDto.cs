using Kessewa.Quiz.Domain.Enums;

namespace Kessewa.Quiz.Processors.Dtos.PageDtos
{
    public class CoursePageDto
    {
        public string Name { get; set; }
        public CreditHours CreditHours { get; set; }
        public LevelType Level { get; set; }
        public string Description { get; set; }
        public LecturerDto Lecturer { get; set; }
    }
}
