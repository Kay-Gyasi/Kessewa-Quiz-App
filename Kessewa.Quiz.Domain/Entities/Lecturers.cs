﻿using System.Collections.Generic;
using System.Linq;
using Kessewa.Quiz.Domain.Entities.Base;
using Kessewa.Quiz.Domain.Enums;

namespace Kessewa.Quiz.Domain.Entities
{
    public class Lecturers : ClassBase
    {

        public int UserId { get; private set; }
        public LecturerType Type { get; private set; }
        public Users User { get; private set; }

        private readonly HashSet<Courses> courses = new HashSet<Courses>();
        public IReadOnlyList<Courses> Courses => courses.ToList().AsReadOnly();        

        
        private Lecturers() { }

        private Lecturers(int userId, LecturerType type)
        {
            UserId = userId;
            Type = type;
        }

        public static Lecturers Create(int userId, LecturerType type)
        {
            return new Lecturers(userId, type);
        }

        public Lecturers OfType(LecturerType type)
        {
            Type = type;
            return this;
        }

        public Lecturers ForUser(Users user)
        {
            User = user;
            return this;
        }
        
        
    }
}