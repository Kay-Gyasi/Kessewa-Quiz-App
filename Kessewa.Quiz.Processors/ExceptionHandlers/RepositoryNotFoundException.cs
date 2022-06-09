using System;

namespace Kessewa.Quiz.Processors.ExceptionHandlers
{
    public class RepositoryNotFoundException : Exception
    {
        public RepositoryNotFoundException(string message) : base(message)
        {
        }

        public RepositoryNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public RepositoryNotFoundException()
        {
        }
    }
}