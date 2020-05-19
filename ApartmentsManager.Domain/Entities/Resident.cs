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
            Active = true;
        }

        public string Name { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Phone { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
        public bool Active { get; set; }
        public string User { get; private set; }

        public void UpdateResident(string name, DateTime birthDate, string phone, string email)
        {
            if (!string.IsNullOrEmpty(name) && !Name.Equals(name))
                Name = name;

            if (birthDate != DateTime.MinValue)
                BirthDate = birthDate;

            if (!string.IsNullOrEmpty(phone) && !Phone.Equals(phone))
                Phone = phone;

            if (!string.IsNullOrEmpty(email) && !Email.Equals(phone))
                Email = email;
        }

        public void Inactive()
        {
            Active = false;
        }

        public void Activate()
        {
            Active = true;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}