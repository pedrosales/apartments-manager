using System;
using ApartmentsManager.Domain.Commands.Requests.Residents;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApartmentsManager.Tests.CommandTests
{
    [TestClass]
    public class InvalidateResidentCommandTests
    {
        private readonly InactivateResidentCommand _invalidCommand = new InactivateResidentCommand(Guid.Empty, "");
        private readonly InactivateResidentCommand _validCommand = new InactivateResidentCommand(Guid.NewGuid(), "Pedro Ivo");

        public InvalidateResidentCommandTests()
        {
            _invalidCommand.Validate();
            _validCommand.Validate();
        }

        [TestMethod]
        public void Given_Valid_Command_Result_Should_Be_True()
        {
            Assert.AreEqual(true, _validCommand.Valid);
            Assert.AreEqual(false, _validCommand.Invalid);
        }

        [TestMethod]
        public void Given_Invalid_Command_Result_Should_Be_False()
        {
            Assert.AreEqual(false, _invalidCommand.Valid);
            Assert.AreEqual(true, _invalidCommand.Invalid);
        }
    }
}