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
        public Quizzes Quiz { get; private set; }
        public HashSet<Answer> Options { get; private set; } = new HashSet<Answer>();        
        
        private Questions() { }

        private Questions(int quizId)
        {
            QuizId = quizId;
        }

        public static Questions Create(int quizId)
        {
            return new Questions(quizId);
        }

        public Questions WithQuizId(int quizId)
        {
            QuizId = quizId;
            return this;
        }

        public Questions HasMarks(double marks)
        {
            MarksAllocated = marks;
            return this;
        }

        public Questions WithQuestion(Question question)
        {
            Question = question;
            return this;
        }

        public Questions WithAnswer(Answer answer)
        {
            Answer = answer;
            return this;
        }

        public Questions ForQuiz(Quizzes quiz)
        {
            Quiz = quiz;
            return this;
        }

        public Questions WithOptions(IEnumerable<Answer> options)
        {
            Options = options.ToHashSet();
            return this;
        }

    }
}