using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BPRCoronaFighter.Models;
namespace BPRCoronaFighter.Controllers
{
    public class CommentAndPostController : Controller
    {
        // GET: CommentAndPost
        public ActionResult Index()
        {
            CommentAndPost cp = new CommentAndPost();
            return View(cp);
        }
    }
}