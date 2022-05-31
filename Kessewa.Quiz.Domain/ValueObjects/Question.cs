using System.Collections.Generic;
using Kessewa.Quiz.Domain.ValueObjects.Base;

namespace Kessewa.Quiz.Domain.ValueObjects
{
    public class Question : ValueObject
    {
        private Question() { }

        public static Question Create()
        {
            return new Question();
        }

        public Question WithQuestion(string question)
        {
            QuestionText = question;
            return this;
        }

        public Question WithAnswer(string answer)
        {
            Answer = answer;
            return this;
        }
        
        public string QuestionText { get; private set; }
        public string Answer { get; private set; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return QuestionText;
            yield return Answer;
        }
    }
}