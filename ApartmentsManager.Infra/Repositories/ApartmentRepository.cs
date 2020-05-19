using System;
using System.Collections.Generic;
using System.Linq;
using ApartmentsManager.Domain.Entities;
using ApartmentsManager.Domain.Queries;
using ApartmentsManager.Domain.Repositories;
using ApartmentsManager.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ApartmentsManager.Infra.Repositories
{
    public class ApartmentRepository : IApartmentRepository
    {
        private readonly ApartmentsManagerContext _context;

        public ApartmentRepository(ApartmentsManagerContext context)
        {
            _context = context;
        }

        public void Create(Apartment apartment)
        {
            _context.Apartments.Add(apartment);
            _context.SaveChanges();
        }

        public IEnumerable<Apartment> GetAll(string user)
        {
            return _context.Apartments.Include(con => con.Condominium).AsNoTracking().Where(ApartmentQueries.GetAll(user));
        }

        public Apartment GetById(Guid id, string user)
        {
            return _context.Apartments.FirstOrDefault(x => x.Id == id && x.User == user);
        }

        public void Update(Apartment apartment)
        {
            _context.Entry(apartment).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}