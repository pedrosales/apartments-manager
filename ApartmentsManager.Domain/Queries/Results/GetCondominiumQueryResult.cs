using System;
using System.Collections.Generic;
using ApartmentsManager.Domain.Entities;

namespace ApartmentsManager.Domain.Queries.Results
{
    public class GetCondominiumQueryResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public bool Active { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public IEnumerable<Apartment> Apartmens { get; set; }
    }
}