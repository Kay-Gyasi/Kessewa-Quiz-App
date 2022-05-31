using System.Collections.Generic;
using Kessewa.Quiz.Domain.ValueObjects.Base;

namespace Kessewa.Quiz.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        private Address() { }
        private Address(string city, string street)
        {
            City = city;
            Street = street;
        }

        public static Address Create(string city, string street)
        {
            return new Address(city, street);
        }

        public string Street { get; private set; }
        public string ZipCode { get; private set; }
        public string City { get; private set; }

        public Address WithStreet(string street)
        {
            Street = street;
            return this;
        }

        public Address WithZipCode(string zipCode)
        {
            ZipCode = zipCode;
            return this;
        }

        public Address WithCity(string city)
        {
            City = city;
            return this;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return ZipCode;
            yield return City;
        }
    }
}