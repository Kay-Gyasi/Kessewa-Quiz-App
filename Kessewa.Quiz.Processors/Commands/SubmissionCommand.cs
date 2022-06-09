using System;
using System.Collections.Generic;
using Kessewa.Quiz.Domain.ValueObjects;

namespace Kessewa.Quiz.Processors.Commands
{
    public class SubmissionCommand
    {
        public int Id { get; set; }
        public int QuizId { get; set; }
        public int StudentId { get; set; }
        public DateTime TimeSubmitted { get; set; }
        public QuizCommand Quiz { get; set; }
        public StudentCommand Student { get; set; }
        public List<Choices> Choices { get; set; }
    }
}