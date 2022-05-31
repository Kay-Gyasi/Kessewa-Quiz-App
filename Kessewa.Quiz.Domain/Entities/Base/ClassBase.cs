using System;

namespace Kessewa.Quiz.Domain.Entities.Base
{
    public class ClassBase
    {
        // TODO:: Work on initialization methods for entities (include base properties)
        // TODO:: Work on configurations and seeding
        // TODO:: Work on value objects
        public int Id { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime DateModified { get; private set; }
    }
}
