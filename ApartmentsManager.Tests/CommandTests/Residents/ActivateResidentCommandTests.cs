using System;
using ApartmentsManager.Domain.Commands.Requests.Residents;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApartmentsManager.Tests.CommandTests.Residents
{
    [TestClass]
    public class ActivateResidentTests
    {
        private readonly ActivateResidentCommand _validCommand = new ActivateResidentCommand(Guid.NewGuid(), "Pedro Ivo");
        private readonly ActivateResidentCommand _invalidCommand = new ActivateResidentCommand(Guid.Empty, "");

        public ActivateResidentTests()
        {
            _validCommand.Validate();
            _invalidCommand.Validate();
        }

        [TestMethod]
        public void Given_Valid_Command_Result_Should_Be_True()
        {
            Assert.AreEqual(true, _validCommand.Valid);
            Assert.AreEqual(false, _validCommand.Invalid);
        }

        [TestMethod]
        public void Given_Valid_Command_Result_Should_Be_False()
        {
            Assert.AreEqual(false, _invalidCommand.Valid);
            Assert.AreEqual(true, _invalidCommand.Invalid);
        }

    }
}