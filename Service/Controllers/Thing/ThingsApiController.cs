using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using ThingsWeNeed.Data.Thing;
using ThingsWeNeed.Shared;

namespace ThingsWeNeed.Controllers.Thing
{

    public class ThingsApiController : ApiController
    {
        private ThingDaLogic logic;

        public ThingsApiController() {
            logic = new ThingDaLogic();
        }

        [HttpGet]
        [Route("api/Things/{id}")]
        public IHttpActionResult Get(int id) {
            if (ModelState.IsValid)
            {
                using (logic)
                {
                    ThingDto dto = logic.GetById(id);
                    dto.Household = new LinkDto($"api/Things/{id}/Household", "houshold", "GET");
                    dto.Links.Add(new LinkDto($"api/Things/{id}", "self", "GET"));
                    dto.Links.Add(new LinkDto($"api/Things/{id}", "create-thing", "POST"));
                    dto.Links.Add(new LinkDto($"api/Things/{id}", "update-thing", "PUT"));
                    dto.Links.Add(new LinkDto($"api/Things/{id}", "delete-thing", "DELETE"));
                    return Ok(dto);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        [Route("api/Things")]
        public IHttpActionResult GetCollection() {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("api/Things")]
        public IHttpActionResult Create([FromBody] ThingDto dto) {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("api/Things/{id}")]
        public IHttpActionResult Update(int id, [FromBody] ThingDto dto) {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("api/Things/{id}")]
        public IHttpActionResult Delete(int id) {
            if (ModelState.IsValid)
            {
                using (logic)
                {
                    ThingDto dto = logic.Delete(id);
                    return Ok(dto);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        public void InjectLogic(ThingDaLogic logic) {
            this.logic = logic;
        }

    }
}