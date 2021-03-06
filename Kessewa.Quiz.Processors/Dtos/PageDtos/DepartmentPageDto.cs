using Kessewa.Quiz.Domain.ValueObjects;

namespace Kessewa.Quiz.Processors.Dtos.PageDtos
{
    public class DepartmentPageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Email Email { get; set; }
        public Phone Phone { get; set; }
    }
}