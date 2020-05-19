using System;
using System.Linq.Expressions;
using ApartmentsManager.Domain.Entities;

namespace ApartmentsManager.Domain.Queries
{
    public static class CondominiumQueries
    {
        public static Expression<Func<Condominium, bool>> GetAll(string user)
        {
            return resident => resident.User == user;
        }

        public static Expression<Func<Condominium, bool>> GetAllActive(string user)
        {
            return resident => resident.User == user && resident.Active;
        }

        public static Expression<Func<Condominium, bool>> GetAllInactive(string user)
        {
            return resident => resident.User == user && !resident.Active;
        }
    }
}