using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using ThingsWeNeed.Data.Thing;

namespace ThingsWeNeed.Service.Thing
{
    public class ThingsApiController : ApiController
    {

        [HttpGet]
        public IHttpActionResult Get(int id) {

        }

        [HttpGet]
        public IHttpActionResult GetCollection() {

        }

        [HttpPost]
        public IHttpActionResult Create([FromBody] ThingDto dto) {

        }

        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody] ThingDto dto) {

        }

        [HttpDelete]
        public IHttpActionResult Delete(int id) {

        }

    }
}
