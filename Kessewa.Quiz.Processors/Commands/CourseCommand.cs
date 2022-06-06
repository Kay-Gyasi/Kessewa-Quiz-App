using System.Text;
using Kessewa.Quiz.Domain.Enums;
using Kessewa.Quiz.Processors.Dtos;

namespace Kessewa.Quiz.Processors.Commands
{
    public class CourseCommand
    {
        public int Id { get; set; }
        public int LecturerId { get; set; }
        public string Name { get; set; }
        public CreditHours CreditHours { get; set; }
        public LevelType Level { get; set; }
        public string Description { get; set; }
        public LecturerCommand Lecturer { get; set; }
    }
}
