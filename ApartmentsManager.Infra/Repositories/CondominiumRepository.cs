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
    public class CondominiumRepository : ICondominiumRepository
    {
        private readonly ApartmentsManagerContext _context;

        public CondominiumRepository(ApartmentsManagerContext context)
        {
            _context = context;
        }

        public void Create(Condominium condominium)
        {
            _context.Condominiums.Add(condominium);
            _context.SaveChanges();
        }

        public IEnumerable<Condominium> GetAll(string user)
        {
            return _context.Condominiums.AsNoTracking().Where(CondominiumQueries.GetAll(user)).OrderBy(x => x.Name);
        }

        public IEnumerable<Condominium> GetAllActive(string user)
        {
            return _context.Condominiums.AsNoTracking().Where(CondominiumQueries.GetAllActive(user)).OrderBy(x => x.Name);
        }

        public IEnumerable<Condominium> GetAllInactive(string user)
        {
            return _context.Condominiums.AsNoTracking().Where(CondominiumQueries.GetAllInactive(user)).OrderBy(x => x.Name);
        }

        public Condominium GetById(Guid id, string user)
        {
            return _context.Condominiums.FirstOrDefault(x => x.Id == id && x.User == user);
        }

        public void Update(Condominium condominium)
        {
            _context.Entry(condominium).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}