using ApartmentsManager.Domain.Commands.Requests.Condominiums;
using ApartmentsManager.Domain.Commands.Results;
using ApartmentsManager.Domain.Handlers;
using ApartmentsManager.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApartmentsManager.Tests.HandlerTests
{
    [TestClass]
    public class CreateCondominiumHandlerTests
    {
        private readonly CreateCondominiumCommand _invalidCommand = new CreateCondominiumCommand("", "", 0, "", "", "", "", "", "");
        private readonly CreateCondominiumCommand _validCommand = new CreateCondominiumCommand("Solar da Mata", "Rua Conselheiro Lafaiete", 1925, "Sagrada Família", "Belo Horizonte", "MG", "Brasil", "31035560", "Pedro Ivo");
        private readonly CondominiumHandler _handler = new CondominiumHandler(new FakeCondominiumRepository());
        private GenericCommandResult _result = new GenericCommandResult();

        [TestMethod]
        public void Given_Invalid_Command_Result_Success_Should_Be_False()
        {
            _result = (GenericCommandResult)_handler.Handle(_invalidCommand);
            Assert.AreEqual(false, _result.Success);
        }

        [TestMethod]
        public void Given_Valid_Command_Result_Success_Should_Be_True()
        {
            _result = (GenericCommandResult)_handler.Handle(_validCommand);
            Assert.AreEqual(true, _result.Success);
        }
    }
}