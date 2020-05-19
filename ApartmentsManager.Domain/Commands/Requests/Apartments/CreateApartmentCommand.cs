using System;
using ApartmentsManager.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace ApartmentsManager.Domain.Commands.Requests.Apartments
{
    public class CreateApartmentCommand : Notifiable, ICommand
    {
        public CreateApartmentCommand() { }
        public CreateApartmentCommand(Guid condominiumId, int number, string block, string user)
        {
            CondominiumId = condominiumId;
            Number = number;
            Block = block;
            User = user;
        }

        public Guid CondominiumId { get; set; }
        public int Number { get; set; }
        public string Block { get; set; }
        public string User { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNullOrEmpty(CondominiumId.ToString(), "CondominiumId", "É necessário informar o condomínio")
                .IsGreaterThan(Number, 0, "Number", "É necessário informar um número")
                .HasMinLen(User, 6, "User", "Usuário inválido")
            );
        }
    }
}