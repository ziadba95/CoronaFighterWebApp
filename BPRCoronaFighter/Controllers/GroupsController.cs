using BPRCoronaFighter.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DataLibrary.BusinessLogic.PostProcessor;
using static DataLibrary.BusinessLogic.CommentProcessor;
using static DataLibrary.BusinessLogic.GroupProcessor;
using static DataLibrary.BusinessLogic.UserProcessor;
namespace BPRCoronaFighter.Controllers
{
    public class GroupsController : Controller
    {
        private BPRCoronaFighterContext db = new BPRCoronaFighterContext();
       
        // GET: Groups 
        public ActionResult Index(Post model, UserGroup model1)
        {
            ViewBag.UserName = AccountController.username;
            ViewBag.UserRole = AccountController.userRole;
            var data = LoadPosts();
            List<Post> listOfPosts = new List<Post>();
                for (int i = 0; i < data.Count; i++) { 
                listOfPosts.Add(new Post()
                {
                    PostId = data[i].PostId,
                    PostTitle = data[i].PostTitle,
                    PostContent = data[i].PostContent,
                    PostDate = data[i].PostDate,
                    PostAuthor = data[i].PostAuthor,
                    UserID = data[i].UserID,
                    numOfLike = data[i].numOfLike
                });
                listOfPosts.Reverse();
            }
            var data1 = LoadJoinedGroups(AccountController.username);
            List<UserGroup> listOfGroups = new List<UserGroup>();
            for (int i = 0; i < data1.Count; i++)
            {
                listOfGroups.Add(new UserGroup
                {
                    GroupName = data1[i].GroupName,
                    UserName = data1[i].UserName,
                });
                listOfGroups.Reverse();
            }

            GroupAndPost cp = new GroupAndPost();
            cp.UserGroups = listOfGroups;
            cp.Posts = listOfPosts;
            return View(cp);
        }

        public ActionResult OwnGroup(Post model, UserGroup model1)
        {
            ViewBag.UserName = AccountController.username;
            ViewBag.UserRole = AccountController.userRole;
            ViewBag.GroupName = GroupName;
            //string groupN = ViewBag.GroupName;
           //model.GroupID= groupID ;
            var data = LoadOwnPosts(groupID);
            List<Post> listOfOwnPosts = new List<Post>();
            for (int i = 0; i < data.Count; i++)
            {
                listOfOwnPosts.Add(new Post()
                {
                    PostId = data[i].PostId,
                    PostTitle = data[i].PostTitle,
                    PostContent = data[i].PostContent,
                    PostDate = data[i].PostDate,
                    PostAuthor = data[i].PostAuthor,
                    UserID = data[i].UserID,
                    numOfLike = data[i].numOfLike
                });
                listOfOwnPosts.Reverse();
            }
            //var data1 = LoadJoinedGroups(AccountController.username);
            var data1 = LoadJoinedGroupsMembers(groupID);
            List<UserGroup> listOfGroupsMembers = new List<UserGroup>();
            for (int i = 0; i < data1.Count; i++)
            {
                listOfGroupsMembers.Add(new UserGroup
                {
                    GroupName = data1[i].GroupName,
                    UserName = data1[i].UserName,
                });
                listOfGroupsMembers.Reverse();
            }
            //var data3 = LoadComments(int.Parse(groupID));
            //List<Comment> listOfComments = new List<Comment>();
            //for (int i = 0; i < data3.Count; i++)
            //{
            //    listOfComments.Add(new Comment()
            //    {
            //        PostID = data3[i].PostID,
            //        UserID = data3[i].UserID,
            //        CommentText = data3[i].CommentText,
            //        CommentDate = data3[i].CommentDate,
            //    });
            //    listOfComments.Reverse();
            //}
            GroupAndPost cp = new GroupAndPost();
            //cp.Comments = listOfComments;
            cp.UserGroups = listOfGroupsMembers;
            cp.Posts = listOfOwnPosts;
            return View(cp);
        }
        public ActionResult Like(Post model)
        {
            bool flag = true;
            if (flag)
            {
                LikeAddP(model.numOfLike);
                flag = false;
            }

            return RedirectToAction("Index");
        }
        
        public ActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost(Post model)
        {
            ModelState.Remove("PostAuthor");
            if (ModelState.IsValid)
            {
                bool isdup = CheckDupP(model.PostTitle);
                if (isdup)
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('Title already exist！');history.go(-1);location.reload();</script>");
                }
                else
                {
                    model.UserID = AccountController.userID;
                    model.PostAuthor = AccountController.username;
                    model.GroupID = groupID;
                    int recordsCreated = CreatePosts(model.PostTitle, model.PostContent, DateTime.Now.ToString(), model.PostAuthor, model.UserID, model.GroupID);
                    postID = GetPostID(model.PostTitle);
                    return RedirectToAction("Index", "Groups");
                }
            }
            return View();
        }


