using System;
using System.Collections.Generic;
using System.Linq;
using ApartmentsManager.Domain.Entities;
using ApartmentsManager.Domain.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApartmentsManager.Tests.QueryTests
{
    [TestClass]
    public class ResidentQueriesTests
    {
        private List<Resident> _items;

        public ResidentQueriesTests()
        {
            _items = new List<Resident>();
            _items.Add(new Resident("Morador 1", DateTime.Parse("08-08-1988"), "31994969424", "09370469656", "morador1@gmail.com", "Pedro Ivo"));
            _items.Add(new Resident("Morador 2", DateTime.Parse("08-24-1963"), "31994969424", "05670458596", "morador2@gmail.com", "Usuario A"));
            _items.Add(new Resident("Morador 3", DateTime.Parse("03-15-1953"), "31994969424", "11301910600", "morador3@gmail.com", "Pedro Ivo"));
            _items.Add(new Resident("Morador 4", DateTime.Parse("09-02-1987"), "31994969424", "21485203656", "morador4@gmail.com", "Usuario A"));
            _items.Add(new Resident("Morador 5", DateTime.Parse("05-02-1990"), "31994969424", "70420145896", "morador5@gmail.com", "Pedro Ivo"));

        }

        [TestMethod]
        public void Should_Return_PedroIvo_Residents()
        {
            var result = _items.AsQueryable().Where(ResidentQueries.GetAll("Pedro Ivo"));
            Assert.AreEqual(3, result.Count());
        }
    }
}