using System;

namespace Kessewa.Quiz.Processors.Dtos.PageDtos
{
    public class SubmissionPageDto
    {
        public DateTime TimeSubmitted { get; set; }
        public QuizDto Quiz { get; set; }
        public StudentDto Student { get; set; }
    }
}