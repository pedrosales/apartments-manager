using System;
using ApartmentsManager.Domain.Commands.Requests;
using ApartmentsManager.Domain.Commands.Contracts;
using ApartmentsManager.Domain.Entities;
using ApartmentsManager.Domain.Handlers.Contracts;
using ApartmentsManager.Domain.Repositories;
using Flunt.Notifications;
using ApartmentsManager.Domain.Commands.Results;

namespace ApartmentsManager.Domain.Handlers
{
    public class ResidentHandler : Notifiable, IHandler<CreateResidentCommand>
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

            var residentResult = new CreateResidentCommandResult
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
    }
}