using System;
using ApartmentsManager.Domain.Commands.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApartmentsManager.Tests.CommandTests
{
    [TestClass]
    public class CreateResidentCommandTests
    {
        private readonly CreateResidentCommand _invalidCommand = new CreateResidentCommand("", DateTime.Now, "", "", "", "");
        private readonly CreateResidentCommand _validCommand = new CreateResidentCommand("Morador 1", DateTime.Parse("08-08-1988"), "31994969424", "09370469656", "pedroivossantos@gmail.com", "Pedro Ivo");
        public CreateResidentCommandTests()
        {
            _invalidCommand.Validate();
            _validCommand.Validate();
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