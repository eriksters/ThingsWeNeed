using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThingsWeNeed.Models;
using ThingsWeNeed.Models.ViewModels;
using ThingsWeNeed.Models.Binders;
using TwnData;

namespace ThingsWeNeed.Controllers
{
    public class NeedsController : Controller
    {
        public TwnContext context { get; set; }

        public NeedsController()
        {
            context = new TwnContext();
        }

        public NeedsController(TwnContext context) {
            this.context = context;
        }

        public ActionResult List() {
            int userId = 1;

            //  Open database connection
            using (context) {
                try
                {
                    ThingsListViewModel model = new ThingsListViewModel("Needs")
                    {
                        //  Eager load the purchases
                        //  (Decreases times the database needs to be accessed, no DB access happens in the views layer)

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