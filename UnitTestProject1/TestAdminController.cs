using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using BPRCoronaFighter.Controllers;
using static DataLibrary.BusinessLogic.VideoProcessor;
using static DataLibrary.BusinessLogic.UserProcessor;
using BPRCoronaFighter.Models;
using System.ComponentModel.DataAnnotations;
namespace UnitTestProject
{
    /// <summary>
    /// TestAdminController 的摘要说明
    /// </summary>
    [TestClass]
    public class TestAdminController
    {
        public TestAdminController()
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
        public void VideoIndexTest()
        {
            AdminController controller = new AdminController();
            //var model = new Video();
            // Act
            ViewResult result = controller.VideoLibrary() as ViewResult;
            // Assert
            Assert.IsNotNull(result);


        }
        [TestMethod]
        public void AddVideoTest()
        {
            var model = new Video()
            {
                VideoTitle = "com",
                VideoURL = "111111",
                ImageLink = "123",
            };

            var controller = new AdminController();
            var results = controller.AdminVideoLibrary(model) as ViewResult;
            var results2 = AddVideo(model.VideoTitle, model.VideoURL, model.ImageLink);
            //Assert.AreEqual("VideoLibrary", results.ViewName);
            Assert.AreEqual(1, results2);
        }
        [TestMethod]
        public void AdminApprovedUsersTest()
        {
            var model = new Application()
            {
                Email= "aaa@qq.com",
            };

            var controller = new AdminController();
            var results = controller.AdminApprovedUsers(model) as ViewResult;
            var results2 = ApproveApp(model.Email);
            Assert.AreEqual(1, results2);
        }
        [TestMethod]
        public void AdminDeclinedTest()
        {
            var model = new Application()
            {
                Email = "aaa@qq.com",
            };

            var controller = new AdminController();
            var results = controller.AdminDeclinedUsers(model) as ViewResult;
            var results2 = DeclineApp(model.Email);
            Assert.AreEqual(1, results2);
        }
    }
}
