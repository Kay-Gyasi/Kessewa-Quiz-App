using System.Collections.Generic;
using Kessewa.Quiz.Domain.ValueObjects;

namespace Kessewa.Quiz.Processors.Commands
{
    public class QuestionCommand
    {
        public int QuizId { get; set; }
        public double MarksAllocated { get; set; }
        public Question Question { get; set; }
        public List<Answer> Options { get; set; }
    }
}