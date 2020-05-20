using System;
using System.Collections.Generic;

namespace ApartmentsManager.Domain.Entities
{
    public class Condominium : Entity
    {
        private readonly IList<Apartment> _apartments;

        public Condominium() { }

        public Condominium(string name, string street, int number, string neighborhood, string city, string state, string country, string zipCode, string user)
        {
            Name = name;
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
            User = user;
            Active = true;
            Created = DateTime.Now;
            _apartments = new List<Apartment>();
        }

        public string Name { get; private set; }
        public string Street { get; private set; }
        public int Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
        public string User { get; private set; }
        public bool Active { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime Updated { get; private set; }
        public ICollection<Apartment> Apartments { get; private set; }

        public void Update(string name, string street, int number, string neighborhood, string city, string state, string country, string zipCode)
        {
            if (!string.IsNullOrEmpty(name) && !Name.Equals(name))
                Name = name;

            if (!string.IsNullOrEmpty(street) && !Street.Equals(street))
                Street = street;

            if (number > 0)
                Number = number;

            if (!string.IsNullOrEmpty(neighborhood) && !Neighborhood.Equals(neighborhood))
                Neighborhood = neighborhood;

            if (!string.IsNullOrEmpty(city) && !City.Equals(city))
                City = city;

            if (!string.IsNullOrEmpty(state) && !State.Equals(state))
                State = state;

            if (!string.IsNullOrEmpty(country) && !Country.Equals(country))
                Country = country;

            if (!string.IsNullOrEmpty(zipCode) && !ZipCode.Equals(zipCode))
                ZipCode = zipCode;

            Updated = DateTime.Now;
        }

        public void Inactivate()
        {
            Active = false;
        }

        public void Activate()
        {
            Active = true;
        }

        public void AddApartment(Apartment apartment)
        {
            if (apartment != null)
                _apartments.Add(apartment);

            Updated = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Street}, {Number}, {Neighborhood} - {City}/{State}";
        }
    }
}