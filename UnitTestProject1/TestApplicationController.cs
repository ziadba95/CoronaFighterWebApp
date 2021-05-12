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
    /// <summary>
    /// TestApplicationController 的摘要说明
    /// </summary>
    [TestClass]
    public class TestApplicationController
    {
        public TestApplicationController()
        {
            //
            //TODO:  在此处添加构造函数逻辑
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，该上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        //
        // 编写测试时，可以使用以下附加特性: 
        //
        // 在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在运行每个测试之前，使用 TestInitialize 来运行代码
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在每个测试运行完之后，使用 TestCleanup 来运行代码
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void DoctorSignUpTest()
        {
            var model = new Application()
            {
                FirstName = "6",
                LastName = "6",
                Dob = DateTime.Now,
                Email = "xu",
                Password = "111111",
                Gender = "Male",
                AppStatus = "waiting"
            };

            var controller = new ApplicationController();
            var results = controller.DoctorSignUp(model) as ViewResult;
            var results1 = CreateDoctor(model.FirstName, model.LastName, model.Email, model.Password, model.Dob, model.Gender, model.AppStatus, DateTime.Now.ToString());
            
            Assert.AreEqual(1, results1);
        }
    }
}
