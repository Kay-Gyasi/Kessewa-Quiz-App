using System.Collections.Generic;
using System.Linq;
using Kessewa.Quiz.Domain.Entities.Base;
using Kessewa.Quiz.Domain.ValueObjects;

namespace Kessewa.Quiz.Domain.Entities
{
    public class Questions : ClassBase
    {
        public int QuizId { get; private set; }
        public double MarksAllocated { get; private set; }
        public Question Question { get; private set; }
        public Answer Answer { get; private set; }
        
        private readonly HashSet<Answer> possibleAnswers = new HashSet<Answer>();
        public IReadOnlyList<Answer> PossibleAnswers => possibleAnswers.ToList().AsReadOnly();

    }
}