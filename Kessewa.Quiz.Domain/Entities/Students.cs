using Kessewa.Quiz.Domain.Entities.Base;
using Kessewa.Quiz.Domain.Enums;

namespace Kessewa.Quiz.Domain.Entities
{
    public class Students : ClassBase
    {
        public int UserId { get; private set; }
        public int DepartmentId { get; private set; }
        public LevelType Level { get; private set; }
        public Users User { get; private set; }
        public Departments Department { get; private set; }
        
        private Students() { }

        private Students(int userId, int departmentId)
        {
            UserId = userId;
            DepartmentId = departmentId;
        }

        public static Students Create(int userId, int departmentId)
        {
            return new Students(userId, departmentId);
        }

        public Students WithUserId(int userId)
        {
            UserId = userId;
            return this;
        }

        public Students WithDepartmentId(int departmentId)
        {
            DepartmentId = departmentId;
            return this;
        }

        public Students AtLevel(LevelType level)
        {
            Level = level;
            return this;
        }

        public Students ForUser(Users user)
        {
            User = user;
            return this;
        }

        public Students ForDepartment(Departments department)
        {
            Department = department;
            return this;
        }
    }
}