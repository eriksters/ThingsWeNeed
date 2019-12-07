using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ThingsWeNeed.Data.Core;
using ThingsWeNeed.Data.Thing;
using ThingsWeNeed.Shared;

namespace ThingsWeNeed.Data.Thing
{
    public class ThingDaLogic : IDisposable
    {
        public TwnContext DatabaseContext { get; private set; }

        public ThingDaLogic()
        {
            DatabaseContext = new TwnContext();
        }

        /// <summary>
        /// Get thing DTO by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Thing Data Transfer Object</returns>
        /// <exception cref="KeyNotFoundException">Datbase entry not found</exception>
        public ThingDto GetById(int id)
        {
            ThingEntity entity = DatabaseContext.Things.Find(id);

            if (entity != null)
            {
                ThingDto dto = new ThingDto()
                {
                    ThingId = entity.ThingId,
                    DefaultPrice = entity.DefaultPrice,
                    Name = entity.Name,
                    Needed = entity.Needed,
                    Show = entity.Show,
                    HouseholdId = entity.HouseholdId
                };
                return dto;
            }
            else
            {
                //  Use Key not found Exception for when a resource is not found
                throw new KeyNotFoundException();
            }
        }

        public ThingDto[] GetCollection()
        {
            List<ThingEntity> thingsList = DatabaseContext.Things.ToList();
            List<ThingDto> thingsDtoList = new List<ThingDto>();

            foreach(ThingEntity entity in thingsList)
            {
                if(entity != null)
                {
                    ThingDto dto = new ThingDto()
                    {
                        ThingId = entity.ThingId,
                        DefaultPrice = entity.DefaultPrice,
                        Name = entity.Name,
                        Needed = entity.Needed,
                        Show = entity.Show,
                        HouseholdId = entity.HouseholdId
                    };
                    thingsDtoList.Add(dto);
                }
            }
            return thingsDtoList.ToArray();
        }

        public ThingDto Create(
            string name, 
            int householdId,
            bool show,
            bool needed,
            double defaultPrice)
        {
            throw new NotImplementedException();
        }

        public void Update(
            int id,
            int householdId,
            string name,
            bool show,
            bool needed,
            double defaultPrice)
        {
            throw new NotImplementedException();
        }

        public ThingDto Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose() {
            DatabaseContext.Dispose();
        }

        public void InjectDatabaseContext(TwnContext context) {
            DatabaseContext = context;
        }
    }
}