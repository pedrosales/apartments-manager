using ApartmentsManager.Domain.Entities;
using ApartmentsManager.Domain.Queries.Results;
using AutoMapper;

namespace ApartmentsManager.Api.Mappings
{
    public class ResidentEntityProfile : Profile
    {
        public ResidentEntityProfile()
        {
            CreateMap<Resident, GetResidentQueryResult>();
        }
    }
}