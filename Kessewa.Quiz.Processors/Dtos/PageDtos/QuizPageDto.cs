using System;

namespace Kessewa.Quiz.Processors.Dtos.PageDtos
{
    public class QuizPageDto
    {
        public string Name { get; set; }
        public DateTime DateToBeTaken { get; set; }
        public DateTime TimeToBeTaken { get; set; }
        public int Duration { get; set; }
        public CourseDto Course { get; set; }
    }
}