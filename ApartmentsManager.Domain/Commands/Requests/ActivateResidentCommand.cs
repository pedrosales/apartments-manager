using System;
using ApartmentsManager.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace ApartmentsManager.Domain.Commands.Requests
{
    public class ActivateResidentCommand : Notifiable, ICommand
    {
        public ActivateResidentCommand() { }
        public ActivateResidentCommand(Guid id, string user)
        {
            Id = id;
            User = user;
        }

        public Guid Id { get; set; }
        public string User { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(Id.ToString(), "Id", "Id do morador inválido")
                    .HasMinLen(User, 6, "User", "Usuário inválido")
            );
        }
    }
}