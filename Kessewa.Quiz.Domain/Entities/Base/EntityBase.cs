using System;

namespace Kessewa.Quiz.Domain.Entities.Base
{
    public class EntityBase
    {
        // TODO:: Write processors
        // TODO:: Change types in migration file (nvarchar(max))
        // TODO:: Rest Client
        // TODO:: Mediatr
        // TODO:: Integration tests
        
        public int Id { get; set; }
        public DateTime DateCreated { get; private set; }
        public DateTime DateModified { get; private set; }
        // Entity Status (for soft delete)
    }
}
