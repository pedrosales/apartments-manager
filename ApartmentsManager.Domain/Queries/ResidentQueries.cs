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
    }
}