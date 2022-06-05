using System.Collections.Generic;
using Kessewa.Quiz.Domain.Entities;
using Kessewa.Quiz.Domain.ValueObjects;

namespace Kessewa.Quiz.Processors.Dtos
{
    public class QuestionDto
    {
        public int QuizId { get; set; }
        public double MarksAllocated { get; set; }
        public Question Question { get; set; }
        public List<Answer> Options { get; set; }
        public QuizDto Quiz { get; set; }

    }
}