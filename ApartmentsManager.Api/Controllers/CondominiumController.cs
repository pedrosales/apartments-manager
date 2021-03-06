using System;
using System.Collections.Generic;
using System.Linq;
using ApartmentsManager.Domain.Commands.Requests.Condominiums;
using ApartmentsManager.Domain.Commands.Results;
using ApartmentsManager.Domain.Handlers;
using ApartmentsManager.Domain.Queries.Results;
using ApartmentsManager.Domain.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentsManager.Api.Controllers
{
    [ApiController]
    [Route("v1/condominiums")]
    [Authorize]
    public class CondominiumController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public GenericCommandResult Post(
            [FromBody] CreateCondominiumCommand command,
            [FromServices] CondominiumHandler handler
        )
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
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
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
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
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
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
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            var result = repository.GetAll(user).ToList();
            var map = mapper.Map<List<GetCondominiumQueryResult>>(result);
            return map;
        }

        [HttpGet]
        [Route("inactive")]
        public IEnumerable<GetCondominiumQueryResult> GetAllInactive(
            [FromServices] ICondominiumRepository repository,
            [FromServices] IMapper mapper
        )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
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
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
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
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
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
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            var command = new ActivateCondominiumCommand(id, user);
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}