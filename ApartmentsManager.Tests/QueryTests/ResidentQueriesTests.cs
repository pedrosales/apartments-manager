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
            _items.Add(new Resident(null, "Morador 1", DateTime.Parse("08-08-1988"), "31994969424", "09370469656", "morador1@gmail.com", "Pedro Ivo"));
            _items.Add(new Resident(null, "Morador 3", DateTime.Parse("03-15-1953"), "31994969424", "11301910600", "morador3@gmail.com", "Pedro Ivo"));
            _items.Add(new Resident(null, "Morador 4", DateTime.Parse("09-02-1987"), "31994969424", "21485203656", "morador4@gmail.com", "Usuario A"));
            _items.Add(new Resident(null, "Morador 2", DateTime.Parse("08-24-1963"), "31994969424", "05670458596", "morador2@gmail.com", "Usuario A"));
            _items.Add(new Resident(null, "Morador 5", DateTime.Parse("05-02-1990"), "31994969424", "70420145896", "morador5@gmail.com", "Pedro Ivo"));
            _items.Add(new Resident(null, "Morador 6 Inactive", DateTime.Parse("09-02-1987"), "31994969424", "21485203656", "morador6@gmail.com", "Usuario A"));
            _items.Add(new Resident(null, "Morador 7 Inactive", DateTime.Parse("09-02-1987"), "31994969424", "21485203656", "morador7@gmail.com", "Usuario A"));
            _items.Add(new Resident(null, "Morador 8 Inactive", DateTime.Parse("05-02-1990"), "31994969424", "70420145896", "morador8@gmail.com", "Pedro Ivo"));
            _items.Add(new Resident(null, "Morador 9 Inactive", DateTime.Parse("05-02-1990"), "31994969424", "70420145896", "morador9@gmail.com", "Pedro Ivo"));

            foreach (var resident in _items.Where(x => x.Name.Contains("Inactive")).ToList())
            {
                resident.Inactivate();
            }
        }

        [TestMethod]
        public void Should_Return_PedroIvo_Residents()
        {
            var result = _items.AsQueryable().Where(ResidentQueries.GetAll("Pedro Ivo"));
            Assert.AreEqual(5, result.Count());
        }

        [TestMethod]
        public void Should_Return_Inactive_Residents_To_UsuarioA()
        {
            var result = _items.AsQueryable().Where(ResidentQueries.GetAllInactive("Usuario A"));
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void Should_Return_Active_Residents_To_PedroIvo()
        {
            var result = _items.AsQueryable().Where(ResidentQueries.GetAllActive("Pedro Ivo"));
            Assert.AreEqual(3, result.Count());
        }
    }
}