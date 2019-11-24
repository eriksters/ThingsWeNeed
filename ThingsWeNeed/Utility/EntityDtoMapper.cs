using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TwnData;
using ThingsWeNeed.DTOs;

namespace ThingsWeNeed.Utility
{
    public static class EntityDtoMapper
    {

        ////////////////        Things      ///////////////////

        ////      Multiple thing DTOs to thing entities
        //public static IEnumerable<ThingEntity> Map(IEnumerable<Thing> DTOs)
        //{
        //    var thingEntities = from entity in DTOs
        //                        select new ThingEntity()
        //                        {
        //                            ThingId = entity.ThingId,
        //                            DefaultPrice = entity.DefaultPrice,
        //                            HouseholdId = entity.HouseholdId,
        //                            Name = entity.Name,
        //                            Needed = entity.Needed
        //                        };

        //    return thingEntities;
        //}

        ////      Single thing DTO to single entity
        //public static ThingEntity Map(Thing dto)
        //{
        //    var entity = new ThingEntity()
        //    {
        //        ThingId = dto.ThingId,
        //        DefaultPrice = dto.DefaultPrice,
        //        HouseholdId = dto.HouseholdId,
        //        Name = dto.Name,
        //        Needed = dto.Needed
        //    };

        //    return entity;
        //}

        //  Multiple thing Entities to DTOs
        public static IEnumerable<Thing> Map(IEnumerable<ThingEntity> entities)
        {
            var thingDTOs = from entity in entities
                                select new Thing()
                                {
                                    ThingId = entity.ThingId,
                                    DefaultPrice = entity.DefaultPrice,
                                    HouseholdId = entity.HouseholdId,
                                    Name = entity.Name,
                                    Needed = entity.Needed
                                };

            return thingDTOs;
        }

        //  Single thing Entity to DTO
        public static Thing Map(ThingEntity entity)
        {
            var dto = new Thing()
            {
                ThingId = entity.ThingId,
                DefaultPrice = entity.DefaultPrice,
                HouseholdId = entity.HouseholdId,
                Name = entity.Name,
                Needed = entity.Needed
            };
            return dto;
        }

        /////////////////////       Households      //////////////////

        ////      Multiple Household DTOs to entities
        //public static IEnumerable<HouseholdEntity> Map(IEnumerable<Household> DTOs)
        //{
        //    var householdEntities = from entity in DTOs
        //                        select new HouseholdEntity()
        //                        {
        //                            HouseholdId = entity.HouseholdId,
        //                            Name = entity.Name,
        //                            Address = entity.Address,
        //                        };

        //    return householdEntities;
        //}

        ////      Single Household DTO to single entity
        //public static HouseholdEntity Map(Household dto)
        //{
        //    var entity = new HouseholdEntity()
        //    {
        //        HouseholdId = dto.HouseholdId,
        //        Name = dto.Name,
        //        Address = dto.Address,
        //    };

        //    return entity;
        //}

        //  Multiple Household Entities to DTOs
        public static IEnumerable<Household> Map(IEnumerable<HouseholdEntity> entities)
        {
            var HouseholdDTOs = from entity in entities
                            select new Household()
                            {
                                HouseholdId = entity.HouseholdId,
                                Name = entity.Name,
                                Address = entity.Address
                                
                            };

            return HouseholdDTOs;
        }

        //  Single Household Entity to DTO
        public static Household Map(HouseholdEntity entity)
        {
            var dto = new Household()
            {
                HouseholdId = entity.HouseholdId,
                Name = entity.Name,
                Address = entity.Address
            };
            return dto;
        }
    }
}