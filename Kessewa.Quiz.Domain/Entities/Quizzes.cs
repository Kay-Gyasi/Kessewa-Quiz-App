using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Kessewa.Quiz.Domain.Entities.Base;

namespace Kessewa.Quiz.Domain.Entities
{
    public class Quizzes : ClassBase
    {
        private Quizzes() { }

        private Quizzes(string name, int courseId)
        {
            Name = name;
            CourseId = courseId;
        }

        public static Quizzes Create(string name, int courseId)
        {
            return new Quizzes(name, courseId);
        }

        public Quizzes WithCourseId(int courseId)
        {
            CourseId = courseId;
            return this;
        }

        public Quizzes WithName(string name)
        {
            Name = name;
            return this;
        }

        public Quizzes ToBeTakenOn(DateTime date)
        {
            DateToBeTaken = date;
            return this;
        }

        public Quizzes ToBeTakenAt(DateTime time)
        {
            TimeToBeTaken = time;
            return this;
        }

        public Quizzes WithDuration(int duration)
        {
            Duration = duration;
            return this;
        }

        public Quizzes ForCourse(Courses course)
        {
            Course = course;
            return this;
        }

        public int CourseId { get; private set; }
        public string Name { get; private set; }
        public DateTime DateToBeTaken { get; private set; }
        public DateTime TimeToBeTaken { get; private set; }
        public int Duration { get; private set; }
        public Courses Course { get; private set; }

        private readonly HashSet<Questions> _questions = new HashSet<Questions>();
        public IReadOnlyList<Questions> Questions => _questions.ToList().AsReadOnly();
        private readonly HashSet<Submissions> _submissions = new HashSet<Submissions>();
        public IReadOnlyList<Submissions> Submissions => _submissions.ToList().AsReadOnly();
    }
}