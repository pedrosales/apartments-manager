using System;

namespace ApartmentsManager.Domain.Commands.Results
{
    public class ResidentCommandResult
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string User { get; set; }
    }
}