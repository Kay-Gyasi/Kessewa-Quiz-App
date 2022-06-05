using System;

namespace Kessewa.Quiz.Processors.ExceptionHandlers
{
    public class InvalidEntityException : Exception
    {
        public InvalidEntityException(string message) : base(message)
        {
        }

        public InvalidEntityException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public InvalidEntityException(){}
    }
}