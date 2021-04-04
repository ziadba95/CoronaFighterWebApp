using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BPRCoronaFighter.Controllers
{
    public class AdminController : Controller
    {
        // GET: AdminPanel
        public ActionResult AdminPanel()
        {
            return View();
        }

        // GET: AdminMyAccount
        public ActionResult AdminMyAccount()
        {
            return View();
        }

        // GET: ApprovedUsers
        public ActionResult AdminApprovedUsers()
        {
            return View();
        }

        // GET: DeclinedUsers
        public ActionResult AdminDeclinedUsers()
        {
            return View();
        }

        // GET: AdminVideoLibrary
        public ActionResult AdminVideoLibrary()
        {
            return View();
        }
    }
}