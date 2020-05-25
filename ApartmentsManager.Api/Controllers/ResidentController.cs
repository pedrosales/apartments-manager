using System;
using System.Collections.Generic;
using System.Linq;
using ApartmentsManager.Domain.Commands.Requests.Residents;
using ApartmentsManager.Domain.Commands.Results;
using ApartmentsManager.Domain.Handlers;
using ApartmentsManager.Domain.Queries.Results;
using ApartmentsManager.Domain.Repositories;
using AutoMapper;
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
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            var result = (GenericCommandResult)handler.Handle(command);
            return result;
        }

        [HttpPut]
        [Route("")]
        public GenericCommandResult Put(
            [FromBody] UpdateResidentCommand command,
            [FromServices] ResidentHandler handler
        )
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            var result = (GenericCommandResult)handler.Handle(command);
            return result;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<GetResidentQueryResult> GetAll(
            [FromServices] IResidentRepository repository,
            [FromServices] IMapper mapper
        )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            var result = repository.GetAll(user);
            return mapper.Map<List<GetResidentQueryResult>>(result);
        }

        [HttpGet]
        [Route("inactive")]
        public IEnumerable<GetResidentQueryResult> GetAllInactive(
            [FromServices] IResidentRepository repository,
            [FromServices] IMapper mapper
        )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            var result = repository.GetAllInactive(user);
            return mapper.Map<List<GetResidentQueryResult>>(result);
        }

        [HttpGet]
        [Route("active")]
        public IEnumerable<GetResidentQueryResult> GetAllActive(
           [FromServices] IResidentRepository repository,
           [FromServices] IMapper mapper
       )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            var result = repository.GetAllActive(user);
            return mapper.Map<List<GetResidentQueryResult>>(result);
        }

        [HttpDelete]
        [Route("inactivate-resident/{id}")]
        public GenericCommandResult Inactivate(
            Guid id,
            [FromServices] ResidentHandler handler
        )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            var command = new InactivateResidentCommand(id, user);
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut]
        [Route("activate-resident/{id}")]
        public GenericCommandResult Delete(
            Guid id,
            [FromServices] ResidentHandler handler
        )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            var command = new ActivateResidentCommand(id, user);
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpGet]
        [Route("apartment/{id}")]
        public IEnumerable<GetResidentQueryResult> GetAllByApartment(
            Guid id,
            [FromServices] IResidentRepository repository,
            [FromServices] IMapper mapper
        )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            var result = repository.GetAllByApartment(user, id);
            return mapper.Map<List<GetResidentQueryResult>>(result);
        }

        [HttpGet]
        [Route("without-apartment")]
        public IEnumerable<GetResidentQueryResult> GetAllWithoutApartment(

            [FromServices] IResidentRepository repository,
            [FromServices] IMapper mapper
        )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            var result = repository.GetAllWithoutApartment(user);
            return mapper.Map<List<GetResidentQueryResult>>(result);
        }
    }
}