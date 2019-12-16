using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ThingsWeNeed.Data.Core;
using ThingsWeNeed.Data.Thing;
using ThingsWeNeed.Shared;

namespace ThingsWeNeed.Service.Controllers.Thing
{
    public class ThingsMvcController : Controller
    {
        private string userId;
        private TwnContext context;

        public ThingsMvcController()
        {
            userId = Request.GetOwinContext().Authentication.User.Identity.GetUserId();
            context = new TwnContext();
        }

        [Route("Things")]
        [HttpGet]
        public ActionResult All()
        {
            ICollection<ThingDto> things;

            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.ToString());
            }
            else
            {
                using (var thingLogic = new ThingDaLogic(context, userId))
                {
                    things = thingLogic.GetCollection();
                }

                ThingDetailsViewModel viewModel = new ThingDetailsViewModel()
                {
                    Things = things
                };

                return View("NeedsList", viewModel);
            }
        }

        [Route("Things/{id}")]
        [HttpGet]
        public ActionResult Details([Bind(Include = "id")] int id) {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.ToString());
            }
            else
            {
                ThingDto thing;
                using (var db = new ThingDaLogic(context, userId))
                {
                    thing = db.GetById(id);
                }

                ThingDetailsViewModel viewModel = new ThingDetailsViewModel() {
                    Thing = thing
                };

                return View("Details", viewModel);
            }
        }

        [Route("Things/Create")]
        [HttpGet]
        public ActionResult Create([Bind(Include = "dto")] ThingDto dto) {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.ToString());
            }
            else
            {
                ThingDto thing;
                using (var db = new ThingDaLogic(context, userId))
                {
                    //thing = db.Create(dto.Name, dto.HouseholdId, dto.Show, dto.Needed, dto.DefaultPrice);
                }

                ThingDetailsViewModel viewModel = new ThingDetailsViewModel()
                {
                    Thing = null
                };

                return View("Details", viewModel);
            }
        }

        [Route("Things/{id}/Edit")]
        [HttpGet]
        public ActionResult Update(int id) {
            throw new NotImplementedException();
        }

    }
}