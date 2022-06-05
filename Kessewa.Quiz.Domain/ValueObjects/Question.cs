using System.Collections.Generic;
using Kessewa.Quiz.Domain.ValueObjects.Base;

namespace Kessewa.Quiz.Domain.ValueObjects
{
    public class Question : ValueObject
    {
        public string QuestionText { get; private set; }
        public string Answer { get; private set; }
        
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
        
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return QuestionText;
            yield return Answer;
        }
    }
}