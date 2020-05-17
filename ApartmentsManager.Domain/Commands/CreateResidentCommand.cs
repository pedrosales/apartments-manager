using System;
using ApartmentsManager.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace ApartmentsManager.Domain.Commands
{
    public class CreateResidentCommand : Notifiable, ICommand
    {
        public CreateResidentCommand() { }

        public CreateResidentCommand(string name, DateTime birthDate, string phone, string cpf, string email)
        {
            Name = name;
            BirthDate = birthDate;
            Phone = phone;
            CPF = cpf;
            Email = email;
        }

        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Name, 3, "Name", "Nome deve conter pelo menos 3 caracteres")
                    .IsGreaterThan(BirthDate, DateTime.MinValue, "BirthDate", "Data de nascimento é inválida")
                    .IsLowerThan(BirthDate, DateTime.MaxValue, "BirthDate", "Data de nascimento é inválida")
                    .HasMinLen(Phone, 11, "Phone", "Número de telefone inválido")
                    .HasMinLen(CPF, 11, "CPF", "CPF inválido")
                    .IsEmail(Email, "Email", "Email inválido")
            );
        }
    }
}