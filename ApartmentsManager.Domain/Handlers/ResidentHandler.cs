using ApartmentsManager.Domain.Commands;
using ApartmentsManager.Domain.Commands.Contracts;
using ApartmentsManager.Domain.Entities;
using ApartmentsManager.Domain.Handlers.Contracts;
using ApartmentsManager.Domain.Repositories;
using Flunt.Notifications;

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
            var resident = new Resident(command.Name, command.BirthDate, command.Phone, command.CPF, command.Email, command.User);

            // Salva morador
            _repository.Create(resident);

            return new GenericCommandResult(true, "Morador salvo com sucesso!", resident);
        }
    }
}