using System.Collections.Generic;
using System.Linq;
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
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
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
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            var result = repository.GetAll(user).ToList();
            return mapper.Map<List<GetApartmentQueryResult>>(result);
        }

        [HttpGet]
        [Route("without-condominium")]
        public IEnumerable<GetApartmentQueryResult> GetAllWithoutCondominium(
            [FromServices] IApartmentRepository repository,
            [FromServices] IMapper mapper
        )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            var result = repository.GetAllWithoutCondominium(user).ToList();
            return mapper.Map<List<GetApartmentQueryResult>>(result);
        }
    }
}