using System;

namespace Kessewa.Quiz.Domain.Entities.Base
{
    public class EntityBase
    {
        // TODO:: Add docker support
        // TODO:: Build a leaderboard for the top 10 players
        // TODO:: Change types in migration file (nvarchar(max))
        // TODO:: Rest Client
        // TODO:: Integration tests (using a sql server docker instance)
        // TODO:: Move shared classes and interfaces to their corresponding shared libraries

        public int Id { get; set; }
        public DateTime DateCreated { get; private set; }
        public DateTime DateModified { get; private set; }
        // Entity Status (for soft delete)
    }
}
