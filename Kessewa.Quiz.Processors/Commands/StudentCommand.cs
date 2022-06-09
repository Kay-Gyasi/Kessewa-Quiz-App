using Kessewa.Quiz.Domain.Enums;

namespace Kessewa.Quiz.Processors.Commands
{
    public class StudentCommand
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public LevelType Level { get; set; }
        public UserCommand User { get; set; }
    }
}