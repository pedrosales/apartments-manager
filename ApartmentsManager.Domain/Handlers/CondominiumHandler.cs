using System;
using ApartmentsManager.Domain.Commands.Contracts;
using ApartmentsManager.Domain.Commands.Requests.Condominiums;
using ApartmentsManager.Domain.Commands.Results;
using ApartmentsManager.Domain.Entities;
using ApartmentsManager.Domain.Handlers.Contracts;
using ApartmentsManager.Domain.Repositories;
using Flunt.Notifications;

namespace ApartmentsManager.Domain.Handlers
{
    public class CondominiumHandler : Notifiable,
        IHandler<CreateCondominiumCommand>,
        IHandler<UpdateCondominiumCommand>,
        IHandler<InactivateCondominiumCommand>,
        IHandler<ActivateCondominiumCommand>,
        IHandler<AddApartmentCommand>
    {
        private readonly ICondominiumRepository _repository;
        private readonly IApartmentRepository _apartmentRepository;

        public CondominiumHandler(ICondominiumRepository repository, IApartmentRepository apartmentRepository)
        {
            _repository = repository;
            _apartmentRepository = apartmentRepository;
        }
        public ICommandResult Handle(CreateCondominiumCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, erro ao cadastrar condomínio.", command.Notifications);

            // Cria condomínio
            var condominium = new Condominium(command.Name, command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode, command.User);

            try
            {
                // Salva condomínio
                _repository.Create(condominium);
            }
            catch (Exception ex)
            {
                return new GenericCommandResult(false, "Erro inesperado!", ex.Message);
            }

            var condominiumResult = new CondominiumCommandResult
            {
                City = condominium.City,
                Country = condominium.Country,
                Name = condominium.Name,
                Neighborhood = condominium.Neighborhood,
                Number = condominium.Number,
                State = condominium.State,
                Street = condominium.Street
            };

            return new GenericCommandResult(true, "Condomínio salvo com sucesso!", condominiumResult);
        }

        public ICommandResult Handle(UpdateCondominiumCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, erro ao atualizar condomínio.", command.Notifications);

            // Hidrata condomínio
            var condominium = _repository.GetById(command.Id, command.User);

            if (condominium == null)
                return new GenericCommandResult(false, "Ops, erro ao atualizar condomínio.", command.Id);

            condominium.Update(command.Name, command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);

            try
            {
                // Atualiza Condomínio
                _repository.Update(condominium);
            }
            catch (Exception ex)
            {
                return new GenericCommandResult(false, "Erro inesperado!", ex.Message);
            }

            var condominiumResult = new CondominiumCommandResult
            {
                City = condominium.City,
                Country = condominium.Country,
                Name = condominium.Name,
                Neighborhood = condominium.Neighborhood,
                Number = condominium.Number,
                State = condominium.State,
                Street = condominium.Street
            };

            return new GenericCommandResult(true, "Condomínio atualizado com sucesso!", condominiumResult);
        }

        public ICommandResult Handle(InactivateCondominiumCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, erro ao inativar condomínio.", command.Notifications);

            // Hidrata condomínio
            var condominium = _repository.GetById(command.Id, command.User);

            if (condominium == null)
                return new GenericCommandResult(false, "Ops, erro ao inativar condomínio.", command.Id);

            condominium.Inactivate();

            try
            {
                // Atualiza morador
                _repository.Update(condominium);
            }
            catch (Exception ex)
            {
                return new GenericCommandResult(false, "Erro inesperado!", ex.Message);
            }

            return new GenericCommandResult(true, "Condomínio inativado com sucesso!", null);
        }

        public ICommandResult Handle(ActivateCondominiumCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, erro ao ativar condomínio.", command.Notifications);

            // Hidrata condomínio
            var condominium = _repository.GetById(command.Id, command.User);

            if (condominium == null)
                return new GenericCommandResult(false, "Ops, erro ao ativar condomínio.", command.Id);

            condominium.Activate();

            try
            {
                // Atualiza morador
                _repository.Update(condominium);
            }
            catch (Exception ex)
            {
                return new GenericCommandResult(false, "Erro inesperado!", ex.Message);
            }

            return new GenericCommandResult(true, "Condomínio ativado com sucesso!", null);
        }

        public ICommandResult Handle(AddApartmentCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, erro ao adicionar apartamento ao condomínio.", command.Notifications);

            // Recupera apartamento
            var apartment = _apartmentRepository.GetById(command.ApartmentId, command.User);
            if (apartment == null)
                return new GenericCommandResult(false, "Ops, erro ao adicionar apartamento ao condomínio.", command.ApartmentId);

            // Recupera condomínio
            var condominium = _repository.GetById(command.Id, command.User);
            if (condominium == null)
                return new GenericCommandResult(false, "Ops, erro ao adicionar apartamento ao condomínio.", command.Id);

            condominium.AddApartment(apartment);

            try
            {
                // Salva condomínio
                _repository.Update(condominium);
            }
            catch (Exception ex)
            {
                return new GenericCommandResult(false, "Erro inesperado!", ex.Message);
            }

            var condominiumResult = new CondominiumCommandResult
            {
                City = condominium.City,
                Country = condominium.Country,
                Name = condominium.Name,
                Neighborhood = condominium.Neighborhood,
                Number = condominium.Number,
                State = condominium.State,
                Street = condominium.Street
            };

            return new GenericCommandResult(true, "Condomínio salvo com sucesso!", condominiumResult);
        }
    }
}