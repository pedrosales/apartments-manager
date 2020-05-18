using System;
using ApartmentsManager.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace ApartmentsManager.Domain.Commands.Requests
{
    public class UpdateResidentCommand : Notifiable, ICommand
    {
        public UpdateResidentCommand() { }
        public UpdateResidentCommand(Guid id, string name, DateTime birthDate, string phone, string cpf, string email, string user)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
            Phone = phone;
            Email = email;
            User = user;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string User { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMinLen(Name, 3, "Name", "Nome inválido")
                .HasLen(Phone, 11, "Phone", "Telefone inválido")
                .IsEmail(Email, "Email", "Email inválido")
                .HasMinLen(User, 6, "User", "Usuário invalido")
            );
        }
    }
}