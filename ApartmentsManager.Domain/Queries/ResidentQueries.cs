using System;
using System.Linq.Expressions;
using ApartmentsManager.Domain.Entities;

namespace ApartmentsManager.Domain.Queries
{
    public static class ResidentQueries
    {
        public static Expression<Func<Resident, bool>> GetAll(string user)
        {
            return resident => resident.User == user;
        }

        public static Expression<Func<Resident, bool>> GetAllActive(string user)
        {
            return resident => resident.User == user && resident.Active;
        }

        public static Expression<Func<Resident, bool>> GetAllInactive(string user)
        {
            return resident => resident.User == user && !resident.Active;
        }

        public static Expression<Func<Resident, bool>> GetAllByApartment(string user, Guid apartmentId)
        {
            return resident => resident.User == user && resident.Active && (resident.Apartment == null || resident.Apartment.Id == apartmentId);
        }

        public static Expression<Func<Resident, bool>> GetAllWithoutApartment(string user)
        {
            return resident => resident.User == user && resident.Apartment == null && resident.Active;
        }
    }
}