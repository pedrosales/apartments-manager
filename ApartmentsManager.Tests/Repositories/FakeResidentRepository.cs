using System;
using System.Collections.Generic;
using System.Linq;
using ApartmentsManager.Domain.Entities;
using ApartmentsManager.Domain.Queries;
using ApartmentsManager.Domain.Repositories;

namespace ApartmentsManager.Tests.Repositories
{
    public class FakeResidentRepository : IResidentRepository
    {
        private IList<Resident> _items;

        public FakeResidentRepository()
        {
            _items = new List<Resident>();
            _items.Add(new Resident(null, "Morador 1", DateTime.Parse("08-08-1988"), "31994969424", "09370469656", "morador1@gmail.com", "Pedro Ivo"));
            _items.Add(new Resident(null, "Morador 2", DateTime.Parse("08-24-1963"), "31994969424", "05670458596", "morador2@gmail.com", "Usuario A"));
            _items.Add(new Resident(null, "Morador 3", DateTime.Parse("03-15-1953"), "31994969424", "11301910600", "morador3@gmail.com", "Pedro Ivo"));
            _items.Add(new Resident(null, "Morador 4", DateTime.Parse("09-02-1987"), "31994969424", "21485203656", "morador4@gmail.com", "Usuario A"));
            _items.Add(new Resident(null, "Morador 5", DateTime.Parse("05-02-1990"), "31994969424", "70420145896", "morador5@gmail.com", "Pedro Ivo"));
            _items.Add(new Resident(null, "Morador 6 Inactive", DateTime.Parse("09-02-1987"), "31994969424", "21485203656", "morador6@gmail.com", "Usuario A"));
            _items.Add(new Resident(null, "Morador 7 Inactive", DateTime.Parse("09-02-1987"), "31994969424", "21485203656", "morador7@gmail.com", "Usuario A"));
            _items.Add(new Resident(null, "Morador 8 Inactive", DateTime.Parse("05-02-1990"), "31994969424", "70420145896", "morador8@gmail.com", "Pedro Ivo"));
            _items.Add(new Resident(null, "Morador 9 Inactive", DateTime.Parse("05-02-1990"), "31994969424", "70420145896", "morador9@gmail.com", "Pedro Ivo"));

            foreach (var resident in _items.Where(x => x.Name.Contains("Inactive")).ToList())
            {
                resident.Inactivate();
            }
        }
        public void Create(Resident resident)
        {

        }

        public IEnumerable<Resident> GetAll(string user)
        {
            return _items.AsQueryable().Where(ResidentQueries.GetAll(user));
        }

        public IEnumerable<Resident> GetAllActive(string user)
        {
            return _items.AsQueryable().Where(ResidentQueries.GetAllActive(user));
        }

        public IEnumerable<Resident> GetAllInactive(string user)
        {
            return _items.AsQueryable().Where(ResidentQueries.GetAllInactive(user));
        }

        public Resident GetById(Guid id, string user)
        {
            return new Resident(null, "Morador 1", DateTime.Now, "31985412356", "09370469656", "morador1@gmail.com", "Pedro Ivo");
        }

        public void Update(Resident resident)
        {

        }
    }
}