        public ActionResult CreateGroups()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateGroups(Group model,UserGroup model1)
        {
            ModelState.Remove("UserId");
            ModelState.Remove("UserName");
            ModelState.Remove("GroupId");
            if (ModelState.IsValid)
            {
                bool isdup = CheckDupG(model.GroupName);
                if (isdup)
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('Group already exist！');history.go(-1);location.reload();</script>");
                }
                else
                {
                    model1.UserId = int.Parse(AccountController.userID);
                    model1.UserName = AccountController.username;
                    model.UserID = AccountController.userID;
                    model.GroupCreater = AccountController.username;
                    int recordsCreated = CreateGroup(model.GroupName,DateTime.Now.ToString(), model.GroupCreater, model.UserID);
                    groupID = GetGroupID(model.GroupName);
                    GroupName = model.GroupName;
                    int recordsCreated1 = JoinGroups(model1.UserId, model1.UserName, int.Parse(groupID), model.GroupName);
                    return RedirectToAction("OwnGroup", "Groups");
                }
            }
            return View();
        }


        public ActionResult CreateComments(Post model)
        {
            
            return View(); ;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateComments(Comment model)
        {
            if (ModelState.IsValid)
            {
                model.UserID = AccountController.userID;
                model.CommentAuthor = AccountController.username;
                model.PostID = postID;
                //model.PostID = GetPostID(model1.PostTitle);
                int recordsCreated = CreateComment( model.CommentText,model.UserID,model.PostID, DateTime.Now.ToString(), model.CommentAuthor);
                return View();

            }
            return View();
        }

        //public ActionResult ViewComment(Comment model)
        //{
        //    var data = LoadComments();
        //    List<Comment> listOfComments = new List<Comment>();
        //    for (int i = 0; i < data.Count; i++)
        //    {
        //        listOfComments.Add(new Comment()
        //        {
        //            PostID = data[i].PostID,
        //            UserID = data[i].UserID,
        //            CommentText = data[i].CommentText,
        //            CommentDate = data[i].CommentDate,
        //        });
        //        listOfComments.Reverse();
        //    }
        //    GroupAndPost cp = new GroupAndPost();
        //    cp.Comments = listOfComments;

        //    return View(cp);
        //}
        public ActionResult MyPost(Post model)
        {
            string UserID = AccountController.userID;
            var data = LoadPostsByUser(UserID);
            List<Post> posts = new List<Post>();
            foreach (var item in data)
            {
                posts.Add(new Post
                {
                    PostTitle = item.PostTitle,
                    PostContent = item.PostContent,
                    PostDate = item.PostDate,
                    PostAuthor = item.PostAuthor,
                    UserID = item.UserID,
                });
                posts.Reverse();
            }
            return View(posts);
        }
        public ActionResult GroupList(Group model)
        {
            var data = LoadGroups();
            List<Group> groups = new List<Group>();
            foreach (var item in data)
            {
                groups.Add(new Group
                {
                    GroupName = item.GroupName,
                    GroupTime = item.GroupTime,
                    GroupCreater = item.GroupCreater,
                });
                groups.Reverse();
            }
            return View(groups);
        }
        
        public ActionResult SearchPost(Post model)
        {
            ModelState.Remove("PostAuthor");
            ModelState.Remove("PostContent");
            if (ModelState.IsValid)
            {
                if (isPrivate(model.PostTitle) == null)
                {
                    int recordsCreated = SearchPosts(model.PostTitle);
                    postTitle = model.PostTitle;
                    return RedirectToAction("ListSearchP", "Groups");
                }
                else
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('It is a private post！');history.go(-1);location.reload();</script>");
                }
               
                
            }
            return View();
        }
        public ActionResult SearchGroup(Group model)
        {
            if (ModelState.IsValid)
            {
                groupID = GetGroupID(model.GroupName);
                if (groupID == "Nothing")
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('Nothing Found！');history.go(-1);location.reload();</script>");
                }
                else
                {
                     int recordsCreated = SearchGroups(int.Parse(groupID));
               
                    GroupName = model.GroupName;
                    ViewBag.GroupName = GroupName;
                    return RedirectToAction("OwnGroup", "Groups");
                }
               
                
            }
            return View();
        }
        public ActionResult SeePost(Post model)
        {
            ModelState.Remove("PostAuthor");
            ModelState.Remove("PostContent");
            if (ModelState.IsValid)
            {
                postID = GetPostID(model.PostTitle);
                if (postID == "Nothing")
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('Nothing Found！');history.go(-1);location.reload();</script>");
                }
                else
                {
                    int recordsCreated = Postdetail(int.Parse(postID));

                    postTitle = model.PostTitle;
                    ViewBag.PostTitle = postTitle;
                    return RedirectToAction("PostDetail", "Groups");
                }
            }
            return View();
        }
        public ActionResult PostDetail(Post model,Comment model1)
        {
            var data = Postdetails(int.Parse(postID));
            List<Post> listOfOwnPosts = new List<Post>();
            for (int i = 0; i < data.Count; i++)
            {
                listOfOwnPosts.Add(new Post()
                {
                    PostId = data[i].PostId,
                    PostTitle = data[i].PostTitle,
                    PostContent = data[i].PostContent,
                    PostDate = data[i].PostDate,
                    PostAuthor = data[i].PostAuthor,
                    UserID = data[i].UserID,
                    numOfLike = data[i].numOfLike
                });
                listOfOwnPosts.Reverse();
            }
            var data1 = LoadComments(int.Parse(postID));
            List<Comment> listOfComments = new List<Comment>();
            for (int i = 0; i < data1.Count; i++)
            {
                listOfComments.Add(new Comment()
                {
                    PostID = data1[i].PostID,
                    UserID = data1[i].UserID,
                    CommentAuthor = data1[i].CommentAuthor,
                    CommentText = data1[i].CommentText,
                    CommentDate = data1[i].CommentDate,
                });
                listOfComments.Reverse();
            }
            GroupAndPost cp = new GroupAndPost();
            cp.Comments = listOfComments;
            cp.Posts = listOfOwnPosts;
            return View(cp);
        }
        public ActionResult ListSearchP(Post model)
        {
            string PostTitle= postTitle;
            var data = ListSearch(PostTitle);
            List<Post> posts = new List<Post>();
            foreach (var item in data)
            {
                posts.Add(new Post
                {
                    PostTitle = item.PostTitle,
                    PostContent = item.PostContent,
                    PostDate = item.PostDate,
                    PostAuthor = item.PostAuthor,
                    UserID = item.UserID,
                });
                posts.Reverse();
            }
            return View(posts);
        }
        public ActionResult DeletePost()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(Post model)
        {
            ModelState.Remove("PostAuthor");
            ModelState.Remove("PostContent");
            if (ModelState.IsValid)
            {
                int recordsCreated = DeletePosts(model.PostTitle);
                if (recordsCreated==0)
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('Nothing Found！');history.go(-1);location.reload();</script>");
                }
                else
                {
                    return RedirectToAction("MyPost", "Groups");
                }

                    
            }
            return View();
        }
        public ActionResult JoinGroup(UserGroup model)
        {
            ModelState.Remove("UserId");
            ModelState.Remove("UserName");
            ModelState.Remove("GroupId");
            if (ModelState.IsValid)
            {
                model.UserId = int.Parse(AccountController.userID);
                model.UserName = AccountController.username;
                if (GetGroupID(model.GroupName) == "Nothing")
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('Nothing Found！');history.go(-1);location.reload();</script>");
                }
                else
                {
                    model.GroupId = int.Parse(GetGroupID(model.GroupName));
                    int recordsCreated = JoinGroups(model.UserId, model.UserName, model.GroupId, model.GroupName);
                    postTitle = model.GroupName;
                    return RedirectToAction("GroupList", "Groups");
                }      
            }
            return View();
        }
        public ActionResult LeaveGroup()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LeaveGroup(UserGroup model)
        {
            ModelState.Remove("UserId");
            ModelState.Remove("UserName");
            ModelState.Remove("GroupId");
            if (ModelState.IsValid)
            {
                int recordsCreated = LeaveGroupss(model.GroupName);
                if (recordsCreated == 0)
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('Nothing Found！');history.go(-1);location.reload();</script>");
                }
                else
                {
                    return RedirectToAction("GroupList", "Groups");
                }
                
                
            }
            return View();
        }
        public ActionResult Savedpost(UserPost model)
        {
            string userName = AccountController.username;
            var data = SavedPosts(userName);
            List<UserPost> posts = new List<UserPost>();
            foreach (var item in data)
            {
                posts.Add(new UserPost
                {
                    PostTitle = item.PostTitle,
                    PostContent = item.PostContent,
                    PostDate = item.PostDate,
                    PostAuthor = item.PostAuthor,
                    UserId = item.UserId,
                });
                posts.Reverse();
            }
            return View(posts);
        }
        public ActionResult SearchPostForSave(UserPost model)
        {
            ModelState.Remove("UserId");
            ModelState.Remove("UserName");
            ModelState.Remove("PostId");
            if (ModelState.IsValid)
            {
                model.UserId = int.Parse(AccountController.userID);
                model.UserName = AccountController.username;
                if (GetPostID(model.PostTitle) == "Nothing")
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('Nothing Found！');history.go(-1);location.reload();</script>");
                }
                else
                {
                model.PostId = int.Parse(GetPostID(model.PostTitle));
                    int recordsCreated = SearchPostsForSave(model.UserId, model.UserName, model.PostId, model.PostTitle);
                    //int recordsCreated2 = SearchPostsForSave2(model.PostTitle);
                    postTitle = model.PostTitle;
                    return RedirectToAction("Savedpost", "Groups");
                }
            }
            return View();
        }
        public ActionResult DeleteSavedPost()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSavedPost(UserPost model)
        {
            ModelState.Remove("UserId");
            ModelState.Remove("UserName");
            ModelState.Remove("PostId");
            if (ModelState.IsValid)
            {
                int recordsCreated = DeleteSavedPosts(model.PostTitle);
                if (recordsCreated == 0)
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('Nothing Found！');history.go(-1);location.reload();</script>");
                }
                else
                {
                    return RedirectToAction("Savedpost", "Groups");
                }
            }
            return View();
        }
        public static string postID;
        public static string groupID;
        public static string postTitle;
        public static string GroupName;
        public static string PostName;
    }
}
