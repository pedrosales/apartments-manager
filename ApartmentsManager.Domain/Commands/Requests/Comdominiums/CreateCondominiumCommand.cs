using ApartmentsManager.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace ApartmentsManager.Domain.Commands.Requests.Condominiums
{
    public class CreateCondominiumCommand : Notifiable, ICommand
    {
        public CreateCondominiumCommand() { }
        public CreateCondominiumCommand(string name, string street, int number, string neighborhood, string city, string state, string country, string zipCode, string user)
        {
            Name = name;
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
            User = user;
        }

        public string Name { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string User { get; set; }
        public void Validate()
        {
            AddNotifications(
              new Contract()
              .Requires()
              .HasMinLen(Name, 3, "Name", "Nome inválido")
              .HasMinLen(Street, 3, "Street", "Endereço inválido")
              .IsGreaterThan(Number, 0, "Number", "Número inválido")
              .HasMinLen(Neighborhood, 3, "Neighborhood", "Bairro inválido")
              .HasMinLen(City, 3, "City", "Cidade inválida")
              .HasLen(State, 2, "State", "Estado deve conter 2 caracteres")
              .HasMinLen(Country, 3, "Country", "País inválido")
              .HasLen(ZipCode, 8, "ZipCode", "CEP inválido")
              .HasMinLen(User, 6, "User", "Usuário inválido")
            );
        }
    }
}