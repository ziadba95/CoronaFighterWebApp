using BPRCoronaFighter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DataLibrary.BusinessLogic.VideoProcessor;

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

        public ActionResult RemoveVideos(int index)
        {
            
            DeleteVideos(index);
            
            return RedirectToAction("VideoLibrary");
        }

    }
}