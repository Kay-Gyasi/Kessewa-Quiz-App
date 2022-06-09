using System.Collections.Generic;
using System.Reflection;
using Kessewa.Quiz.Domain.Entities;
using Kessewa.Quiz.Domain.Enums;
using Kessewa.Quiz.Domain.ValueObjects;

namespace Kessewa.Quiz.Processors.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public UserType Type { get; set; }
        public Email Email { get; set; }
        public Phone Phone { get; set; }
        public Address Address { get; set; }
        public DepartmentDto Department { get; set; }


        public List<LecturerDto> Lecturers { get; set; }
        public List<StudentDto> Students { get; set; }
    }
}