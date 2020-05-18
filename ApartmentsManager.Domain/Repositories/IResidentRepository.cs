using System;
using System.Collections.Generic;
using ApartmentsManager.Domain.Entities;
using ApartmentsManager.Domain.Queries.Results;

namespace ApartmentsManager.Domain.Repositories
{
    public interface IResidentRepository
    {
        void Create(Resident resident);
        void Update(Resident resident);
        IEnumerable<Resident> GetAll(string user);
        Resident GetById(Guid id, string user);
    }
}