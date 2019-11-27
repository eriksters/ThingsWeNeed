using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThingsWeNeed.Service.Controllers.Thing
{
    public class ThingsMvcController : Controller
    {
        // GET: ThingsMvc
        public ActionResult Index()
        {
            return View();
        }
    }
}