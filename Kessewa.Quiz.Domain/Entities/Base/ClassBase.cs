using System;

namespace Kessewa.Quiz.Domain.Entities.Base
{
    public class ClassBase
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; private set; }
        public DateTime DateModified { get; private set; }
    }
}
