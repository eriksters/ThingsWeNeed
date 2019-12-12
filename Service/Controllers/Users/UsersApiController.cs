using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using ThingsWeNeed.Data.User;
using ThingsWeNeed.Service.Identity;
using ThingsWeNeed.Shared;
using ThingsWeNeed.Shared.REST;

namespace ThingsWeNeed.Service.Controllers.Users
{
    [Authorize]
    public class UsersApiController : ApiController
    {
        private TwnSignInManager _signInManager;
        private TwnUserManager _userManager;

        public UsersApiController()
        {
        }

        public TwnSignInManager SignInManager {
            get => _signInManager ?? Request.GetOwinContext().Get<TwnSignInManager>();
            set => _signInManager = value;
        }

        public TwnUserManager UserManager {
            get => _userManager ?? Request.GetOwinContext().Get<TwnUserManager>();
            set => _userManager = value;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/Users/Login")]
        public async Task<IHttpActionResult> Login(LoginBinder binder)
        {
            IHttpActionResult result;
            if (!Request.GetOwinContext().Authentication.User.Identity.IsAuthenticated) {
                if (ModelState.IsValid)
                {
                    if (binder != null) {
                        
                        // Password sign in 
                        var res = await SignInManager.PasswordSignInAsync(binder.Username, binder.Password, isPersistent: false, shouldLockout: false);

                        if (res == SignInStatus.Success)
                        {
                            //  All OK
                            result = Ok();
                        }
                        else
                        {
                            //  Login unsuccessful
                            result = Unauthorized();
                        }
                    }
                    else
                    {
                        //  Request body empty
                        result = BadRequest("No Login Data given");
                    }
                }
                else
                {
                    //  Model errors
                    result = BadRequest(ModelState);
                }
            }
            else
            {
                //  user already signed in
                result = BadRequest("User already Signed In, try restarting the application.");
            }
            return result;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/Users/Register")]
        public async Task<IHttpActionResult> Register(RegisterBinder binder)
        {
            IHttpActionResult result;

            //  If model state is valid (no missing data, etc)
            if (ModelState.IsValid)
            {
                //  Create user entity to be stored
                UserEntity user = new UserEntity
                {
                    Email = binder.Email,
                    UserName = binder.Username,
                    FName = binder.FName,
                    LName = binder.LName
                };

                //  Create user identity with password
                var res = await UserManager.CreateAsync(user, binder.Password);

                //  If created successfully
                if (res.Succeeded)
                {
                    //  Sign user in
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    result = Ok();
                }
                else
                {
                    //  Unsuccessful registation
                    result = GetErrorResult(res);
                }
            }
            else
            {
                //  Model state errors
                result = BadRequest(ModelState);
            }

            return result;
        }

        [HttpPost]
        [Route("api/Users/LogOff")]
        public IHttpActionResult LogOff() {

            Request.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            return Ok();
        }

        [HttpPut]
        [Route("api/Users")]
        public IHttpActionResult Update(UserDto dto) {

            if (ModelState.IsValid)
            {
                dto.Id = Request.GetOwinContext().Authentication.User.Identity.GetUserId();
                UserManager.Update(dto);
                return Ok(dto);
            }
            else 
            {
                return BadRequest(ModelState);
            }
        }



        private IHttpActionResult GetErrorResult(IdentityResult identityRes) {

            if (identityRes.Errors != null)
            {
                foreach (string error in identityRes.Errors)
                {
                    ModelState.AddModelError("", error);
                }
            }

            return BadRequest(ModelState);
        }
    }
}