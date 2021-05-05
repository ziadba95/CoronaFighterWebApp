using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using BPRCoronaFighter.Controllers;
using static DataLibrary.BusinessLogic.UserProcessor;
using BPRCoronaFighter.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class TestAccountController
    {
        [TestMethod]
        public void IndexTest()
        {
            // Arrange
            AccountController controller = new AccountController();
            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
           }

        [TestMethod]
        public void LogoutTest(User model)
        {
            // Arrange
            AccountController controller = new AccountController();
            // Act
            ViewResult result = controller.Logout(model) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ChangePassTest(User model)
        {
            // Arrange
            AccountController controller = new AccountController();
            // Act
            ViewResult result = controller.ChangePass(model) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }


    }
}
