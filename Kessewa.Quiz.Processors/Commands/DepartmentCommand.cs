﻿using Kessewa.Quiz.Domain.ValueObjects;

namespace Kessewa.Quiz.Processors.Commands
{
    public class DepartmentCommand
    {
        public int Id { get; set; }
        public int FacultyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Email Email { get; set; }
        public Phone Phone { get; set; }
        public FacultyCommand Faculty { get; set; }
    }
}