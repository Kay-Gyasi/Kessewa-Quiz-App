using System.Collections.Generic;
using Kessewa.Quiz.Domain.ValueObjects.Base;

namespace Kessewa.Quiz.Domain.ValueObjects
{
    public class Choices : ValueObject
    {
        private Choices() { }

        private Choices(int questionId)
        {
            QuestionId = questionId;
        }

        public static Choices Create(int questionId)
        {
            return new Choices(questionId);
        }

        public Choices WithAnswer(string answer)
        {
            Answer = answer;
            return this;
        }

        
        public int QuestionId { get; }
        public string Answer { get; private set; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return QuestionId;
            yield return Answer;
        }
    }
}