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
    }
}