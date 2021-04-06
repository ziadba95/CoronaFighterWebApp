using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BPRCoronaFighter.Models;
namespace BPRCoronaFighter.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.UserName = "Welcome: "+AccountController.username;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About us";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact us";

            return View();
        }
    }
}