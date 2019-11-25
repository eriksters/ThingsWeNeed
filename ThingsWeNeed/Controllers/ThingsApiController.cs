using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TwnData;
using System.Data.Entity;
using ThingsWeNeed.Utility;
using ThingsWeNeed.DTOs;
using ThingsWeNeed.Binders;
using ThingsWeNeed.DAL;

namespace ThingsWeNeed.Controllers
{
    public class ThingsApiController : ApiController
    {
        private ThingDaLogic logic;

        //  Allow for simple Dependency injection for easier testing
        public ThingsApiController(TwnContext context)
        {
            logic = ThingDaLogic.Instance;
        }

        public ThingsApiController() // 1
        {
            logic = ThingDaLogic.Instance;
        }

        /// <summary>
        /// Returns information about a Thing
        /// </summary>
        /// <param name="id"></param>
        [HttpGet]
        [Route("api/Things/{id}")] //  URI: "[host:port]/api/Things/{id}" (GET)
        public IHttpActionResult
            GetDetails(int id,
                [FromBody] ThingIncludeDto binder) //  Allow specifying how much data to include in the response
        {
            //  If model state is invalid, return Bad Request and the Error Response
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, ErrorResponseFactory.BadRequest(ModelState));
            }
            else
            {
                using (logic)
                {

                    Thing thingDto;

                    if (binder != null)
                    {
                        thingDto = logic.GetThingDto(id, includeHousehold: binder.IncludeHousehold);
                    }
                    else
                    {
                        thingDto = logic.GetThingDto(id, includeHousehold: true);
                    }

                    return Ok(thingDto);
                }
            }
        }

        /// <summary>
        /// Returns information on all stored things
        /// </summary>
        [HttpGet]
        [Route("api/Things")] //  URI: "[host:port]/api/Things" (GET)
        public IHttpActionResult GetAll([FromBody] ThingIncludeDto binder)
        {


            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, ErrorResponseFactory.BadRequest(ModelState));
            }
            else
            {
                using (logic)
                {
                    IEnumerable<Thing> things;  //7
                    if (binder != null)
                    {
                        things = logic.GetThingDtos(includeHousehold: binder.IncludeHousehold, includeHidden: binder.IncludeHidden);
                    }
                    else
                    {
                        things = logic.GetThingDtos(includeHousehold: false, includeHidden: false);
                    }

                    return Ok(things);
                }
            }

        }

        ///// <summary>
        ///// Creates a new Thing
        ///// The Thing's data must be specified in the request body
        ///// </summary>
        ///// <param name="thing"></param>
        ///// <returns>Created thing data including generated id</returns>
        //[HttpPost]
        //[Route("api/Things")]     //  URI: "[host:port]/api/Things" (POST)
        //public IHttpActionResult Create([FromBody] Thing thing)
        //{
        //    //  Check if there were no binding errors, no Thing data provided
        //    if (!ModelState.IsValid || thing == null)
        //    {
        //        // If there were errors, return Bad Request
        //        return Content(HttpStatusCode.BadRequest, ErrorResponseFactory.BadRequest(ModelState));
        //    }
        //    else
        //    {
        //        //  If all is good and well, 
        //        //  add the thing to the context, save to database,
        //        //  return the created thing with Ok status code and the created thing's data including generated Id
        //        ThingEntity thingEntity = new ThingEntity()
        //        {
        //            Name = thing.Name,
        //            HouseholdId = thing.HouseholdId,

        //            Needed = thing.Needed == null ? true : (bool) thing.Needed,
        //            DefaultPrice = thing.DefaultPrice == null ? 0 : (double) thing.DefaultPrice,
        //            Show = thing.Show == null ? true : (bool) thing.Show

        //        };
        //        context.Things.Add(thingEntity);
        //        context.SaveChanges();
        //        return Ok(EntityDtoMapper.Map(new List<ThingEntity> { thingEntity }));
        //    }
        //}

        ///// <summary>
        ///// Deletes a thing
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns>Deleted thing data</returns>
        //[HttpDelete]
        //[Route("api/Things/{id}")]     //  URI: "[host:port]/api/Things/{id}" (DELETE)
        //public IHttpActionResult Delete(int id)
        //{
        //    //  Find the thing in the database using EF
        //    ThingEntity thing = context.Things.Find(id);

        //    //  If the thing was not found, return Bad Request
        //    if (thing == null) {
        //        return NotFound();
        //    } 
        //    else 
        //    {
        //        //  If all is good and well, 
        //        //  remove the thing from the ED context,
        //        //  save to database, 
        //        //  return Ok with the removed thing's data

        //        thing.Show = false;
        //        context.SaveChanges();
        //        return Ok(EntityDtoMapper.Map(new ThingEntity[] {thing}));
        //    }
        //}

        ///// <summary>
        ///// Edits a Thing's data
        ///// The Thing's data must be specified in the request body
        ///// </summary>
        ///// <param name="id">Id of the thing</param>
        //[HttpPut]
        //[Route("api/Things/{id}")]  //  URI: "[host:port]/api/Things/{id}" (PUT)
        //public IHttpActionResult Edit(int id, [FromBody] Thing updatedThing)
        //{
        //    //  Check if there were no binding errors
        //    if (!ModelState.IsValid) 
        //    {
        //        // If there were errors, return Bad Request
        //        return Content(HttpStatusCode.BadRequest, ErrorResponseFactory.BadRequest(ModelState));
        //    } 
        //    else 
        //    {
        //        //  Find the thing in the database using EF
        //        ThingEntity thingEntity = context.Things.Find(id);

        //        //  If the Thing was not found, return Bad Request 
        //        if (thingEntity == null)
        //        {
        //            throw new HttpResponseException(HttpStatusCode.NotFound);
        //        }
        //        else 
        //        {
        //            //  If all is Good, 
        //            //  update the entity, 
        //            //  save the changes to the Database,
        //            //  return with the updated thingEntity's data

        //            thingEntity.Name = updatedThing.Name;

        //            if (updatedThing.DefaultPrice != null)
        //                thingEntity.DefaultPrice = (double) updatedThing.DefaultPrice;



        //            context.SaveChanges();

        //            return Ok(EntityDtoMapper.Map(new List<ThingEntity> {thingEntity} ));
        //        }
        //    }
        //}
    
    }
}