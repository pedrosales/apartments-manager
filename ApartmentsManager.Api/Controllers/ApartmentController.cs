using System.Collections.Generic;
using ApartmentsManager.Domain.Commands.Requests.Apartments;
using ApartmentsManager.Domain.Commands.Results;
using ApartmentsManager.Domain.Handlers;
using ApartmentsManager.Domain.Queries.Results;
using ApartmentsManager.Domain.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentsManager.Api.Controllers
{
    [ApiController]
    [Route("v1/apartments")]
    public class ApartmentController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public GenericCommandResult Post(
            [FromBody] CreateApartmentCommand command,
            [FromServices] ApartmentHandler handler
        )
        {
            command.User = "Pedro Ivo";
            var result = (GenericCommandResult)handler.Handle(command);
            return result;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<GetApartmentQueryResult> GetAll(
            [FromServices] IApartmentRepository repository,
            [FromServices] IMapper mapper
        )
        {
            var user = "Pedro Ivo";
            var result = repository.GetAll(user);
            return mapper.Map<List<GetApartmentQueryResult>>(result);
        }
    }
}