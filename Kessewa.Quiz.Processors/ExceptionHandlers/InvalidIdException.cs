﻿using System;

namespace Kessewa.Quiz.Processors.ExceptionHandlers
{
    public class InvalidIdException : Exception
    {
        public InvalidIdException(string message) : base(message)
        {
        }

        public InvalidIdException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public InvalidIdException()
        {
        }
    }
}