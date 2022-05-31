using System.Collections.Generic;
using Kessewa.Quiz.Domain.ValueObjects.Base;

namespace Kessewa.Quiz.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        private Email()
        {
            
        }
        private Email(string emailAddress)
        {
            EmailAddress = emailAddress;
        }

        public static Email Create(string emailAddress)
        {
            return new Email(emailAddress);
        }
        public string EmailAddress { get; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return EmailAddress;
        }
    }
}