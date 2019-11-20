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
                try
                {
                    ThingsListViewModel model = new ThingsListViewModel("Needs")
                    {
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
                } catch (InvalidOperationException e) {
                    Debug.WriteLine(e.Message);
                    Debug.WriteLine(e.InnerException);

                    return View("Error");
                }


                
                
            }
        }

        public ActionResult AddThing() {
            return View(new ThingsListViewModel("Add thing"));
        }


        //  Action for handling purchases
        [HttpPost]
        public ActionResult Purchase([Bind(Prefix = "purchases", Include = "ThingId, ThingPrice")] CreateNeedData[] purchases) {
            string str = "";
            
            //  TODO
            //  if request contains needed things, handle 'em

            if (purchases != null)
            {
                for (int i = 0; i < purchases.Length; i++)
                {
                    str = $"{str}{i}: {purchases[i].ThingId}, {purchases[i].ThingPrice}\n";
                }
                Debug.WriteLine(String.Format("---Start---\n{0}\n---End---", str));
            }

            //  Dummy return
            return Content("Purchases");
        }
    }
}