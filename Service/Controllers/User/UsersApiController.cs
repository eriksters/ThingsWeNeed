using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using ThingsWeNeed.Data.User;
using ThingsWeNeed.Shared;

namespace ThingsWeNeed.Controllers.User
{

    public class UsersApiController : ApiController
    {
        private UserDaLogic logic;

        public UsersApiController() {
            logic = new UserDaLogic();
        }

        [HttpGet]
        [Route("api/Users/{id}")]
        public IHttpActionResult Get(int id) {
            if (ModelState.IsValid)
            {
                using (logic)
                {
                    UserDto dto = logic.GetById(id);
                    //dto.Links.Add(new LinkDto($"api/Users/{id}", "self", "GET"));
                    //dto.Links.Add(new LinkDto($"api/Users/{id}", "create-user", "POST"));
                    //dto.Links.Add(new LinkDto($"api/Users/{id}", "update-user", "PUT"));
                    //dto.Links.Add(new LinkDto($"api/Users/{id}", "delete-user", "DELETE"));
                    return Ok(dto);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        [Route("api/Users")]
        public IHttpActionResult GetCollection() {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("api/Users")]
        public IHttpActionResult Create([FromBody] UserDto dto) {
               if (ModelState.IsValid)
            {
                using (logic)
                {
                    logic.Create(dto.FName, dto.LName, dto.PhoneNumber, dto.Username, dto.Email);
                }
                return Ok(dto);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("api/Users/{id}")]
        public IHttpActionResult Update(int id, [FromBody] UserDto dto) {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("api/Users/{id}")]
        public IHttpActionResult Delete(int id) {
            if (ModelState.IsValid)
            {
                using (logic)
                {
                    UserDto dto = logic.Delete(id);
                    return Ok(dto);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        public void InjectLogic(UserDaLogic logic) {
            this.logic = logic;
        }

    }
}