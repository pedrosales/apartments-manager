using System;
using System.Collections.Generic;
using ApartmentsManager.Domain.Commands.Requests.Condominiums;
using ApartmentsManager.Domain.Commands.Results;
using ApartmentsManager.Domain.Handlers;
using ApartmentsManager.Domain.Queries.Results;
using ApartmentsManager.Domain.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentsManager.Api.Controllers
{
    [ApiController]
    [Route("v1/condominiums")]
    public class CondominiumController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public GenericCommandResult Post(
            [FromBody] CreateCondominiumCommand command,
            [FromServices] CondominiumHandler handler
        )
        {
            command.User = "Pedro Ivo";
            var result = (GenericCommandResult)handler.Handle(command);
            return result;
        }

        [HttpPut]
        [Route("")]
        public GenericCommandResult Put(
            [FromBody] UpdateCondominiumCommand command,
            [FromServices] CondominiumHandler handler
        )
        {
            command.User = "Pedro Ivo";
            var result = (GenericCommandResult)handler.Handle(command);
            return result;
        }

        [HttpPut]
        [Route("add-apartment")]
        public GenericCommandResult AddApartment(
            [FromBody] AddApartmentCommand command,
            [FromServices] CondominiumHandler handler
        )
        {
            command.User = "Pedro Ivo";
            var result = (GenericCommandResult)handler.Handle(command);
            return result;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<GetCondominiumQueryResult> GetAll(
            [FromServices] ICondominiumRepository repository,
            [FromServices] IMapper mapper
        )
        {
            var user = "Pedro Ivo";
            var result = repository.GetAll(user);
            return mapper.Map<List<GetCondominiumQueryResult>>(result);
        }

        [HttpGet]
        [Route("inactive")]
        public IEnumerable<GetCondominiumQueryResult> GetAllInactive(
            [FromServices] ICondominiumRepository repository,
            [FromServices] IMapper mapper
        )
        {
            var user = "Pedro Ivo";
            var result = repository.GetAllInactive(user);
            return mapper.Map<List<GetCondominiumQueryResult>>(result);
        }

        [HttpGet]
        [Route("active")]
        public IEnumerable<GetCondominiumQueryResult> GetAllActive(
           [FromServices] ICondominiumRepository repository,
           [FromServices] IMapper mapper
       )
        {
            var user = "Pedro Ivo";
            var result = repository.GetAllActive(user);
            return mapper.Map<List<GetCondominiumQueryResult>>(result);
        }

        [HttpDelete]
        [Route("inactivate/{id}")]
        public GenericCommandResult Inactivate(
            Guid id,
            [FromServices] CondominiumHandler handler
        )
        {
            var user = "Pedro Ivo";
            var command = new InactivateCondominiumCommand(id, user);
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut]
        [Route("activate/{id}")]
        public GenericCommandResult Activate(
            Guid id,
            [FromServices] CondominiumHandler handler
        )
        {
            var user = "Pedro Ivo";
            var command = new ActivateCondominiumCommand(id, user);
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}