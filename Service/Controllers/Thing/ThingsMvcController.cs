using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ThingsWeNeed.Data.Thing;
using ThingsWeNeed.Shared;

namespace ThingsWeNeed.Service.Controllers.Thing
{
    public class ThingsMvcController : Controller
    {
        [Route]
        [Route("Things")]
        [Route("Things/All")]
        [HttpGet]
        public ActionResult All()
        {
            return Content("This page is not yet implemented");
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
                using (var db = new ThingDaLogic(null, null))
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
                using (var db = new ThingDaLogic(null, null))
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