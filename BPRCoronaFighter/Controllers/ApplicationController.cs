using BPRCoronaFighter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BPRCoronaFighter.Controllers
{
    public class ApplicationController : Controller
    {
        // GET: Application
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DoctorSignUp()
        {
            ViewBag.Message = "Doctors Application";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DoctorSignUp(Application model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}