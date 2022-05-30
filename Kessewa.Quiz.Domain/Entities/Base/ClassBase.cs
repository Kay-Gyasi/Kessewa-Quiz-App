using System;

namespace Kessewa.Quiz.Domain.Entities.Base
{
    public class ClassBase
    {
        // TODO:: Create initialization methods for these in child classes
        // TODO:: Work on configurations
        public int Id { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime DateModified { get; private set; }
    }
}
