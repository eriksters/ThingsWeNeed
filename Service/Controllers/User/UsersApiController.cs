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
        [Route("api/Users/Update/{id}")]
        public IHttpActionResult Update(int id, UserEntity userEntity)
        {
            if (ModelState.IsValid)
            {
                if (id == userEntity.UserId)
                {
                    using (logic)
                    {
                        var userDto = logic.Update(userEntity);
                        return Ok(userDto);
                    }
                }
                else
                {
                    return BadRequest("Id's do not match");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        // move maybe to user Api Controller
        [Route("api/User/Households/{householdId}")]
        // and change this to maybe api/User/{id}/Households
        public IHttpActionResult GetCollection(int householdId)
        {
            if (ModelState.IsValid)
            {
                using (logic)
                {
                    var householdDtoList = logic.GetCollection(householdId);
                    return Ok(householdDtoList);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("api/Users/{id}")]
        public IHttpActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                using (logic)
                {
                    bool removed = logic.Delete(id);
                    return Ok(removed);
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