using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using BPRCoronaFighter.Controllers;
namespace UnitTestProject1
{
    /// <summary>
    /// UnitTest2 的摘要说明
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            
        }
        [TestMethod]
        public void Index2()
        {
            OfferHelpController controller = new OfferHelpController();
            ViewResult result = controller.DeleteOfferHelp() as ViewResult;
            Assert.AreEqual(0, result);
        }


    }
}
