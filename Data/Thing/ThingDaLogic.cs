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
        protected TwnContext DatabaseContext { get; private set; }

        public ThingDaLogic()
        {
            DatabaseContext = new TwnContext();
        }

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
            int householdId,
            string name, 
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
    }
}