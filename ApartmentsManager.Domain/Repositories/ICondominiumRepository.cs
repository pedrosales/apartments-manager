using System;
using System.Collections.Generic;
using ApartmentsManager.Domain.Entities;

namespace ApartmentsManager.Domain.Repositories
{
    public interface ICondominiumRepository
    {
        void Create(Condominium condominium);
        void Update(Condominium condominium);
        IEnumerable<Condominium> GetAll(string user);
        IEnumerable<Condominium> GetAllInactive(string user);
        IEnumerable<Condominium> GetAllActive(string user);
        Condominium GetById(Guid id, string user);
    }
}