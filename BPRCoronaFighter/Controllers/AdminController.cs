using BPRCoronaFighter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DataLibrary.BusinessLogic.VideoProcessor;
using static DataLibrary.BusinessLogic.UserProcessor;

namespace BPRCoronaFighter.Controllers
{
    public class AdminController : Controller
    {
        // GET: AdminPanel
        public ActionResult AdminPanel(Application model)
        {
            ViewBag.UserName=AccountController.username;
            var data = LoadDoctorsWaiting();
            List<Application> application = new List<Application>();
            foreach (var item in data)
            {
                application.Add(new Application
                {
                    ApplicationId = item.ApplicationId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    Password = item.Password,
                    Dob = item.Dob,
                    Gender = item.Gender,
                    AppStatus = item.AppStatus,
                    ApplicationDate = item.ApplicationDate,
                });
                application.Reverse();
            }
            return View(application);
        }

        // GET: AdminMyAccount
        public ActionResult AdminMyAccount()
        {
            return View();
        }

        // GET: ApprovedUsers
        public ActionResult AdminApprovedUsers(Application model)
        {
            ModelState.Remove("FirstName");
            ModelState.Remove("LastName");
            ModelState.Remove("Dob");
            ModelState.Remove("Gender");
            ModelState.Remove("Password");
            if (ModelState.IsValid)
            {
                int recordsCreated = ApproveApp(model.Email);
                if (recordsCreated == 0)
                {
                    return Content("<script language='javascript' type='text/javascript'>"+
                        "alert('Nothing Found！');history.go(-1);location.reload();</script>");
                }
                else
                {
                    return RedirectToAction("AdminPanel", "Admin");
                }
            }
            return View();
        }

        // GET: DeclinedUsers
        public ActionResult AdminDeclinedUsers(Application model)
        {
            ModelState.Remove("FirstName");
            ModelState.Remove("LastName");
            ModelState.Remove("Dob");
            ModelState.Remove("Gender");
            ModelState.Remove("Password");
            if (ModelState.IsValid)
            {
                int recordsCreated = DeclineApp(model.Email);
                if (recordsCreated == 0)
                {
                    return Content("<script language='javascript' type='text/javascript'>" + 
                        "alert('Nothing Found！');history.go(-1);location.reload();</script>");
                }
                else
                {
                    return RedirectToAction("AdminPanel", "Admin");
                }
            }
            return View();
        }

        public ActionResult AdminVideoLibrary(Video model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = AddVideo(model.VideoTitle, model.VideoURL, model.ImageLink);
                return RedirectToAction("VideoLibrary", "Admin");
            }
            return View();
        }

        // GET: AdminVideoLibrary
        public ActionResult VideoLibrary()
        {
            ViewBag.UserName = AccountController.username;
            ViewBag.Message = "Video List";
            var data = LoadVideos();
            List<Video> videos = new List<Video>();
            foreach (var item in data)
            {
                videos.Add(new Video
                {
                    VideoTitle = item.VideoTitle,
                    VideoURL = item.VideoURL,
                    ImageLink = item.ImageLink,
                });
            }
            return View(videos);
        }
        public ActionResult RemoveVideos()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveVideos(Video model)
        {
            ModelState.Remove("VideoURL");
            ModelState.Remove("ImageLink");
            if (ModelState.IsValid)
            {
                int recordsCreated = RemoveVideo(model.VideoTitle);
                if (recordsCreated == 0)
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('Nothing Found！');history.go(-1);location.reload();</script>");
                }
                else
                {
                    return RedirectToAction("VideoLibrary");
                } 

            }
            return View();
        }

    }
}