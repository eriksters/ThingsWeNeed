using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using ThingsWeNeed.Data.Core;
using ThingsWeNeed.Data.Household;
using ThingsWeNeed.Shared;
using Microsoft.Owin;
using System.Net.Http;
using Microsoft.AspNet.Identity;

namespace ThingsWeNeed.Service.Controllers.Household
{
    public class HouseholdApiController : ApiController
    {
        private HouseholdDaLogic householdLogic;
        private TwnContext context;

        public HouseholdApiController()
        {
            householdLogic = new HouseholdDaLogic(context, Request.GetOwinContext().Authentication.User.Identity.GetUserId());
        }

        [HttpGet]
        [Route("api/Households/{id}")]
        public IHttpActionResult Get(int id)
        {
            if (ModelState.IsValid)
            {
                using (householdLogic)
                {
                    HouseholdDto dto = householdLogic.GetById(id);
                    return Ok(dto);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        // move maybe to user Api Controller
        [Route("api/Households/User/{userId}")]
        // and change this to maybe api/User/{id}/Households
        public IHttpActionResult GetCollection(int userId)
        {
            if (ModelState.IsValid)
            {
                using (householdLogic)
                {
                    var householdDtoList = householdLogic.GetCollection(userId);
                    return Ok(householdDtoList);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("api/Households/Update/{id}")]
        public IHttpActionResult Update(int id, HouseholdEntity householdEntity)
        {
            if (ModelState.IsValid)
            {
                if (id == householdEntity.HouseholdId)
                {
                    using (householdLogic)
                    {
                        var householdDto = householdLogic.Update(householdEntity);
                        return Ok(householdDto);
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

        [HttpDelete]
        [Route("api/Households/{id}")]
        public IHttpActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                using (householdLogic)
                {
                    bool removed = householdLogic.Delete(id);
                    return Ok(removed);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [Route("api/Households/Create")]
        public IHttpActionResult Create(HouseholdEntity newHousehold)
        {
            if (ModelState.IsValid)
            {
                using (householdLogic)
                {
                    HouseholdDto householdDto = householdLogic.Create(newHousehold);
                    return Ok(householdDto);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        public void InjectLogic(HouseholdDaLogic householdLogic)
        {
            this.householdLogic = householdLogic;
        }
    }
}