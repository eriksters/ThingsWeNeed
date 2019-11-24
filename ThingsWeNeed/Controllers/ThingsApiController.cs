using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TwnData;
using ThingsWeNeed.Utility;
using ThingsWeNeed.DTOs;

namespace ThingsWeNeed.Controllers
{
    public class ThingsApiController : ApiController
    {
        private TwnContext context;

        //  Allow for simple Dependency injection for easier testing
        public ThingsApiController(TwnContext context) {
            this.context = context;
        }

        public ThingsApiController() {
            context = new TwnContext();
        }

        /// <summary>
        /// Returns information about a Thing
        /// </summary>
        /// <param name="id"></param>
        [HttpGet]
        [Route("api/Things/{id}")]     //  URI: "[host:port]/api/Things/{id}" (GET)
        public IHttpActionResult GetDetails(int id)
        {
            //  Find the thing in the database using EF
            ThingEntity thing = context.Things.Find(id);

            //  If the Thing was not found, return Not found
            if (thing == null)
            {
                return NotFound();
            }
            else 
            {
                return Ok(EntityDtoMapper.Map(thing));
            }
        }

        /// <summary>
        /// Returns information on all stored things
        /// </summary>
        [HttpGet]
        [Route("api/Things")]     //  URI: "[host:port]/api/Things" (GET)
        public IHttpActionResult GetAll()
        {
            //  Currently no errors are being handled (at this layer)
            //  so just return all things derectly from the EF context
            //  return Ok(context.Things.Except);

            List<Thing> e = EntityDtoMapper.Map(context.Things).ToList();

            return Ok(EntityDtoMapper.Map(context.Things));
        }

        /// <summary>
        /// Creates a new Thing
        /// The Thing's data must be specified in the request body
        /// </summary>
        /// <param name="thing"></param>
        /// <returns>Created thing data including generated id</returns>
        [HttpPost]
        [Route("api/Things")]     //  URI: "[host:port]/api/Things" (POST)
        public IHttpActionResult Create([FromBody] Thing thing)
        {
            //  Check if there were no binding errors
            if (!ModelState.IsValid || thing == null)
            {
                // If there were errors, return Bad Request
                return Content(HttpStatusCode.BadRequest, ErrorResponseFactory.BadRequest(ModelState));
            }
            else
            {
                //  If all is good and well, 
                //  add the thing to the context, save to database,
                //  return the created thing with Ok status code and the created thing's data including generated Id
                ThingEntity thingEntity = new ThingEntity()
                {
                    DefaultPrice = thing.DefaultPrice,
                    Name = thing.Name,
                    Needed = thing.Needed,
                    HouseholdId = thing.HouseholdId
                };
                context.Things.Add(thingEntity);
                context.SaveChanges();
                return Ok(EntityDtoMapper.Map(thingEntity));
            }
        }

        /// <summary>
        /// Deletes a thing
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Deleted thing data</returns>
        [HttpDelete]
        [Route("api/Things/{id}")]     //  URI: "[host:port]/api/Things/{id}" (DELETE)
        public IHttpActionResult Delete(int id)
        {
            //  Find the thing in the database using EF
            ThingEntity thing = context.Things.Find(id);

            //  If the thing was not found, return Bad Request
            if (this == null) {
                return Content(HttpStatusCode.BadRequest, ErrorResponseFactory.BadRequest(ModelState));
            } 
            else 
            {
                //  If all is good and well, 
                //  remove the thing from the ED context,
                //  save to database, 
                //  return Ok with the removed thing's data
                
                context.Things.Remove(thing);
                context.SaveChanges();
                return Ok(EntityDtoMapper.Map(thing));
            }
        }

        /// <summary>
        /// Edits a Thing's data
        /// The Thing's data must be specified in the request body
        /// </summary>
        /// <param name="id">Id of the thing</param>
        [HttpPut]
        [Route("api/Things/{id}")]  //  URI: "[host:port]/api/Things/{id}" (PUT)
        public IHttpActionResult Edit(int id, [FromBody] Thing updatedThing)
        {
            //  Check if there were no binding errors
            if (!ModelState.IsValid) 
            {
                // If there were errors, return Bad Request
                return Content(HttpStatusCode.BadRequest, ErrorResponseFactory.BadRequest(ModelState));
            } 
            else 
            {
                //  Find the thing in the database using EF
                ThingEntity thing = context.Things.Find(id);

                //  If the Thing was not found, return Bad Request 
                if (thing == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                else 
                {
                    //  If all is Good, 
                    //  update the entity, 
                    //  save the changes to the Database,
                    //  return with the updated thing's data
                    
                    thing.DefaultPrice = updatedThing.DefaultPrice;
                    thing.Name = updatedThing.Name;
                    thing.Needed = updatedThing.Needed;

                    context.SaveChanges();
                    
                    return Ok(EntityDtoMapper.Map(thing));
                }
            }
        }
    }
}