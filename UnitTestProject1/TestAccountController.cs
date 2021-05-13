using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using BPRCoronaFighter.Controllers;
using static DataLibrary.BusinessLogic.UserProcessor;
using static DataLibrary.BusinessLogic.VideoProcessor;
using BPRCoronaFighter.Models;
using System.ComponentModel.DataAnnotations;

namespace UnitTestProject
{
    [TestClass]
    public class TestAccountController
    {
        //public static IList<ValidationResult> Validate(object model)
        //{
        //    var results = new List<ValidationResult>();
        //    var validationContext = new ValidationContext(model, null, null);
        //    Validator.TryValidateObject(model, validationContext, results, true);
        //    if (model is IValidatableObject) (model as IValidatableObject).Validate(validationContext);
        //    return results;
        //}
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

        //[TestMethod]
        public void LogoutTest()
        {
            
            // Arrange
            AccountController controller = new AccountController();
            // Act
            ViewResult result = controller.Logout() as ViewResult;

            // Assert
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void ChangePassTest()
        {

            var model = new User()
            {
                Password = "111111",
                UserId = 10
            };
            var controller = new AccountController();

            var results = controller.ChangePass(model) as ViewResult;
            var results2=ChangePassword(model.Password,"10");
            Assert.AreEqual(1, results2);
        }

        [TestMethod]
        public void ChangeUserNameTest()
        {
            var model = new User()
            {
                FirstName = "1",
                LastName = "1",
                UserId=10
            };
            var controller = new AccountController();
            var results = controller.ChangeUserName(model) as ViewResult;
            var results2 = ChangeUsername(model.FirstName, model.LastName, model.UserId.ToString());
            Assert.AreEqual(1, results2);
        }

        [TestMethod]
        public void LoginTest()
        {
            var model = new User()
            {
                Email = "xu@qq.com",
                Password= "111111",
            };

            var controller = new AccountController();
            var results = controller.Login(model) as ViewResult;
            var results2 = LogIn(model.Email, model.Password);
            //Assert.AreEqual("VideoLibrary", results.ViewName);
            Assert.AreEqual(true, results2);
        }

        [TestMethod]
        public void SignUpTest()
        {
            var model = new User()
            {
                FirstName="6",
                LastName="6",
                Dob= DateTime.Now,
                Email = "xu",
                Password = "111111",
                Gender="Male",
                RoleType="Patient"
            };

            var controller = new AccountController();
            var results = controller.Login(model) as ViewResult;
            var results1=CheckDup(model.Email);
            var results2 = CreateUser(model.FirstName, model.LastName, model.Email, model.Password, model.Dob, model.Gender, model.RoleType);
            //Assert.AreEqual("VideoLibrary", results.ViewName);
            Assert.AreEqual(1, results2);
        }

    }
}
