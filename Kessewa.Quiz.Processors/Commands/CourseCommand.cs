using System.Text;
using Kessewa.Quiz.Domain.Enums;

namespace Kessewa.Quiz.Processors.Commands
{
    public class CourseCommand
    {
        public int LecturerId { get; set; }
        public string Name { get; set; }
        public CreditHours CreditHours { get; set; }
        public LevelType Level { get; set; }
        public string Description { get; set; }
    }
}
