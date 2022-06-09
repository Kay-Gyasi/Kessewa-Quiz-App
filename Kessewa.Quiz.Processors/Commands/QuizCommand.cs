using System;

namespace Kessewa.Quiz.Processors.Commands
{
    public class QuizCommand
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Name { get; set; }
        public DateTime DateToBeTaken { get; set; }
        public DateTime TimeToBeTaken { get; set; }
        public int Duration { get; set; }
        public CourseCommand Course { get; set; }
    }
}