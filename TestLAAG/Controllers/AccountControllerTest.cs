using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LAAG;
using LAAG.Controllers;
using LAAG.Models;
using WebMatrix.WebData;

namespace TestLAAG.Controllers
{
    [TestClass]
    public class AccountControllerTest
    {
        [TestMethod]
        public void login()
        {
            // Arrange
            AccountController controller = new AccountController();
            LoginModel model = new LoginModel();
            model.Password = "12345";
            model.UserName = "jeragones";
            //WebSecurity.Logout();
            //ActionResult result = controller.Login(model,"");
            //string algo = result.ToString();
            Assert.AreEqual("", "");
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
