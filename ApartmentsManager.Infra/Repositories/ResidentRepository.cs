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
    public class ResidentRepository : IResidentRepository
    {
        private readonly ApartmentsManagerContext _context;

        public ResidentRepository(ApartmentsManagerContext context)
        {
            _context = context;
        }
        public void Create(Resident resident)
        {
            _context.Residents.Add(resident);
            _context.SaveChanges();
        }

        public IEnumerable<Resident> GetAll(string user)
        {
            return _context.Residents.AsNoTracking().Where(ResidentQueries.GetAll(user)).OrderBy(x => x.Name);
        }

        public IEnumerable<Resident> GetAllActive(string user)
        {
            return _context.Residents.AsNoTracking().Where(ResidentQueries.GetAllActive(user)).OrderBy(x => x.Name);
        }

        public IEnumerable<Resident> GetAllInactive(string user)
        {
            return _context.Residents.AsNoTracking().Where(ResidentQueries.GetAllInactive(user)).OrderBy(x => x.Name);
        }

        public Resident GetById(Guid id, string user)
        {
            return _context.Residents.FirstOrDefault(x => x.Id == id && x.User == user);
        }

        public void Update(Resident resident)
        {
            _context.Entry(resident).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}