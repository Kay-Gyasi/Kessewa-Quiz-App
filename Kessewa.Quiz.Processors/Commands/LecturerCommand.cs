using Kessewa.Quiz.Domain.Enums;

namespace Kessewa.Quiz.Processors.Commands
{
    public class LecturerCommand
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public LecturerType Type { get; set; }
        public UserCommand User { get; set; }
    }
}