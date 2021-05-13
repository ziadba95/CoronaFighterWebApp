using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using BPRCoronaFighter.Controllers;
using static DataLibrary.BusinessLogic.LectureProcessor;
using static DataLibrary.BusinessLogic.VideoProcessor;
using BPRCoronaFighter.Models;
using System.ComponentModel.DataAnnotations;
namespace UnitTestProject
{
    /// <summary>
    /// TestLectureController 的摘要说明
    /// </summary>
    [TestClass]
    public class TestLectureController
    {
        public TestLectureController()
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
        public void LectureIndexTest()
        {
            LectureController controller = new LectureController();
            var model = new Lecture();
            // Act
            ViewResult result = controller.Index(model) as ViewResult;
            // Assert
            Assert.IsNotNull(result);


        }
        [TestMethod]
        public void CreateLectureTest()
        {
            var model = new Lecture()
            {
                LectureTitle = "test",
                LectureDescription = "test",
                LectureLink = "test",
                LectureDate = DateTime.Now,
                LectureTime = DateTime.Now,
                LectureAuthor = "test",
                UserID="40",
            };

            var controller = new LectureController();
            var results = controller.Create(model) as ViewResult;
            var results2 = CreateLecture(model.LectureTitle, model.LectureDescription, model.LectureLink, model.LectureDate, model.LectureTime, model.LectureAuthor, model.UserID);
            Assert.AreEqual(1, results2);
        }
        [TestMethod]
        public void DeleteLectureTest()
        {
            var model = new Lecture()
            {
                LectureTitle = "some",
            };

            var controller = new LectureController();
            var results = controller.DeleteLecture(model) as ViewResult;
            var results2 = DeleteLectures(model.LectureTitle);
            Assert.AreEqual(1, results2);
        }
        [TestMethod]
        public void EditLectureTest()
        {
            var model = new Lecture()
            {
                LectureTitle = "11",
                LectureDate = DateTime.Now,
                LectureTime = DateTime.Now,
            };
            var controller = new LectureController();
            var results = controller.EditLecture(model) as ViewResult;
            var results2 = EditLectures(model.LectureTitle, model.LectureDate, model.LectureTime);
            Assert.AreEqual(1, results2);
        }
    }
}
