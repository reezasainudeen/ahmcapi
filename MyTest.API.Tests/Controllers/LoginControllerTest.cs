using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTest.API;
using MyTest.API.Controllers;
using MyTest.Core.Enitity;
using MyTest.Infrastructure.Repositories;
using System.Web.Http.Results;


namespace MyTest.API.Tests.Controllers
{
    [TestClass]
    public class LoginControllerTest
    {
        [TestMethod]
        public void LoginTest()
        {
            // Arrange
            LoginController controller = new LoginController(new MockUserRepositories() );

            // Act
            var actionResult = controller.Put();
            var contentResult = actionResult as OkNegotiatedContentResult<string>;

            // Assert
            Assert.IsNotNull(contentResult.Content);           
        }
        [TestMethod]
        public void RegisterTest()
        {

            // Arrange
            LoginController controller = new LoginController(new MockUserRepositories());

            // Act
            var actionResult = controller.Post(new User{ Id = 5 , Name = "TestUser", Password = "TestPWD",Email = "TestUser@abc.com"} );
            var contentResult = actionResult as OkNegotiatedContentResult<bool>;

            // Assert
            Assert.IsTrue(contentResult.Content);
        }
    }
}
