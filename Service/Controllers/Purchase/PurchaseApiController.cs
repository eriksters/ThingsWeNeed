using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using ThingsWeNeed.Data.Purchase;
using ThingsWeNeed.Data.Thing;
using ThingsWeNeed.Shared;

namespace ThingsWeNeed.Service.Controllers.Purchase
{
    public class PurchaseApiController : ApiController
    {
        private PurchaseDaLogic logic;

        public PurchaseApiController () {
            logic = new PurchaseDaLogic();
        }

        [HttpGet]
        [Route("api/Purchases/{id}")]
        public IHttpActionResult Get(int id) {

            IHttpActionResult result;

            if (ModelState.IsValid)
            {
                using (logic)
                {
                    var dto = logic.GetById(id);

                    createLinks(dto);

                    result = Ok(dto);
                }
            }
            else
            {
                result = BadRequest(ModelState);
            }

            return result;
        }

        [HttpGet]
        [Route("api/Purchases")]
        public IHttpActionResult GetCollection()
        {
            var dtos = logic.GetCollection();

            foreach (var dto in dtos) {
                createLinks(dto);
            }

            return Ok(dtos);
        }

        [HttpPost]
        [Route("api/Purchases")]
        public IHttpActionResult Create(PurchaseDto dto)
        {
            IHttpActionResult result;

            if (ModelState.IsValid && dto != null) {

                using (logic)
                {
                    dto.MadeOn = DateTime.Now;

                    logic.Create(dto);

                    using (var thingLogic = new ThingDaLogic())
                    {
                        var thingDto = thingLogic.GetById(dto.ThingId);
                        //thingLogic.Update(dto.ThingId, thingDto.HouseholdId, thingDto.Name, thingDto.Show, false, thingDto.DefaultPrice);
                    }

                    createLinks(dto);

                    result = Ok(dto);
                }
            }
            else
            {
                result = BadRequest(ModelState);
            }

            return result;
        }

        [HttpPut]
        [Route("api/Purchases")]
        public IHttpActionResult Update(PurchaseDto dto) {

            IHttpActionResult result;

            if (ModelState.IsValid)
            {
                logic.Update(dto);
                createLinks(dto);
                result = Ok(dto);
            }
            else
            {
                result = BadRequest(ModelState);
            }

            return result;
        }

        [HttpDelete]
        [Route("api/Purchases/{id}")]
        public IHttpActionResult Delete(int id) {
            IHttpActionResult result;
            if (ModelState.IsValid)
            {
                var dto = logic.Delete(id);
                result = Ok(dto);
            }
            else
            {
                result = BadRequest(ModelState);
            }
            return result;
        }


        private void createLinks(PurchaseDto dto) {

            dto.Thing = new LinkDto(rel: "thing", href: $"api/Things/{dto.ThingId}", method: "GET");
            dto.MadeBy = new LinkDto(rel: "user", href: $"api/Users/{dto.MadeById}", method: "GET");

        }

        public void InjectLogic(PurchaseDaLogic logic) {
            this.logic = logic;
        }
    }
}