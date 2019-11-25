using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Core;
using Microsoft.Ajax.Utilities;
using ThingsWeNeed.Binders;
using ThingsWeNeed.DTOs;
using TwnData;

namespace ThingsWeNeed.DAL
{
    public class ThingDaLogic : AbstractDaLogic
    {
        private static ThingDaLogic instance;

        public static ThingDaLogic Instance {
            get 
            {
                if (instance == null)
                {
                    instance = new ThingDaLogic(context: new TwnContext());
                }
                return instance;
            }
        }

        public ThingDaLogic(TwnContext context) : base(context) { } //3

        private ThingDaLogic() : base(new TwnContext()) { }  //5
        
        ///  <summary>Cast Thing entity to Thing DTO</summary>
        public Thing GetThingDto(ThingEntity thingEntity, bool includeHousehold)
        {
            Thing thingDto;
            
            if (thingEntity == null)
            {
                thingDto = null;
            }
            else
            {
                thingDto = new Thing()
                {
                    ThingId = thingEntity.ThingId,
                    Needed = thingEntity.Needed,
                    Show = thingEntity.Show,
                    Name = thingEntity.Name,
                    DefaultPrice = thingEntity.DefaultPrice,
                    HouseholdId = thingEntity.HouseholdId,

                    //  Include the household only if requested
                    Household = includeHousehold
                        //  If household requested, cast Household entity to Household DTO
                        ? new Household()
                        {
                            Name = thingEntity.Household.Name,
                            HouseholdId = thingEntity.Household.HouseholdId,
                            Address = thingEntity.Household.Address
                        }
                        //  If household not requested, set Household to null
                        : null
                };
            }
            return thingDto;
        }

        //public Func<ThingEntity, Thing> GetThingDtoStoredExpression(bool includeHousehold)
        //{
        //    var result = new Func<ThingEntity, Thing>(x => 
        //        new Thing()
        //        {
        //            DefaultPrice = x.DefaultPrice,
        //            Name = x.Name,
        //            Show = x.Show,
        //            Needed = x.Needed,
        //            ThingId = x.ThingId,
        //            HouseholdId = x.HouseholdId,

        //            Household = includeHousehold ? 
        //                new Household()
        //                {
        //                    Name = x.Household.Name,
        //                    HouseholdId = x.Household.HouseholdId,
        //                    Address = x.Household.Address
        //                }
        //                : null
        //        });

        //    return result;
        //}

        /// <summary>Get Thing DTO by Id</summary>
        /// <returns>Null if not found</returns>
        public Thing GetThingDto(int id, bool includeHousehold)
        {
            var thingDto = DatabaseContext.Things
                //  Don't include the household in the query if not necessary
                //.Include(x => includeHousehold ? x.Household : null)

                //  Find the thing
                .Where(x => x.ThingId == id)

                //  Cast Thing entity to Thing DTO
                .Select(thingEntity => new Thing() {
                        ThingId = thingEntity.ThingId, 
                        Needed = thingEntity.Needed,
                        Show = thingEntity.Show,
                        Name = thingEntity.Name,
                        DefaultPrice = thingEntity.DefaultPrice,
                        HouseholdId = thingEntity.HouseholdId,

                        //  Include the household only if requested
                        Household = includeHousehold
                            //  If household requested, cast Household entity to Household DTO
                            ? new Household()
                            {
                                Name = thingEntity.Household.Name,
                                HouseholdId = thingEntity.Household.HouseholdId,
                                Address = thingEntity.Household.Address
                            }
                            //  If household not requested, set Household to null
                            : null
                })

                .FirstOrDefault();

            //  Returns null if Thing not found
            return thingDto;
        }


        /// <summary>Get multiple Thing DTOs</summary>
        public IEnumerable<Thing> GetThingDtos(bool includeHousehold = false, bool includeHidden = false)
        {
            var thingDtos = DatabaseContext.Things

                //  Include Household in the query if requested
                //  .Include(x => includeHousehold ? x.Household : null)

                //  Include Hidden things in the query if requested
                .Where(x => includeHidden ? true : x.Show)

                // Cast Thing entity to Thing DTO
                .Select(thingEntity => new Thing()
                {
                    ThingId = thingEntity.ThingId,
                    Needed = thingEntity.Needed,
                    Show = thingEntity.Show,
                    Name = thingEntity.Name,
                    DefaultPrice = thingEntity.DefaultPrice,
                    HouseholdId = thingEntity.HouseholdId,

                    //  Include the household only if requested
                    Household = includeHousehold
                        //  If household requested, cast Household entity to Household DTO
                        ? new Household()
                        {
                            Name = thingEntity.Household.Name,
                            HouseholdId = thingEntity.Household.HouseholdId,
                            Address = thingEntity.Household.Address
                        }
                        //  If household not requested, set Household to null
                        : null
                });


            //  return the DTOs as a list
            List<Thing> result = thingDtos.ToList();
            return result;
        }


        /// <summary>Create new thing</summary>
        /// <returns>Thing DTO with generated Id</returns>
        public Thing Create(Thing thingDto)
        {
            var thingEntity = new ThingEntity()
            {
                ThingId = thingDto.ThingId,
                HouseholdId = thingDto.HouseholdId,
                Name = thingDto.Name,
                Show = (bool) thingDto.Show,
                Needed = (bool) thingDto.Needed,
                DefaultPrice = (double) thingDto.DefaultPrice
            };

            //  Return thing DTO with Generated Id
            return GetThingDto(thingEntity, includeHousehold: false);
        }



        ///  <summary>Update Thing with Thing DTO object's data</summary>
        ///  <returns>Null if Thing not found</returns>
        public Thing Update(int id, Thing updatedThing)
        {
            //  Find the thing
            var thingEntity = DatabaseContext.Things
                .Find(id);

            //  If the thing is found, update the data
            if (thingEntity != null)
            {
                thingEntity.Name = updatedThing.Name;
                thingEntity.HouseholdId = updatedThing.HouseholdId;

                //  Update Needed if requested by business layer
                if (updatedThing.Needed != null)
                    thingEntity.Needed = (bool) updatedThing.Needed;

                //  Update Show if requested by business layer
                if (updatedThing.Show != null)
                    thingEntity.Show = (bool) updatedThing.Show;

                //  Update DefaultPrice if requested by business layer
                if (updatedThing.DefaultPrice != null)
                    thingEntity.DefaultPrice = (double) updatedThing.DefaultPrice;

                //  Save the changes
                DatabaseContext.SaveChanges();
            }

            //  Return updated Thing DTO, Null if not found
            return GetThingDto(thingEntity, includeHousehold: false);
        }
    }
}