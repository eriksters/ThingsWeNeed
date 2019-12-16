using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using ThingsWeNeed.Data.Core;
using ThingsWeNeed.Service.Controllers.Users;
using ThingsWeNeed.Shared;

namespace ThingsWeNeed.Service.Controllers.Login
{
    public class LoginMvcController : Controller
    {
        // GET: Login
        [Route("Login")]
        public ActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public async Task<ActionResult> AuthorizeAsync(LoginViewModel loginViewModel)
        {
            UsersApiController usersApiController = new UsersApiController();
            LoginBinder loginBinder = new LoginBinder()
            {
                Username = loginViewModel.UserName,
                Password = loginViewModel.Password
            };

            var result = await usersApiController.Login(loginBinder);

            if (result is OkResult)
            {
                int userId = 0;
                using(TwnContext context = new TwnContext())
                {
                    var user = context.Users.Where(u => u.UserName.Equals(loginViewModel.UserName)).FirstOrDefault();
                    userId = Int32.Parse(user.Id);
                }
                return RedirectToRoute("Households/" + userId);
            }
            else
            {
                return View("Login", loginViewModel);
            }
            
        }
    }
}