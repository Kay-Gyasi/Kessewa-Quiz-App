using Kessewa.Quiz.Domain.Enums;

namespace Kessewa.Quiz.Processors.Dtos.PageDtos
{
    public class LecturerPageDto
    {
        public int UserId { get; set; }
        public LecturerType Type { get; set; }
        public UserDto User { get; set; }
    }
}