using System;
using System.Collections.Generic;
using System.Reflection;
using Kessewa.Quiz.Domain.Entities;

namespace Kessewa.Quiz.Processors.Dtos
{
    public class QuizDto
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Name { get; set; }
        public DateTime DateToBeTaken { get; set; }
        public DateTime TimeToBeTaken { get; set; }
        public int Duration { get; set; }
        public CourseDto Course { get; set; }

        public List<QuestionDto> Questions { get; set; }
        public List<SubmissionDto> Submissions { get; set; }
    }
}