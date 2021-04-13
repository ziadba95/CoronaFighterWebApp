using BPRCoronaFighter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DataLibrary.BusinessLogic.UserProcessor;

namespace BPRCoronaFighter.Controllers
{
    public class AccountController : Controller
    {
        
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChangePass(User model)
        {
            ModelState.Remove("FirstName");
            ModelState.Remove("LastName");
            ModelState.Remove("Gender");
            ModelState.Remove("RoleType");
            ModelState.Remove("Dob");
            ModelState.Remove("PasswordConfirm");
            ModelState.Remove("Email");
            if (ModelState.IsValid)
            {
                string UserID = userID;
                int recordsCreated = ChangePassword(model.Password, UserID);
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Login(User model)
        {
            ModelState.Remove("FirstName");
            ModelState.Remove("LastName");
            ModelState.Remove("Gender");
            ModelState.Remove("RoleType");
            ModelState.Remove("Dob");
            ModelState.Remove("PasswordConfirm");
            if (ModelState.IsValid)
            {
                bool recordsCreated = LogIn(model.Email, model.Password);
                if (recordsCreated)
                {
                    string fname = GetFName(model.Email);
                    string lname = GetLName(model.Email);
                    string ID = GetUserID(model.Email);
                    string role = GetRoleType(model.Email);
                    userID = ID;
                    username = fname+" "+ lname + " (" + role + ")";
                    userRole = role;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('Log in fail！');history.go(-1);location.reload();</script>");
                }
                        
            }
               return View();


        }

        //Sign up method
        public ActionResult SignUp()
        {
            ViewBag.UserType = new SelectList(new[] {  "Patient", "Volunteer" });
            ViewBag.Gender =    new SelectList(new[] {  "Male", "Female" });
            ViewBag.Message = " User Sign Up";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(User model)
        {
            ViewBag.UserType = new SelectList(new[] { "Patient", "Volunteer" });
            ViewBag.Gender = new SelectList(new[] { "Male", "Female" });
            if (ModelState.IsValid)
            {
                bool isdup = CheckDup(model.Email);
                if (isdup)
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('Email already used！');history.go(-1);location.reload();</script>");
                }
                else
                {
                    int recordsCreated = CreateUser(model.FirstName, model.LastName, model.Email, model.Password, model.Dob, model.Gender, model.RoleType);
                    username = model.FirstName + " " + model.LastName+" ("+ model.RoleType + ")";
                    string ID = GetUserID(model.Email);
                    userRole = model.RoleType;
                    userID = ID;
                    return RedirectToAction("Index", "Home");
                }
                
            }
            return View();
        }

        //TEST Method To View Users
        //public ActionResult ViewUsers()
        //{
        //    ViewBag.Message = "Users List";
        //    var data = LoadUsers();
        //    List<User> users = new List<User>();
        //    foreach (var item in data)
        //    {
        //        users.Add(new User
        //        {
        //            FirstName = item.FirstName,
        //            LastName = item.LastName,
        //            Email = item.Email,
        //            Gender = item.Gender,
        //            RoleType = item.RoleType
        //        });
        //    }
        //    return View(users);
        //}
        public static string username="New user";
        public static string userID ;
        public static string userRole;
    }
}