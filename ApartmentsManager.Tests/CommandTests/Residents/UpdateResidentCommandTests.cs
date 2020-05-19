using System;
using ApartmentsManager.Domain.Commands.Requests.Residents;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApartmentsManager.Tests.CommandTests.Residents
{
    [TestClass]
    public class UpdateResidentCommandTests
    {
        private readonly UpdateResidentCommand _invalidCommand = new UpdateResidentCommand(Guid.Empty, "", DateTime.MinValue, "", "", "", "");
        private readonly UpdateResidentCommand _validCommand = new UpdateResidentCommand(Guid.NewGuid(), "Morador 1 update", DateTime.Now, "31994969424", "09370469656", "morador1@gmail.com", "Pedro Ivo");

        public UpdateResidentCommandTests()
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