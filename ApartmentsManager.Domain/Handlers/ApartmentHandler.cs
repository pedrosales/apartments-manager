using System;
using ApartmentsManager.Domain.Commands.Contracts;
using ApartmentsManager.Domain.Commands.Requests.Apartments;
using ApartmentsManager.Domain.Commands.Results;
using ApartmentsManager.Domain.Entities;
using ApartmentsManager.Domain.Handlers.Contracts;
using ApartmentsManager.Domain.Repositories;
using Flunt.Notifications;

namespace ApartmentsManager.Domain.Handlers
{
    public class ApartmentHandler : Notifiable,
        IHandler<CreateApartmentCommand>
    {
        private readonly IApartmentRepository _repository;
        private readonly ICondominiumRepository _condominiumRepository;

        public ApartmentHandler(IApartmentRepository repository, ICondominiumRepository condominiumRepository)
        {
            _repository = repository;
            _condominiumRepository = condominiumRepository;
        }

        public ICommandResult Handle(CreateApartmentCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, erro ao cadastrar apartamento.", command.Notifications);

            // Recupera condomínio
            // var condominium = _condominiumRepository.GetById(command.CondominiumId, command.User);
            // if (condominium == null)
            //     return new GenericCommandResult(false, "Ops, erro ao cadastrar apartamento.", "Condomínio não encontrado");

            // Cria apartamento
            var apartment = new Apartment(command.Number, command.Block, command.User);

            try
            {
                // Salva morador
                _repository.Create(apartment);
            }
            catch (Exception ex)
            {
                return new GenericCommandResult(false, "Erro inesperado!", ex.Message);
            }

            var apartmentResult = new ApartmentCommandResult
            {
                Block = apartment.Block,
                //Condominium = apartment.Condominium.Name,
                Number = apartment.Number,
                User = apartment.User
            };

            return new GenericCommandResult(true, "Apartamento salvo com sucesso!", apartmentResult);
        }
    }
}