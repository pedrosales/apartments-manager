

using ApartmentsManager.Domain.Entities;
using ApartmentsManager.Domain.Queries.Results;
using AutoMapper;

namespace ApartmentsManager.Api.Mappings
{
    public class ApartmentEntityProfile : Profile
    {
        public ApartmentEntityProfile()
        {
            CreateMap<Apartment, GetApartmentQueryResult>()
                .ForMember(x => x.Condominium, opts => opts.MapFrom(src => src.Condominium.Name));
        }
    }
}