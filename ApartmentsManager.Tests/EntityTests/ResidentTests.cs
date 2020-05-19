using System;
using ApartmentsManager.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApartmentsManager.Tests.EntityTests
{
    [TestClass]
    public class ResidentTests
    {
        private readonly Resident _validResident = new Resident("Morador 1", DateTime.Now, "31994969424", "09370469656", "morador1@gmail.com", "Pedro Ivo");

        [TestMethod]
        public void Given_Valid_Resident_Active_Should_Be_True()
        {
            Assert.AreEqual(true, _validResident.Active);
        }

        [TestMethod]
        public void Given_Valid_Resident_When_Activate_Active_Should_Be_True()
        {
            _validResident.Activate();
            Assert.AreEqual(true, _validResident.Active);
        }

        [TestMethod]
        public void Given_Valid_Resident_When_Invalidate_Active_Should_Be_False()
        {
            _validResident.Inactivate();
            Assert.AreEqual(false, _validResident.Active);
        }
    }
}