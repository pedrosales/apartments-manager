using System;
using System.Collections.Generic;
using System.Linq;
using ApartmentsManager.Domain.Entities;
using ApartmentsManager.Domain.Queries;
using ApartmentsManager.Domain.Repositories;

namespace ApartmentsManager.Tests.Repositories
{
    public class FakeApartmentRepository : IApartmentRepository
    {
        private IList<Apartment> _items;

        public FakeApartmentRepository()
        {
            _items = new List<Apartment>();
            var condominium = new Condominium("Condomínio 1", "Rua do condominio", 1925, "Bairro do condominio", "Cidade do Condominio", "MG", "Brasil", "31035560", "Pedro Ivo");
            _items.Add(new Apartment(condominium, 101, "Bloco 1", "Pedro Ivo"));
            _items.Add(new Apartment(condominium, 102, "Bloco 1", "Pedro Ivo"));
            _items.Add(new Apartment(condominium, 103, "Bloco 1", "Pedro Ivo"));

        }

        public void Create(Apartment apartment)
        {

        }

        public IEnumerable<Apartment> GetAll(string user)
        {
            return _items.AsQueryable().Where(ApartmentQueries.GetAll(user));
        }
        public Apartment GetById(Guid id, string user)
        {
            return new Apartment(null, 1925, "Bloco 1", "Pedro Ivo");
        }

        public void Update(Apartment apartment)
        {

        }
    }
}