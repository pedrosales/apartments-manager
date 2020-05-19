using System.Collections.Generic;
using System.Linq;
using ApartmentsManager.Domain.Entities;
using ApartmentsManager.Domain.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApartmentsManager.Tests.QueryTests
{
    [TestClass]
    public class CondominiumQueriesTests
    {
        private List<Condominium> _items;

        public CondominiumQueriesTests()
        {
            _items = new List<Condominium>();
            _items.Add(new Condominium("Solar da Mata", "Rua Conselheiro Lafaiete", 1925, "Sagrada Família", "Belo Horizonte", "MG", "Brasil", "31035560", "Pedro Ivo"));
            _items.Add(new Condominium("Edifício Magalhães Pinto", "Rua Conselheiro Lafaiete", 1977, "Sagrada Família", "Belo Horizonte", "MG", "Brasil", "31035560", "Pedro Ivo"));
            _items.Add(new Condominium("Moleques do Sul", "Rua José Beiro", 272, "Jardim Atlântico", "Florianópolis", "SC", "Brasil", "88095122", "Pedro Ivo"));
            _items.Add(new Condominium("Condominio 1", "Rua Condomínio 1", 199, "Bairro condomínio 1", "São Paulo", "SP", "Brasil", "11250860", "Usuario A"));
            _items.Add(new Condominium("Condominio 2", "Rua Condomínio 2", 199, "Bairro condomínio 2", "São Paulo", "SP", "Brasil", "11654789", "Usuario A"));
            _items.Add(new Condominium("Condominio 3 Inactive", "Rua Condomínio 3 Inactive", 199, "Bairro condomínio 3", "São Paulo", "SP", "Brasil", "11690356", "Usuario A"));
            _items.Add(new Condominium("Condominio 4 Inactive", "Rua Condomínio 4 Inactive", 199, "Bairro condomínio 4", "São Paulo", "SP", "Brasil", "11548890", "Usuario A"));
            _items.Add(new Condominium("Condominio 5 Inactive", "Rua Condomínio 5 Inactive", 199, "Bairro condomínio 5", "Belo Horizonte", "MG", "Brasil", "31897852", "Pedro Ivo"));

            foreach (var condominium in _items.Where(x => x.Name.Contains("Inactive")).ToList())
            {
                condominium.Inactivate();
            }
        }

        [TestMethod]
        public void Should_Return_PedroIvo_Condominiums()
        {
            var result = _items.AsQueryable().Where(CondominiumQueries.GetAll("Pedro Ivo"));
            Assert.AreEqual(4, result.Count());
        }

        [TestMethod]
        public void Should_Return_Inactive_Condominiums_To_UsuarioA()
        {
            var result = _items.AsQueryable().Where(CondominiumQueries.GetAllInactive("Usuario A"));
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void Should_Return_Active_Condominiums_To_PedroIvo()
        {
            var result = _items.AsQueryable().Where(CondominiumQueries.GetAllActive("Pedro Ivo"));
            Assert.AreEqual(3, result.Count());
        }
    }
}