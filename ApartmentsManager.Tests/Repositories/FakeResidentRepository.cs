using System;
using System.Collections.Generic;
using ApartmentsManager.Domain.Entities;
using ApartmentsManager.Domain.Repositories;

namespace ApartmentsManager.Tests.Repositories
{
    public class FakeResidentRepository : IResidentRepository
    {
        private IList<Resident> _items;

        public FakeResidentRepository()
        {
            _items = new List<Resident>();
            _items.Add(new Resident("Morador 1", DateTime.Parse("08-08-1988"), "31994969424", "09370469656", "morador1@gmail.com", "Pedro Ivo"));
            _items.Add(new Resident("Morador 2", DateTime.Parse("24-08-1963"), "31994969424", "05670458596", "morador2@gmail.com", "Usuario A"));
            _items.Add(new Resident("Morador 3", DateTime.Parse("15-03-1953"), "31994969424", "11301910600", "morador3@gmail.com", "Pedro Ivo"));
            _items.Add(new Resident("Morador 4", DateTime.Parse("02-09-1987"), "31994969424", "21485203656", "morador4@gmail.com", "Usuario A"));
            _items.Add(new Resident("Morador 5", DateTime.Parse("02-05-1990"), "31994969424", "70420145896", "morador5@gmail.com", "Pedro Ivo"));
        }
        public void Create(Resident resident)
        {
            _items.Add(resident);
        }

        public IEnumerable<Resident> GetAll()
        {
            return _items;
        }
    }
}