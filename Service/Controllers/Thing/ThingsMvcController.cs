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
                using (var thingLogic = new ThingDaLogic())
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
                using (var db = new ThingDaLogic())
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
        public ActionResult Create() {
            throw new NotImplementedException();
        }

        [Route("Things/{id}/Edit")]
        [HttpGet]
        public ActionResult Update(int id) {
            throw new NotImplementedException();
        }

    }
}