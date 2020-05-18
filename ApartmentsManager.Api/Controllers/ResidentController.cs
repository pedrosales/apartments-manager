using System.Collections.Generic;
using ApartmentsManager.Domain.Commands;
using ApartmentsManager.Domain.Entities;
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
            command.User = "Pedro Ivo";
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
            var user = "Pedro Ivo";
            var result = repository.GetAll(user);
            return mapper.Map<List<GetResidentQueryResult>>(result);
        }
    }
}