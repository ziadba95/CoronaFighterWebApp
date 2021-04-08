using BPRCoronaFighter.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DataLibrary.BusinessLogic.PostProcessor;
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
                model.UserID = AccountController.userID;
                model.PostAuthor = AccountController.username;
                int recordsCreated = CreatePosts(model.PostTitle, model.PostContent, DateTime.Now.ToString(), model.PostAuthor, model.UserID);
                return RedirectToAction("Index", "Groups");
            }
            return View();
        }
       
    }
}
