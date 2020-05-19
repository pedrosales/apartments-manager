using System;
using System.Collections.Generic;
using ApartmentsManager.Domain.Entities;

namespace ApartmentsManager.Domain.Repositories
{
    public interface IResidentRepository
    {
        void Create(Resident resident);
        void Update(Resident resident);
        IEnumerable<Resident> GetAll(string user);
        IEnumerable<Resident> GetAllInactive(string user);
        IEnumerable<Resident> GetAllActive(string user);
        Resident GetById(Guid id, string user);
    }
}