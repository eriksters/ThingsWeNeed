using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThingsWeNeed.Models;

namespace ThingsWeNeed.Controllers {
    public class HomeController : Controller {
        public ActionResult Index()
        {
            ModelContainer mc = new ModelContainer();

            return View("ThingsListView", mc.Households.Find(1));
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            AppUser user = new AppUser() {
                Email = "eriksters@gmail.com",
                FName = "Eriks",
                LName = "Petersons",
                UserId = 12,
                PhoneNumber = "81917581",
            };



            return View();
        }
    }
}