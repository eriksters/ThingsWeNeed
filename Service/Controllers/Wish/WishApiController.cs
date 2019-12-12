using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ThingsWeNeed.Data.Wish;
using ThingsWeNeed.Shared;

namespace ThingsWeNeed.Service.Controllers.Wish
{
    public class WishApiController : ApiController
    {
        private WishLogic logic;

        public WishApiController()
        {
            logic = new WishLogic();
        }


        [HttpGet]
        [Route("api/Wish/{id}")]
        public IHttpActionResult Get(int id)
        {
            if (ModelState.IsValid)
            {
                using (logic)
                {
                    WishDto dto = logic.GetById(id);
                    dto.User = new LinkDto($"api/Wishes/{id}/UserId", "user", "GET");
                    dto.Links.Add(new LinkDto($"api/Wishes/{id}", "self", "GET"));
                    dto.Links.Add(new LinkDto($"api/Wishes/{id}", "create-wish", "POST"));
                    dto.Links.Add(new LinkDto($"api/Wishes/{id}", "update-wish", "PUT"));
                    dto.Links.Add(new LinkDto($"api/Wishes/{id}", "delete-wish", "DELETE"));
                    return Ok(dto);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpGet]
        [Route("api/Wishes")]
        public IHttpActionResult GetCollection()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("api/Wishes")]
        public IHttpActionResult Create(int id)
        {
            if (ModelState.IsValid)
            {
                using (logic)
                {
                    WishDto dto = logic.Create(id);
                    return Ok(dto);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("api/Wishes/{id}")]
        public IHttpActionResult Update(int id)
        {
            if (ModelState.IsValid)
            {
                using (logic)
                {
                    WishDto dto = logic.Update(id);
                    return Ok(dto);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        [HttpDelete]
        [Route("api/Wishes/{id}")]
        public IHttpActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                using (logic)
                {
                    WishDto dto = logic.Delete(id);
                    return Ok(dto);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        public void InjectLogic(WishLogic logic)
        {
            this.logic = logic;
        }
    }
}
