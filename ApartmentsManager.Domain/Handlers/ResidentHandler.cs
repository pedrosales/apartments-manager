using System;
using ApartmentsManager.Domain.Commands.Contracts;
using ApartmentsManager.Domain.Entities;
using ApartmentsManager.Domain.Handlers.Contracts;
using ApartmentsManager.Domain.Repositories;
using Flunt.Notifications;
using ApartmentsManager.Domain.Commands.Results;
using ApartmentsManager.Domain.Commands.Requests.Residents;

namespace ApartmentsManager.Domain.Handlers
{
    public class ResidentHandler : Notifiable,
        IHandler<CreateResidentCommand>,
        IHandler<UpdateResidentCommand>,
        IHandler<InactivateResidentCommand>,
        IHandler<ActivateResidentCommand>
    {
        private readonly IResidentRepository _repository;

        public ResidentHandler(IResidentRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateResidentCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, erro ao cadastrar morador.", command.Notifications);

            // Cria morador
            var resident = new Resident(command.Name, command.BirthDate, command.Phone, command.Cpf, command.Email, command.User);

            try
            {
                // Salva morador
                _repository.Create(resident);
            }
            catch (Exception ex)
            {
                return new GenericCommandResult(false, "Erro inesperado!", ex.Message);
            }

            var residentResult = new ResidentCommandResult
            {
                Name = resident.Name,
                BirthDate = resident.BirthDate,
                Cpf = resident.Cpf,
                Email = resident.Email,
                Phone = resident.Phone,
                User = resident.User
            };
            return new GenericCommandResult(true, "Morador salvo com sucesso!", residentResult);
        }

        public ICommandResult Handle(UpdateResidentCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, erro ao atualizar morador.", command.Notifications);

            // Cria morador
            var resident = _repository.GetById(command.Id, command.User);

            if (resident == null)
                return new GenericCommandResult(false, "Ops, erro ao atualizar morador.", command.Id);

            resident.Update(command.Name, command.BirthDate, command.Phone, command.Email);

            try
            {
                // Salva morador
                _repository.Update(resident);
            }
            catch (Exception ex)
            {
                return new GenericCommandResult(false, "Erro inesperado!", ex.Message);
            }

            var residentResult = new ResidentCommandResult
            {
                Name = resident.Name,
                BirthDate = resident.BirthDate,
                Cpf = resident.Cpf,
                Email = resident.Email,
                Phone = resident.Phone,
                User = resident.User
            };
            return new GenericCommandResult(true, "Morador salvo com sucesso!", residentResult);
        }

        public ICommandResult Handle(InactivateResidentCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, erro ao inativar morador.", command.Notifications);

            // Hidrata morador
            var resident = _repository.GetById(command.Id, command.User);

            if (resident == null)
                return new GenericCommandResult(false, "Ops, erro ao inativar morador.", command.Id);

            resident.Inactivate();

            try
            {
                // Atualiza morador
                _repository.Update(resident);
            }
            catch (Exception ex)
            {
                return new GenericCommandResult(false, "Erro inesperado!", ex.Message);
            }

            return new GenericCommandResult(true, "Morador inativado com sucesso!", null);
        }

        public ICommandResult Handle(ActivateResidentCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, erro ao ativar morador.", command.Notifications);

            // Hidrata morador
            var resident = _repository.GetById(command.Id, command.User);

            if (resident == null)
                return new GenericCommandResult(false, "Ops, erro ao ativar morador.", command.Id);

            resident.Activate();

            try
            {
                // Atualiza morador
                _repository.Update(resident);
            }
            catch (Exception ex)
            {
                return new GenericCommandResult(false, "Erro inesperado!", ex.Message);
            }

            return new GenericCommandResult(true, "Morador ativado com sucesso!", null);
        }
    }
}