using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using ThingsWeNeed.Models;
using ThingsWeNeed.Models.ViewModels;

namespace ThingsWeNeed.Controllers {
    public class HomeController : Controller {
        public ActionResult Index()
        {

            int householdId = 1;

            //  Instantiate
            ThingsListViewModel model = new ThingsListViewModel();
            ModelContainer mc = new ModelContainer();
            mc.Households.Include("Thing.Purchases");
            

            //  Find the household
            Household household = mc.Households.Find(householdId);

            //If household is not found, throw 404 page
            if (household == null)
            {
                return HttpNotFound($"Household with the id [{householdId}] not found.");
            }

            model.ThingsList = household.Things;

            return View("ThingsListView", model);
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