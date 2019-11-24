using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwnData;
using ThingsWeNeed.Models.ViewModels;
using System.Diagnostics;
using System.Data.Entity;

namespace ThingsWeNeed.Controllers
{
    public class ThingsController : Controller
    {

        private TwnContext context;

        public ThingsController(TwnContext context) {
            this.context = context;
        }

        public ThingsController() {
            context = new TwnContext();
        }

        //Default route
        [Route("Things/List")]
        public ActionResult List()
        {
            int userId = 1;
            //  Open database connection
            using (context)
            {
                try
                {
                    ThingsListViewModel model = new ThingsListViewModel("Needs")
                    {
                        //  Eager load the households and purchases
                        //  (Decreases times the database needs to be accessed, no DB access happens in the views layer)
                        Title = "Household list",
                        User = context.Users
                            .Include("Households")
                            .Include("Households.Things") 
                            .Include("Households.Things.Purchases")
                            .Single(x => x.UserId == userId)
                    };
                    //  Return View with complete ViewModel
                    return View("NeedsList", model);
                }
                catch (InvalidOperationException e)
                {
                    Debug.WriteLine(e.Message);
                    Debug.WriteLine(e.InnerException);

                    return View("Error");
                }
            }
        }
    }
}