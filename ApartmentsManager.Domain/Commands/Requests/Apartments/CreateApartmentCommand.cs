using System;
using System.Collections.Generic;
using ApartmentsManager.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace ApartmentsManager.Domain.Commands.Requests.Apartments
{
    public class CreateApartmentCommand : Notifiable, ICommand
    {
        public CreateApartmentCommand() { }
        public CreateApartmentCommand(Guid condominiumId, int number, string block, List<Guid> residents, string user)
        {
            CondominiumId = condominiumId;
            Number = number;
            Block = block;
            User = user;
            Residents = residents;
        }

        public Guid? CondominiumId { get; set; }
        public int Number { get; set; }
        public string Block { get; set; }
        public string User { get; set; }
        public List<Guid> Residents { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsGreaterThan(Number, 0, "Number", "É necessário informar um número")
                .HasMinLen(User, 6, "User", "Usuário inválido")
            );
        }
    }
}