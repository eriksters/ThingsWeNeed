using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThingsWeNeed.Service.Controllers.Users
{
    [Authorize]
    public class UsersMvcController : Controller
    {
        [AllowAnonymous]
        [Route("Login")]
        [Route("Users/Login")]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [Route("Register")]
        [Route("Users/Register")]
        public ActionResult Register()
        {
            return View();
        }
    }
}