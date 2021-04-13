﻿using BPRCoronaFighter.Models;
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
namespace BPRCoronaFighter.Controllers
{
    public class GroupsController : Controller
    {
        private BPRCoronaFighterContext db = new BPRCoronaFighterContext();

        // GET: Groups
        public ActionResult Index(Post model,Group model1, Comment model2)
        {
            ViewBag.UserName = AccountController.username;
            ViewBag.UserRole = AccountController.userRole;
            var data = LoadPosts();
            List<Post> listOfPosts = new List<Post>();
                for (int i = 0; i < data.Count; i++) { 
                listOfPosts.Add(new Post()
                {
                    PostTitle = data[i].PostTitle,
                    PostContent = data[i].PostContent,
                    PostDate = data[i].PostDate,
                    PostAuthor = data[i].PostAuthor,
                    UserID = data[i].UserID,
                    numOfLike = data[i].numOfLike
                });
                listOfPosts.Reverse();
            }
            var data1 = LoadGroups();
            List<Group> listOfGroups = new List<Group>();
            for (int i = 0; i < data1.Count; i++)
            {
                listOfGroups.Add(new Group
                {
                    GroupName = data1[i].GroupName,
                    GroupTime = data1[i].GroupTime,
                    GroupCreater = data1[i].GroupCreater,
                    UserID = data1[i].UserID,
                });
                listOfGroups.Reverse();
            }
            var data3 = LoadComments();
            List<Comment> listOfComments = new List<Comment>();
            for (int i = 0; i < data3.Count; i++)
            {
                listOfComments.Add(new Comment()
                {
                    PostID = data3[i].PostID,
                    UserID = data3[i].UserID,
                    CommentText = data3[i].CommentText,
                    CommentDate = data3[i].CommentDate,
                });
                listOfComments.Reverse();
            }
            GroupAndPost cp = new GroupAndPost();
            cp.Comments = listOfComments;
            cp.Groups = listOfGroups;
            cp.Posts = listOfPosts;
            return View(cp);
        }
        //public ActionResult ViewGroup(Group model)
        //{
        //    var data = LoadGroups();
        //    List<Group> listOfGroups = new List<Group>();
        //    for (int i = 0; i < data.Count; i++)
        //    {
        //        listOfGroups.Add(new Group
        //        {
        //            GroupName = data[i].GroupName,
        //            GroupTime = data[i].GroupTime,
        //            GroupCreater = data[i].GroupCreater,
        //            UserID = data[i].UserID,
        //        });
        //        listOfGroups.Reverse();
        //    }
        //    GroupAndPost cp = new GroupAndPost();
        //    cp.Groups = listOfGroups;

        //    return View(cp);
        //}

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
                    int recordsCreated = CreatePosts(model.PostTitle, model.PostContent, DateTime.Now.ToString(), model.PostAuthor, model.UserID);
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
        public ActionResult CreateGroups(Group model)
        {
            if (ModelState.IsValid)
            {
                bool isdup = CheckDupG(model.GroupName);
                if (isdup)
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('Group already exist！');history.go(-1);location.reload();</script>");
                }
                else
                {
                    model.UserID = AccountController.userID;
                    model.GroupCreater = AccountController.username;
                    int recordsCreated = CreateGroup(model.GroupName,DateTime.Now.ToString(), model.GroupCreater, model.UserID);
                    groupID = GetGroupID(model.GroupName);
                    return RedirectToAction("Index", "Groups");
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
                return RedirectToAction("Index", "Groups");
                
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

        public static string postID;
        public static string groupID;
    }
}
