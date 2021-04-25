using BPRCoronaFighter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DataLibrary.BusinessLogic.LectureProcessor;

namespace BPRCoronaFighter.Controllers
{
    public class LectureController : Controller
    {
        // GET: Lecture
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (Lecture model)
        {
            if (ModelState.IsValid)
            {
                bool isdup = CheckDup(model.LectureTitle);
                if (isdup)
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('Title already exist！');history.go(-1);location.reload();</script>");
                }
                else
                {
                    //string ID = GetLectureID(model.LectureTitle);
                    //lectureID = ID;
                    model.UserID = AccountController.userID;
                    model.LectureAuthor = AccountController.username;
                    int recordsCreated = CreateLecture(model.LectureTitle, model.LectureDescription, model.LectureLink, model.LectureDate, model.LectureTime, model.LectureAuthor,model.UserID);
                    return RedirectToAction("Index", "Lecture");
                }
            }
            return View();
        }

        public ActionResult Index(Lecture model)
        {
            var data = LoadLectures();
            List<Lecture> lectures = new List<Lecture>();
            foreach (var item in data)
            {
                lectures.Add(new Lecture
                {
                    LectureTitle = item.LectureTitle,
                    LectureDescription = item.LectureDescription,
                    LectureLink = item.LectureLink,
                    LectureDate = item.LectureDate,
                    LectureTime = item.LectureTime,
                    numOfLike = item.numOfLike,
                    LectureAuthor = item.LectureAuthor,
                });
                lectures.Reverse();
            }
            return View(lectures);
        }
        public ActionResult MyLecture(Lecture model)
        {
            string UserID = AccountController.userID;
            var data = LoadLecturesByUser(UserID);
            List<Lecture> lectures = new List<Lecture>();
            foreach (var item in data)
            {
                lectures.Add(new Lecture
                {
                    LectureTitle = item.LectureTitle,
                    LectureDescription = item.LectureDescription,
                    LectureLink = item.LectureLink,
                    LectureDate = item.LectureDate,
                    LectureTime = item.LectureTime,
                });
                lectures.Reverse();
            }
            return View(lectures);
        }

        public ActionResult Like(Lecture model)
        {
            LikeAddL(model.numOfLike,model.LectureId);
            return RedirectToAction("Index");
        }
        public static string lectureID;
    }
}