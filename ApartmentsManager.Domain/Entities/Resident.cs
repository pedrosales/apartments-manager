using System;

namespace ApartmentsManager.Domain.Entities
{
    public class Resident : Entity
    {
        public Resident(string name, DateTime birthDate, string phone, string cpf, string email, string user)
        {
            Name = name;
            BirthDate = birthDate;
            Phone = phone;
            Cpf = cpf;
            Email = email;
            User = user;
        }

        public string Name { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Phone { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
        public string User { get; private set; }

        public override string ToString()
        {
            return Name;
        }
    }
}