using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            throw new NotImplementedException();
        }

        [Route("Things/{id}")]
        [HttpGet]
        public ActionResult Details(int id) {
            throw new NotImplementedException();
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