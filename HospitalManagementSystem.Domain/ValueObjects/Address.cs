namespace HospitalManagementSystem.Domain.ValueObjects
{
    public sealed class Address : ValueObject
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Governorate { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }

        public string FullAddress => $"{Street}, {City}, {Governorate},{Country}, {PostalCode}";

        private Address()
        {

        }

        public Address(string street, string city, string governorate, string country, string postalCode)
        {
            Street = street;
            City = city;
            Governorate = governorate;
            Country = country;
            PostalCode = postalCode;
        }


        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return City;
            yield return Governorate;
            yield return Country;
            yield return PostalCode;
        }
    }
}