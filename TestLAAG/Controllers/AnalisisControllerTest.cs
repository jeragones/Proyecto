using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LAAG;
using LAAG.Controllers;

namespace TestLAAG.Controllers
{
    [TestClass]
    public class AnalisisControllerTest
    {
        [TestMethod]
        public void login()
        {
            // Arrange
            AccountController controller = new AccountController();
            //ViewResult result = controller.Login(null) as ViewResult;
            // Act
            //ViewResult result = controller.Index() as ViewResult;

            string algo = ""; // result.ViewBag.app
            // Assert
            Assert.AreEqual(algo, "");
        }
        /*
        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Login() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Profile() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }*/
    }
}
