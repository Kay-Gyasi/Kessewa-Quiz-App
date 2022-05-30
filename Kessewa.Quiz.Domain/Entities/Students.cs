using Kessewa.Quiz.Domain.Entities.Base;
using Kessewa.Quiz.Domain.Enums;

namespace Kessewa.Quiz.Domain.Entities
{
    public class Students : ClassBase
    {
        public int UserId { get; private set; }
        public int DepartmentId { get; private set; }
        public LevelType Level { get; private set; }
    }
}