using System;

namespace Kessewa.Quiz.Processors.ExceptionHandlers
{
    public class RepositoryNotRegisteredException : Exception
    {
        public RepositoryNotRegisteredException(string message) : base(message)
        {
        }

        public RepositoryNotRegisteredException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public RepositoryNotRegisteredException()
        {
        }
    }
}