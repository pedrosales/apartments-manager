using System.Collections.Generic;
using ApartmentsManager.Domain.Commands;
using ApartmentsManager.Domain.Entities;
using ApartmentsManager.Domain.Handlers;
using ApartmentsManager.Domain.Queries.Results;
using ApartmentsManager.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentsManager.Api.Controllers
{
    [ApiController]
    [Route("v1/residents")]
    public class ResidentController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public GenericCommandResult Post(
            [FromBody] CreateResidentCommand command,
            [FromServices] ResidentHandler handler
        )
        {
            command.User = "Pedro Ivo";
            var result = (GenericCommandResult)handler.Handle(command);
            return result;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Resident> GetAll(
            [FromServices] IResidentRepository repository
        )
        {
            var user = "Pedro Ivo";
            return repository.GetAll(user);
        }
    }
}