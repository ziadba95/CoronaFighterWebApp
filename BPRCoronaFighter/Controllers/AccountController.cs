using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BPRCoronaFighter.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }


        //Sign up method
        public ActionResult SignUp()
        {
            ViewBag.Message = " User Sign Up";
            return View();
        }
    }
}