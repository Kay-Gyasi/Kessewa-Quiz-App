﻿using System;
using System.Collections.Generic;
using System.Linq;
using Kessewa.Quiz.Domain.Entities.Base;
using Kessewa.Quiz.Domain.ValueObjects;

namespace Kessewa.Quiz.Domain.Entities
{
    public class Submissions : ClassBase
    {
        public int QuizId { get; private set; }
        public int StudentId { get; private set; }
        public DateTime TimeSubmitted { get; private set; }
        public Quizzes Quiz { get; private set; }
        public Students Student { get; private set; }
        public HashSet<Choices> Choices { get; private set; } = new HashSet<Choices>();

        private Submissions() { }

        private Submissions(int quizId, int studentId)
        {
            QuizId = quizId;
            StudentId = studentId;
        }

        public static Submissions Create(int quizId, int studentId)
        {
            return new Submissions(quizId, studentId);
        }

        public Submissions WithQuizId(int quizId)
        {
            QuizId = quizId;
            return this;
        }

        public Submissions WithStudentId(int studentId)
        {
            StudentId = studentId;
            return this;
        }

        public Submissions WasSubmittedAt(DateTime timeSubmitted)
        {
            TimeSubmitted = timeSubmitted;
            return this;
        }

        public Submissions ForQuiz(Quizzes quiz)
        {
            Quiz = quiz;
            return this;
        }

        public Submissions ForStudent(Students student)
        {
            Student = student;
            return this;
        }

        public Submissions WithChoices(IEnumerable<Choices> choices)
        {
            Choices = choices.ToHashSet();
            return this;
        }
    }
}