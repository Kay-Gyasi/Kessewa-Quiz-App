using Kessewa.Quiz.Domain.Enums;
using Kessewa.Quiz.Domain.ValueObjects;

namespace Kessewa.Quiz.Processors.Dtos.PageDtos
{
    public class UserPageDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public UserType Type { get; set; }
        public Email Email { get; set; }
        public Phone Phone { get; set; }
        public Address Address { get; set; }

    }
}