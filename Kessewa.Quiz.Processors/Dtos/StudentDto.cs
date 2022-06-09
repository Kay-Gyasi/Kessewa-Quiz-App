using Kessewa.Quiz.Domain.Entities;
using Kessewa.Quiz.Domain.Enums;

namespace Kessewa.Quiz.Processors.Dtos
{
    public class StudentDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public LevelType Level { get; set; }
        public UserDto User { get; set; }
    }
}