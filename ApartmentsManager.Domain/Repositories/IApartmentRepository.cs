using System;
using System.Collections.Generic;
using ApartmentsManager.Domain.Entities;

namespace ApartmentsManager.Domain.Repositories
{
    public interface IApartmentRepository
    {
        void Create(Apartment apartment);
        void Update(Apartment apartment);
        IEnumerable<Apartment> GetAll(string user);
        Apartment GetById(Guid id, string user);
        IEnumerable<Apartment> GetAllWithoutCondominium(string user);
    }
}