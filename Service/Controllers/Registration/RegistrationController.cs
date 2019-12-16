using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThingsWeNeed.Service.Controllers.Registration;

namespace ThingsWeNeed.Service.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View("Registration");
        }

        public ActionResult Registration(RegistrationViewModel registrationViewModel)
        {
            return View();
        }
    }
}