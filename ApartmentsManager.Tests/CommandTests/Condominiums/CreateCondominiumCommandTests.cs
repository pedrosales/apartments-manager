using ApartmentsManager.Domain.Commands.Requests.Condominiums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApartmentsManager.Tests.CommandTests.Condominiums
{
    [TestClass]
    public class CreateCondominiumCommandTests
    {
        private readonly CreateCondominiumCommand _validCommand = new CreateCondominiumCommand("Solar da Mata", "Rua Conselheiro Lafaiete", 1925, "Sagrada Família", "Belo Horizonte", "MG", "Brasil", "31035560", "Pedro Ivo");
        private readonly CreateCondominiumCommand _invalidCommand = new CreateCondominiumCommand("", "", 0, "", "", "", "", "", "");

        public CreateCondominiumCommandTests()
        {
            _validCommand.Validate();
            _invalidCommand.Validate();
        }

        [TestMethod]
        public void Given_Invalid_Command_Result_Should_Be_False()
        {
            Assert.AreEqual(false, _invalidCommand.Valid);
            Assert.AreEqual(true, _invalidCommand.Invalid);
        }

        [TestMethod]
        public void Given_Valid_Command_Result_Should_Be_True()
        {
            Assert.AreEqual(true, _validCommand.Valid);
            Assert.AreEqual(false, _validCommand.Invalid);
        }
    }
}