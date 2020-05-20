

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
            .ForMember(x => x.Residents, opt => opt.MapFrom(re => re.Residents));
        }
    }
}