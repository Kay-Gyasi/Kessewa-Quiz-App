using Kessewa.Quiz.Domain.Enums;

namespace Kessewa.Quiz.Processors.Dtos.PageDtos
{
    public class StudentPageDto
    {
        public LevelType Level { get; set; }
        public UserDto User { get; set; }
    }
}