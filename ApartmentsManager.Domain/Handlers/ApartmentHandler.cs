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
        private readonly IResidentRepository _residentRepository;

        public ApartmentHandler(IApartmentRepository repository, ICondominiumRepository condominiumRepository,
            IResidentRepository residentRepository)
        {
            _repository = repository;
            _condominiumRepository = condominiumRepository;
            _residentRepository = residentRepository;
        }

        public ICommandResult Handle(CreateApartmentCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, erro ao cadastrar apartamento.", command.Notifications);
            try
            {
                // Recupera condomínio
                var condominium = _condominiumRepository.GetById(command.CondominiumId.Value, command.User);
                if (condominium == null)
                    return new GenericCommandResult(false, "Ops, erro ao cadastrar apartamento.", "Condomínio não encontrado");

                // Cria apartamento
                var apartment = new Apartment(condominium, command.Number, command.Block, command.User);

                if (command.Residents.Count > 0)
                {
                    foreach (var resident in command.Residents)
                    {
                        var res = _residentRepository.GetById(resident, command.User);
                        apartment.AddResident(res);
                    }
                }

                // Salva morador
                _repository.Create(apartment);

                var apartmentResult = new ApartmentCommandResult
                {
                    Block = apartment.Block,
                    //Condominium = apartment.Condominium.Name,
                    Number = apartment.Number,
                    User = apartment.User
                };

                return new GenericCommandResult(true, "Apartamento salvo com sucesso!", apartmentResult);
            }
            catch (Exception ex)
            {
                return new GenericCommandResult(false, "Erro inesperado!", ex.Message);
            }
        }
    }
}