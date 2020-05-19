using ApartmentsManager.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApartmentsManager.Tests.EntityTests
{
    [TestClass]
    public class CondominiumTests
    {
        private readonly Condominium _validCondominium = new Condominium("Solar da Mata", "Rua Conselheiro Lafaiete", 1925, "Sagrada Família", "Belo Horizonte", "MG", "Brasil", "31035560", "Pedro Ivo");

        [TestMethod]
        public void Given_Valid_Condominium_Active_Should_Be_True()
        {
            Assert.AreEqual(true, _validCondominium.Active);
        }

        [TestMethod]
        public void Given_Valid_Condominium_When_Activate_Active_Should_Be_True()
        {
            _validCondominium.Activate();
            Assert.AreEqual(true, _validCondominium.Active);
        }

        [TestMethod]
        public void Given_Valid_Condominium_When_Invalidate_Active_Should_Be_False()
        {
            _validCondominium.Inactivate();
            Assert.AreEqual(false, _validCondominium.Active);
        }
    }
}