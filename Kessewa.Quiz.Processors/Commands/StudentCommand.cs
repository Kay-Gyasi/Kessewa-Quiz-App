using Kessewa.Quiz.Domain.Enums;

namespace Kessewa.Quiz.Processors.Commands
{
    public class StudentCommand
    {
        public int UserId { get; set; }
        public LevelType Level { get; set; }
    }
}