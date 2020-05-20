using System;
using System.Collections.Generic;

namespace ApartmentsManager.Domain.Queries.Results
{
    public class GetApartmentQueryResult
    {
        public Guid Id { get; set; }
        public string Condominium { get; set; }
        public int Number { get; set; }
        public string Block { get; set; }
        public IEnumerable<GetResidentQueryResult> Residents { get; set; }
    }
}