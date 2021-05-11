using BPRCoronaFighter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DataLibrary.BusinessLogic.OfferHelpProcessor;
namespace BPRCoronaFighter.Controllers
{
    public class OfferHelpController : Controller
    {
        // GET: OfferHelp
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OfferHelp model)
        {
            if (ModelState.IsValid)
            {
                bool isdup = CheckDupH(model.HelpTitle);
                if (isdup)
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('Title already exist！');history.go(-1);location.reload();</script>");
                }
                else
                {
                    model.UserID = AccountController.userID;
                    model.UserName = AccountController.username;
                    int recordsCreated = CreateOfferHelp(model.UserID, model.UserName, model.HelpDescription, model.HelpDate, model.HelpTime, model.FreeHour, model.Contact, model.HelpTitle,model.City);
                    return RedirectToAction("Index", "OfferHelp");
                }
                
            }
            return View();
        }

        public ActionResult Index(OfferHelp model)
        {
            var data = LoadOfferHelp();
            List<OfferHelp> offerHelps = new List<OfferHelp>();
            foreach (var item in data)
            {
                offerHelps.Add(new OfferHelp
                {
                    UserID = item.UserID,
                    UserName = item.UserName,
                    HelpTitle=item.HelpTitle,
                    HelpDescription = item.HelpDescription,
                    HelpDate = item.HelpDate,
                    HelpTime = item.HelpTime,
                    FreeHour = item.FreeHour,
                    Contact = item.Contact,
                    City=item.City,
                });
                offerHelps.Reverse();
            }
            return View(offerHelps);
        }
        public ActionResult MyOfferHelp(OfferHelp model)
        {
            string UserID = AccountController.userID;
            var data = LoadOfferHelpByUser(UserID);
            List<OfferHelp> offerHelps = new List<OfferHelp>();
            foreach (var item in data)
            {
                offerHelps.Add(new OfferHelp
                {
                    UserID = item.UserID,
                    UserName = item.UserName,
                    HelpTitle = item.HelpTitle,
                    HelpDescription = item.HelpDescription,
                    HelpDate = item.HelpDate,
                    HelpTime = item.HelpTime,
                    FreeHour = item.FreeHour,
                    Contact = item.Contact,
                    City = item.City,
                });
                offerHelps.Reverse();
            }
            return View(offerHelps);
        }


        //public static string helpID;
        public ActionResult DeleteOfferHelp()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteOfferHelp(OfferHelp model)
        {
            ModelState.Remove("HelpDescription");
            ModelState.Remove("HelpDate");
            ModelState.Remove("HelpTime");
            ModelState.Remove("FreeHour");
            ModelState.Remove("Contact");
            ModelState.Remove("City");
            if (ModelState.IsValid)
            {
                int recordsCreated = DeleteOfferHelps(model.HelpTitle);
                if (recordsCreated == 0)
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('Nothing Found！');history.go(-1);location.reload();</script>");
                }
                else
                {
                    return RedirectToAction("MyOfferHelp", "OfferHelp");
                }


            }
            return View();
        }
    }
}