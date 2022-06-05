using System;
using System.Collections.Generic;
using Kessewa.Quiz.Domain.Entities;
using Kessewa.Quiz.Domain.ValueObjects;

namespace Kessewa.Quiz.Processors.Dtos
{
    public class SubmissionDto
    {
        public int QuizId { get; set; }
        public int StudentId { get; set; }
        public DateTime TimeSubmitted { get; set; }
        public QuizDto Quiz { get; set; }
        public StudentDto Student { get; set; }
        public List<Choices> Choices { get; set; }
    }
}