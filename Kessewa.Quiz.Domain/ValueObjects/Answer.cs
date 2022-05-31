using System.Collections.Generic;
using Kessewa.Quiz.Domain.ValueObjects.Base;

namespace Kessewa.Quiz.Domain.ValueObjects
{
    public class Answer : ValueObject
    {
        
        private Answer()
        {
        }

        public int Id { get; private set; }
        public string Text { get; private set; }
        public bool IsCorrectt { get; private set; }

        public Answer SetId(int id)
        {
            Id = id;
            return this;
        }
        public static Answer Create()
        {
            return new Answer();
        }
        public Answer WithText(string answer)
        {
            Text = answer;
            return this;
        }

        public Answer IsCorrect(bool isCorrect)
        {
            IsCorrectt = isCorrect;
            return this;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Text;
            yield return IsCorrectt;
        }
    }
}