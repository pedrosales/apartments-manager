using System;
using ApartmentsManager.Domain.Commands.Requests.Residents;
using ApartmentsManager.Domain.Commands.Results;
using ApartmentsManager.Domain.Handlers;
using ApartmentsManager.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApartmentsManager.Tests.HandlerTests
{
    [TestClass]
    public class CreateResidentHandlerTests
    {
        private readonly CreateResidentCommand _invalidCommand = new CreateResidentCommand("", DateTime.Now, "", "", "", "");
        private readonly CreateResidentCommand _validCommand = new CreateResidentCommand("Morador 1", DateTime.Parse("08-08-1988"), "31994969424", "09370469656", "pedroivossantos@gmail.com", "Pedro Ivo");
        private readonly ResidentHandler _handler = new ResidentHandler(new FakeResidentRepository());
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