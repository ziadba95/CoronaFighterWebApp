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
namespace BPRCoronaFighter.Controllers
{
    public class GroupsController : Controller
    {
        private BPRCoronaFighterContext db = new BPRCoronaFighterContext();

        // GET: Groups
        public ActionResult Index()
        {
            ViewBag.UserName =  AccountController.username;
            var data = LoadPosts();
            List<Post> post = new List<Post>();
            foreach (var item in data)
            {
                post.Add(new Post
                {
                    PostTitle = item.PostTitle,
                    PostContent = item.PostContent,
                    PostDate = item.PostDate,
                    PostAuthor=item.PostAuthor,
                    UserID=item.UserID,
                    numOfLike = item.numOfLike
                });
            post.Reverse();
            }
            return View(post);
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
                bool isdup = CheckDup(model.PostTitle);
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
                int recordsCreated = CreateComment( model.CommentText,model.UserID,model.PostID, DateTime.Now.ToString(), model.CommentAuthor);
                return RedirectToAction("Index", "Groups");
                
            }
            return View();
        }
        public ActionResult ViewComment()
        {
            var data = LoadComments();
            List<Comment> comment = new List<Comment>();
            foreach (var item in data)
            {
                comment.Add(new Comment
                {
                    PostID = item.PostID,
                    UserID = item.UserID,
                    CommentText = item.CommentText,
                });
                comment.Reverse();
            }
            return View(comment);
        }
        public static string postID;
    }
}
