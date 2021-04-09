using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BPRCoronaFighter.Models;
namespace BPRCoronaFighter.Controllers
{
    public class GroupAndPostController : Controller
    {
        // GET: CommentAndPost
        public ActionResult Index()
        {
            GroupAndPost cp = new GroupAndPost();
            return View(cp);
        }
    }
}