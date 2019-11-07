using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using ThingsWeNeed.Models;
using ThingsWeNeed.Models.ViewModels;

namespace ThingsWeNeed.Controllers {
    public class HomeController : Controller {
        public ActionResult Index()
        {
            int userId = 1;

            //  Open database connection
            using (ModelContainer mc = new ModelContainer())
            {   
                //  If household is not found, show 404 page
                //if (household == null)
                //{
                //    return HttpNotFound($"Household with the id [{userId}] not found.");
                //}

                //  Create View Model
                ThingsListViewModel model = new ThingsListViewModel ("Needs") {
                    //  Eager load the purchases
                    //  (Decreases times the database needs to be accessed, no DB access happens in the views layer)
                    User = mc.AppUsers
                        .Include("Households")
                        .Include("Households.Things")
                        .Include("Households.Things.Purchases")
                        .Single(x => x.UserId == userId)

                };

                //  Return View with complete ViewModel
                return View("ThingsListView", model);
            }
        }

        [HttpPost]
        public ActionResult Index(IList<Purchase> map) {
            Purchase p = new Purchase();
            return Content("Purchases");
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