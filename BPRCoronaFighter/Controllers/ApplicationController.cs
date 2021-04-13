using BPRCoronaFighter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DataLibrary.BusinessLogic.UserProcessor;

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
            ViewBag.Gender = new SelectList(new[] { "Male", "Female" });
            ViewBag.Message = "Doctors Application";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DoctorSignUp(Application model)
        {
            ViewBag.Gender = new SelectList(new[] { "Male", "Female" });
            if (ModelState.IsValid)
            {
                //int recordsCreated = CreateDoctor(model.FirstName, model.LastName, model.Email, model.Password, model.Dob, model.Gender, model.Document);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

    }
}