using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using ThingsWeNeed.Data.Thing;
using ThingsWeNeed.Shared;

namespace ThingsWeNeed.Service.Thing
{
    public class ThingsApiController : ApiController
    {

        [HttpGet]
        public IHttpActionResult Get(int id) {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IHttpActionResult GetCollection() {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody] ThingDto dto) {
            throw new NotImplementedException();
        }

        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody] ThingDto dto) {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id) {
            throw new NotImplementedException();
        }

    }
}