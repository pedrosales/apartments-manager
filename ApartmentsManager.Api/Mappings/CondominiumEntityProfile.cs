using System.Collections.Generic;
using ApartmentsManager.Domain.Entities;
using ApartmentsManager.Domain.Queries.Results;
using AutoMapper;

namespace ApartmentsManager.Api.Mappings
{
    public class CondominiumEntityProfile : Profile
    {
        public CondominiumEntityProfile()
        {
            CreateMap<Condominium, GetCondominiumQueryResult>()
                .ForMember(x => x.Apartmens, opt => opt.MapFrom(ap => ap.Apartments));
        }
    }
}