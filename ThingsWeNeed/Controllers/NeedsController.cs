using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThingsWeNeed.Models;
using ThingsWeNeed.Models.ViewModels;
using ThingsWeNeed.Models.Binders;

namespace ThingsWeNeed.Controllers
{
    public class NeedsController : Controller
    {
        public ActionResult List() {
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

        [ValidateInput(false)]
        [HttpPost]
        //[Route("/Needs/Create")]
        public ActionResult Create([Bind(Prefix = "CreateNeeds",Include = "ThingId")] CreateNeedsReturn t) {
            Purchase p = new Purchase();
            Debug.WriteLine(String.Format("---Start---\n{0}\n---End---", t.CreateThings.Count));
            //if (result != null)
            //{
            //    if (result.CreateThings.Count > 0)
            //    {
            //        Debug.WriteLine(String.Format(
            //            "Thing id: {0}\nThing price: {1}",
            //            result.CreateThings[0].ThingId,
            //            result.CreateThings[0].ThingPrice));
            //    }
            //    else
            //    {
            //        Debug.WriteLine("List of things has {0} elements.", result.CreateThings.Count);
            //    }
            //}
            //else
            //{
            //    Debug.WriteLine("The result is null");
            //}

            return Content("Purchases");

        }
    }
}