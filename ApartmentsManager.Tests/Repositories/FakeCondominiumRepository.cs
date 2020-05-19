using System;
using System.Collections.Generic;
using System.Linq;
using ApartmentsManager.Domain.Entities;
using ApartmentsManager.Domain.Queries;
using ApartmentsManager.Domain.Repositories;

namespace ApartmentsManager.Tests.Repositories
{
    public class FakeCondominiumRepository : ICondominiumRepository
    {
        private IList<Condominium> _items;

        public FakeCondominiumRepository()
        {
            _items = new List<Condominium>();
            _items.Add(new Condominium("Solar da Mata", "Rua Conselheiro Lafaiete", 1925, "Sagrada Família", "Belo Horizonte", "MG", "Brasil", "31035560", "Pedro Ivo"));
            _items.Add(new Condominium("Edifício Magalhães Pinto", "Rua Conselheiro Lafaiete", 1977, "Sagrada Família", "Belo Horizonte", "MG", "Brasil", "31035560", "Pedro Ivo"));
            _items.Add(new Condominium("Moleques do Sul", "Rua José Beiro", 272, "Jardim Atlântico", "Florianópolis", "SC", "Brasil", "88095122", "Pedro Ivo"));
        }

        public void Create(Condominium condominium)
        {

        }

        public IEnumerable<Condominium> GetAll(string user)
        {
            return _items.AsQueryable().Where(CondominiumQueries.GetAll(user));
        }

        public IEnumerable<Condominium> GetAllActive(string user)
        {
            return _items.AsQueryable().Where(CondominiumQueries.GetAllActive(user));
        }

        public IEnumerable<Condominium> GetAllInactive(string user)
        {
            return _items.AsQueryable().Where(CondominiumQueries.GetAllInactive(user));
        }

        public Condominium GetById(Guid id, string user)
        {
            return new Condominium("Solar da Mata", "Rua Conselheiro Lafaiete", 1925, "Sagrada Família", "Belo Horizonte", "MG", "Brasil", "31035560", "Pedro Ivo");
        }

        public void Update(Condominium condominium)
        {

        }
    }
}