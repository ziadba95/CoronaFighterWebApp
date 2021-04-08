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
                int recordsCreated = CreateLecture(model.LectureTitle, model.LectureDescription, model.LectureLink,model.LectureDate, model.LectureTime);
                return RedirectToAction("Index", "Lecture");
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
                    numOfLike = item.numOfLike
                });
                lectures.Reverse();
            }
            return View(lectures);
        }
        
        public ActionResult Like(Lecture model)
        {
            bool flag = true;
            if (flag)
            {
                LikeAdd(model.numOfLike);
                flag = false;
            }
            
            return RedirectToAction("Index");
        }

    }
}