using System;

namespace Kessewa.Quiz.Domain.Entities.Base
{
    public class EntityBase
    {
        // TODO:: Loggers
        // TODO:: Work on seeding 
        // TODO:: Work on repositories (GetPage, GetSearchCondition, SoftDelete) 
        // TODO:: Work on commands, dtos, pageDtos
        // TODO:: Create custom exception handlers in a shared project
        // TODO:: AutoMapper
        // TODO:: Rest Client
        // TODO:: Mediatr
        // TODO:: Integration tests
        
        public int Id { get; set; }
        public DateTime DateCreated { get; private set; }
        public DateTime DateModified { get; private set; }
        // RowStatus (for soft delete)
    }
}
