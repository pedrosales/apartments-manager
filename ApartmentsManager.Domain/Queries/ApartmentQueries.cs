using System;
using System.Linq.Expressions;
using ApartmentsManager.Domain.Entities;

namespace ApartmentsManager.Domain.Queries
{
    public class ApartmentQueries
    {
        public static Expression<Func<Apartment, bool>> GetAll(string user)
        {
            return apartment => apartment.User == user;
        }

        public static Expression<Func<Apartment, bool>> GetAllActive(string user)
        {
            return apartment => apartment.User == user && apartment.Active;
        }

        public static Expression<Func<Apartment, bool>> GetAllInactive(string user)
        {
            return apartment => apartment.User == user && !apartment.Active;
        }
    }
}