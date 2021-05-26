using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using BPRCoronaFighter.Controllers;
using static DataLibrary.BusinessLogic.CommentProcessor;
using static DataLibrary.BusinessLogic.PostProcessor;
using static DataLibrary.BusinessLogic.GroupProcessor;
using static DataLibrary.BusinessLogic.UserProcessor;
using BPRCoronaFighter.Models;
using System.ComponentModel.DataAnnotations;
namespace UnitTestProject
{
    /// <summary>
    /// TestGroupController 的摘要说明
    /// </summary>
    [TestClass]
    public class TestGroupController
    {
        public TestGroupController()
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
        public void GroupIndexTest()
        {
            // Arrange
            GroupsController controller = new GroupsController();
            var model = new Post();
            var model1 = new UserGroup();
            // Act
            ViewResult result = controller.Index(model, model1) as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void OwnGroupTest()
        {
            // Arrange
            GroupsController controller = new GroupsController();
            var model = new Post();
            var model1 = new UserGroup()
            {
                GroupId = 15,
            };
            // Act
            ViewResult result = controller.OwnGroup(model, model1) as ViewResult;
            //LoadOwnPosts(model1.GroupId.ToString());
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreatePostTest()
        {
            // Arrange
            var model = new Post()
            {
                PostTitle = "test",
                PostContent = "test",
                PostDate = DateTime.Now.ToString(),
                PostAuthor = "test",
                UserID = "15",
                GroupID= "5"
            };
            var controller = new GroupsController();
            // Act
            var results = controller.CreatePost(model) as ViewResult;
            var results2 = CreatePosts(model.PostTitle, model.PostContent, 
                DateTime.Now.ToString(), model.PostAuthor, model.UserID, model.GroupID);
            // Assert
            Assert.AreEqual(1, results2);
        }

        [TestMethod]
        public void CreateCommentTest()
        {
            var model = new Comment()
            {
                PostID = "5",
                UserID = "5",
                CommentAuthor = "5",
                CommentText = "5",
            };

            var controller = new GroupsController();
            var results = controller.CreateComments(model) as ViewResult;
            var results2 = CreateComment(model.CommentText, model.UserID, model.PostID, DateTime.Now.ToString(), model.CommentAuthor);
            Assert.AreEqual(1, results2);
        }
        [TestMethod]
        public void CreateGroupTest()
        {
            AccountController.userID = "5";
            var model = new Group()
            {
                GroupName = "test",
                GroupCreater = "test",
                UserID = "5",
                City = "15",
                Description = "5"
            };
            var model1 = new UserGroup()
            {
                UserId = 5,
                UserName = "test",
                GroupId = 5,
                GroupName = "test",
            };

            var controller = new GroupsController();
            var results = controller.CreateGroups(model,model1) as ViewResult;
            var results2 = CreateGroup(model.GroupName, DateTime.Now.ToString(), model.GroupCreater, model.UserID, model.City, model.Description);
            var results3 = JoinGroups(model1.UserId, model1.UserName, model1.GroupId, model.GroupName);
            Assert.AreEqual(1, results2);
            Assert.AreEqual(1, results3);
        }
        [TestMethod]
        public void GroupListTest()
        {
            GroupsController controller = new GroupsController();
            var model = new Group();
            ViewResult result = controller.GroupList(model) as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void JoinGroupTest()
        {
            AccountController.username = "bj cui (Volunteer)";
            AccountController.userID ="40";
            var model = new UserGroup()
            {
                GroupName = "ziad",
            };
            model.GroupId = int.Parse(GetGroupID(model.GroupName));
            model.UserId = int.Parse(AccountController.userID);
            model.UserName = AccountController.username;
            var controller = new GroupsController();
            var results = controller.JoinGroup(model) as ViewResult;
            var results2 = JoinGroups(model.UserId, model.UserName, model.GroupId, model.GroupName);
            Assert.AreEqual(1, results2);
            
        }
        [TestMethod]
        public void LeaveGroupTest()
        {
            AccountController.userID = "40";
            var model = new UserGroup()
            {
                GroupName = "top",
                UserId= int.Parse(AccountController.userID),
            };
            model.GroupId = int.Parse(GetGroupID(model.GroupName));
            var controller = new GroupsController();
            var results = controller.LeaveGroup(model) as ViewResult;
            var results2 = LeaveGroupss(model.GroupName,model.UserId);
            Assert.AreEqual(1, results2);

        }
        [TestMethod]
        public void SearchPostTest()
        {
            var model = new Post()
            {
                PostTitle ="0",
            };

            var controller = new GroupsController();
            var results = controller.SearchPost(model) as ViewResult;
            var results2 = SearchPosts(model.PostTitle);
            Assert.AreEqual(1, results2);
        }
        [TestMethod]
        public void SeePostTest()
        {
            var model = new Post()
            {
                PostId=32,
            };
            
            var controller = new GroupsController();
            var results = controller.SeePost(model) as ViewResult;
            var results2 = Postdetail(model.PostId);
            Assert.AreEqual(1, results2);
        }
        [TestMethod]
        public void PostDetailTest()
        {
            var model = new Post()
            {
                PostId=15,
            };
            var model1 = new Comment();
            var controller = new GroupsController();
            var results = controller.PostDetail(model,model1) as ViewResult;
            var results2 = Postdetails(model.PostId);
            var results3 = LoadComments(model.PostId);
            Assert.IsNotNull(results);
        }
        [TestMethod]
        public void SavedpostTest()
        {
            var model = new UserPost()
            {
                UserName="test",
            };

            var controller = new GroupsController();
            var results = controller.Savedpost(model) as ViewResult;
            var results2 = SavedPosts(model.UserName);
            Assert.IsNotNull(results2);
        }
        [TestMethod]
        public void SearchPostForSaveTest()
        {
            AccountController.userID = "15";
            AccountController.username = "test";
            var model = new UserPost()
            {
                UserId = int.Parse(AccountController.userID),
                UserName = AccountController.username,
                PostId=5,
                PostTitle = "test",
            };
            var controller = new GroupsController();
            var results = controller.SearchPostForSave(model) as ViewResult;
            var results2 = SearchPostsForSave(model.UserId, model.UserName, model.PostId, model.PostTitle);
            Assert.AreEqual(1, results2);
        }
    }
}
