using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ThingsWeNeed.Data.Core;
using ThingsWeNeed.Data.Household;
using ThingsWeNeed.Shared;

namespace ThingsWeNeed.Service.Controllers.Household
{
    public class HouseholdMvcController : Controller
    {
        private TwnContext context;
        private string userId;

        public HouseholdMvcController()
        {
            context = new TwnContext();
            userId = Request.GetOwinContext().Authentication.User.Identity.GetUserId();
        }
        
        [Route("Households/{id}")]
        [HttpGet]
        public ActionResult Details([Bind(Include = "id")] int id)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.ToString());
            }
            else
            {
                HouseholdDto household;
                using (var householdLogic = new HouseholdDaLogic(context, userId))
                {
                    household = householdLogic.GetById(id);
                }

                HouseholdViewModel viewModel = new HouseholdViewModel()
                {
                    Household = household,
                    Name = household.Name
                };
                return View("HouseholdDetails", viewModel);
            }
        }

        [Route("Households/User/{userId}")]
        [HttpGet]
        public ActionResult HouseholdCollection([Bind(Include="userId")] string userId)
        {
            ICollection<HouseholdDto> households;

            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.ToString());
            }
            else
            {
                using (var householdLogic = new HouseholdDaLogic(new TwnContext(), userId))
                {
                    households = householdLogic.GetCollection(userId);
                }

                HouseholdViewModel viewModel = new HouseholdViewModel()
                {
                    Households = households
                }; 

                return View("NeedsList", viewModel);
            }
        }
    }
}