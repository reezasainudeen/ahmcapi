using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTest.API.Controllers;
using MyTest.Core.Enitity;
using MyTest.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;

namespace MyTest.API.Tests.Controllers
{
    [TestClass]
    public class CarControllerTest
    {
        [TestMethod]
        public void GetAll()
        {
            // Arrange
            CarController controller = new CarController(new MockCarRepositories());

            // Act
            var actionResult = controller.GetAll();
            var contentResult = actionResult as OkNegotiatedContentResult<IEnumerable<Car>>;
            // Assert
            var cars = contentResult.Content;
            Assert.AreEqual(5, cars.Count());
        }
        [TestMethod]
        public void SearchCarsByYear()
        {
            // Arrange
            CarController controller = new CarController(new MockCarRepositories());

            // Act
            var actionResult = controller.GetByYear("2022");
            var contentResult = actionResult as OkNegotiatedContentResult<IEnumerable<Car>>;
            // Assert
            var cars = contentResult.Content;           
            Assert.AreEqual(2, cars.Count());
        }
    }
}
