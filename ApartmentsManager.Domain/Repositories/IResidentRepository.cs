using System.Collections.Generic;
using ApartmentsManager.Domain.Entities;

namespace ApartmentsManager.Domain.Repositories
{
    public interface IResidentRepository
    {
        void Create(Resident resident);
        IEnumerable<Resident> GetAll();
    }
}