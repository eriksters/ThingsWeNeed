using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using ThingsWeNeed.Data.Household;
using ThingsWeNeed.Shared;

namespace ThingsWeNeed.Service.Controllers.Household
{
    public class HouseholdMvcController : Controller
    {
        
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
                using (var householdLogic = new HouseholdLogic())
                {
                    household = householdLogic.GetById(id);
                }

                return View("NeedsList", household);
            }
        }

        [Route("Households/User/{userId}")]
        [HttpGet]
        public ActionResult HouseholdCollection([Bind(Include="userId")] int userId)
        {
            ICollection<HouseholdDto> households;

            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.ToString());
            }
            else
            {
                using (var householdLogic = new HouseholdLogic())
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