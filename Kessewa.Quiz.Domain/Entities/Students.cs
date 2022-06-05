using Kessewa.Quiz.Domain.Entities.Base;
using Kessewa.Quiz.Domain.Enums;

namespace Kessewa.Quiz.Domain.Entities
{
    public class Students : EntityBase
    {
        public int UserId { get; private set; }
        public LevelType Level { get; private set; }
        public Users User { get; private set; }
        
        private Students() { }

        private Students(int userId, int departmentId)
        {
            UserId = userId;
        }

        public static Students Create(int userId, int departmentId)
        {
            return new Students(userId, departmentId);
        }

        public Students SetId(int id)
        {
            Id = id;
            return this;
        }

        public Students WithUserId(int userId)
        {
            UserId = userId;
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
    }
}