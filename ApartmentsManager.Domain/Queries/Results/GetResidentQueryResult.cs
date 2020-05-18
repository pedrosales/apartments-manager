using System;

namespace ApartmentsManager.Domain.Queries.Results
{
    public class GetResidentQueryResult
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
    }
}