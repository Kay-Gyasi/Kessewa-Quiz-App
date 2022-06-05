using Kessewa.Quiz.Domain.ValueObjects;

namespace Kessewa.Quiz.Processors.Dtos.PageDtos
{
    public class QuestionPageDto
    {
        public double MarksAllocated { get; set; }
        public Question Question { get; set; }
        public QuizDto Quiz { get; set; }
    }
}