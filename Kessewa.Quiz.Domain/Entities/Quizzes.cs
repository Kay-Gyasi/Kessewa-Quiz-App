using System;
using System.Collections.Generic;
using System.Linq;
using Kessewa.Quiz.Domain.Entities.Base;

namespace Kessewa.Quiz.Domain.Entities
{
    public class Quizzes : ClassBase
    {
        public int CourseId { get; private set; }
        public string Name { get; private set; }
        public DateTime DateToBeTaken { get; private set; }
        public DateTime TimeToBeTaken { get; private set; }

        private readonly HashSet<Questions> questions = new HashSet<Questions>();
        public IReadOnlyList<Questions> Questions => questions.ToList().AsReadOnly();
        private readonly HashSet<Submissions> submissions = new HashSet<Submissions>();
        public IReadOnlyList<Submissions> Submissions => submissions.ToList().AsReadOnly();
    }
}