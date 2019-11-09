using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThingsWeNeed.Models;
using ThingsWeNeed.Models.ViewModels;

namespace ThingsWeNeed.Controllers
{
    public class NeedsController : Controller
    {
        public ActionResult Index() {
            int userId = 1;

            //  Open database connection
            using (ModelContainer mc = new ModelContainer()) {
                //  If household is not found, show 404 page
                //if (household == null)
                //{
                //    return HttpNotFound($"Household with the id [{userId}] not found.");
                //}

                //  Create View Model
                ThingsListViewModel model = new ThingsListViewModel("Needs") {
                    //  Eager load the purchases
                    //  (Decreases times the database needs to be accessed, no DB access happens in the views layer)
                    User = mc.AppUsers
                        .Include("Households")
                        .Include("Households.Things")
                        .Include("Households.Things.Purchases")
                        .Single(x => x.UserId == userId)

                };

                //  Return View with complete ViewModel
                return View("NeedsList", model);
            }
        }

        [HttpPost]
        public ActionResult Index(IList<Purchase> map) {
            Purchase p = new Purchase();
            return Content("Purchases");
        }
    }
}