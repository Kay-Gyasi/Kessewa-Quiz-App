using System;
using System.Collections.Generic;
using System.Linq;
using Kessewa.Quiz.Domain.Entities.Base;
using Kessewa.Quiz.Domain.ValueObjects;

namespace Kessewa.Quiz.Domain.Entities
{
    public class Submissions : ClassBase
    {
        public int QuizId { get; private set; }
        public int StudentId { get; private set; }
        public DateTime TimeSubmitted { get; private set; }
        
        private readonly HashSet<Choices> choices = new HashSet<Choices>();
        public IReadOnlyList<Choices> Choices => choices.ToList().AsReadOnly();
    }
}