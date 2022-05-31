using System.Collections.Generic;
using Kessewa.Quiz.Domain.ValueObjects.Base;

namespace Kessewa.Quiz.Domain.ValueObjects
{
    public class Phone : ValueObject
    {
        private Phone()
        {
            
        }
        private Phone(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        public static Phone Create(string phoneNumber)
        {
            return new Phone(phoneNumber);
        }

        
        public string PhoneNumber { get; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return PhoneNumber;
        }
    }
}