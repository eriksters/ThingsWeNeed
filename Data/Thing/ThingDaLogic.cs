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

        public IEnumerable<ThingDto> GetCollection()
        {
            throw new NotImplementedException();
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


        public ThingDto Update(int id)
        {
            ThingEntity entity = DatabaseContext.Things.Find(id);

            if (entity != null)
            {
                DatabaseContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;

            ThingDto dto = new ThingDto()
            {
                ThingId = entity.ThingId,
                DefaultPrice = entity.DefaultPrice,
                Name = entity.Name,
                Needed = entity.Needed,
                Show = entity.Show,
                HouseholdId = entity.HouseholdId
            };

                DatabaseContext.SaveChanges();

            return dto;
                

        }
            else
            {
                throw new NotImplementedException();
    }
}

        public ThingDto Delete(int id)
        {
            ThingEntity entity = DatabaseContext.Things.Find(id);
            if (entity != null)
            {
                DatabaseContext.Things.Remove(entity);

                ThingDto dto = new ThingDto()
                {
                    ThingId = entity.ThingId,
                    DefaultPrice = entity.DefaultPrice,
                    Name = entity.Name,
                    Needed = entity.Needed,
                    Show = entity.Show,
                    HouseholdId = entity.HouseholdId
                };

                DatabaseContext.SaveChanges();

                return dto;
            }
            else
            {
                throw (new KeyNotFoundException());
            }
        }

        public void Dispose() {
            DatabaseContext.Dispose();
        }

        public void InjectDatabaseContext(TwnContext context) {
            DatabaseContext = context;
        }
    }
}