using System;
using ApartmentsManager.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace ApartmentsManager.Domain.Commands.Requests.Condominiums
{
    public class AddApartmentCommand : Notifiable, ICommand
    {
        public Guid ApartmentId { get; set; }
        public Guid Id { get; set; }
        public string User { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNullOrEmpty(ApartmentId.ToString(), "ApartmentId", "Informe um apartamento")
                .IsNotNullOrEmpty(Id.ToString(), "Id", "Informe um condomínio")
                .HasMinLen(User, 6, "User", "Usuário Inválido")
            );
        }
    }
}