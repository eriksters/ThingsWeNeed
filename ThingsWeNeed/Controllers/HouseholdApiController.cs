//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using TwnData;
//using ThingsWeNeed.Utility;

//namespace ThingsWeNeed.Controllers
//{
//    public class HouseholdApiController : ApiController
//    {
//        private TwnContext context;

//        public HouseholdApiController(TwnContext context)
//        {
//            this.context = context;
//        }

//        public HouseholdApiController()
//        {
//            context = new TwnContext();
//        }

//        /// <summary>
//        /// Returns information about a Household
//        /// </summary>
//        /// <param name="id"></param>
//        [HttpGet]
//        [Route("api/Households/{id}")]    
//        public IHttpActionResult GetDetails(int id)
//        {
//            HouseholdEntity household = context.Households.Find(id);

//            if (household == null)
//            {
//                return Content(HttpStatusCode.BadRequest, ErrorResponseFactory.BadRequest(ModelState));
//            }
//            else
//            {
//                return Ok(EntityDtoMapper.Map(household));
//            }
//        }

//        /// <summary>
//        /// Returns information on all households
//        /// </summary>
//        [HttpGet]
//        [Route("api/Households")] 
//        public IHttpActionResult GetAll()
//        {
//            return Ok(EntityDtoMapper.Map(context.Households));
//        }

//        /// <summary>
//        /// Creates a new Household
//        /// The household data must be specified in the request body
//        /// </summary>
//        /// <param name="household"></param>
//        /// <returns>Created household data including generated id</returns>
//        [HttpPost]
//        [Route("api/Households")]     
//        public IHttpActionResult Create([FromBody] HouseholdEntity household)
//        {
//            if (!ModelState.IsValid || household == null)
//            {
//                return Content(HttpStatusCode.BadRequest, ErrorResponseFactory.BadRequest(ModelState));
//            }
//            else
//            {
//                //  If address null when saving the data, an exception is thrown
//                if (household.Address == null)
//                    household.Address = new Address();

//                context.Households.Add(household);
//                context.SaveChanges();
//                return Ok(EntityDtoMapper.Map(household));
//            }
//        }

//        /// <summary>
//        /// Deletes a household
//        /// </summary>
//        /// <param name="id">Household id</param>
//        /// <returns>Deleted household data</returns>
//        [HttpDelete]
//        [Route("api/Households/{id}")]     
//        public IHttpActionResult Delete(int id)
//        {
//            HouseholdEntity household = context.Households.Find(id);

//            if (this == null)
//            {
//                return Content(HttpStatusCode.BadRequest, ErrorResponseFactory.BadRequest(ModelState));
//            }
//            else
//            {
//                context.Households.Remove(household);
//                context.SaveChanges();
//                return Ok(EntityDtoMapper.Map(household));
//            }
//        }

//        /// <summary>
//        /// Edits a Household's data
//        /// The updated household data must be specified in the request body
//        /// </summary>
//        /// <param name="id">Id of the household</param>
//        [HttpPut]
//        [Route("api/Households/{id}")]  
//        public IHttpActionResult Edit(int id, [FromBody] HouseholdEntity updatedHousehold)
//        {
//            if (!ModelState.IsValid)
//            {
//                return Content(HttpStatusCode.BadRequest, ErrorResponseFactory.BadRequest(ModelState));
//            }
//            else
//            {
//                HouseholdEntity household = context.Households.Find(id);

//                if (household == null)
//                {
//                    throw new HttpResponseException(HttpStatusCode.NotFound);
//                }
//                else
//                {
//                    household.Address = updatedHousehold.Address;
//                    household.Name = updatedHousehold.Name;

//                    context.SaveChanges();

//                    return Ok(EntityDtoMapper.Map(household));
//                }
//            }
//        }
//    }
//}
