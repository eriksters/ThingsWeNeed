using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ThingsWeNeed.Data.Core;
using ThingsWeNeed.Data.Household;
using ThingsWeNeed.Data.Thing;
using ThingsWeNeed.Data.User;
using ThingsWeNeed.Shared;

namespace ThingsWeNeed.Data.Thing
{
    public class ThingDaLogic : IDisposable
    {
        private UserEntity currentUser;
        private TwnContext context;

        public ThingDaLogic(TwnContext context, UserEntity currentUser)
        {
            this.context = context;
            this.currentUser = currentUser;
        }

        /// <summary>
        /// Get thing DTO by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Thing Data Transfer Object</returns>
        /// <exception cref="KeyNotFoundException">Datbase entry not found</exception>
        public ThingDto GetById(int id)
        {
            ThingEntity entity = context.Things.Find(id);

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

        public ICollection<ThingDto> GetCollection()
        {
            ICollection<ThingDto> collection = new List<ThingDto>();

            foreach (HouseholdEntity household in currentUser.Households)
            {
                foreach (var entity in household.Things)
                {
                    collection.Add(new ThingDto()
                    {
                        ThingId = entity.ThingId,
                        DefaultPrice = entity.DefaultPrice,
                        Name = entity.Name,
                        Needed = entity.Needed,
                        Show = entity.Show,
                        HouseholdId = entity.HouseholdId
                    });
                }
            }

            return collection;
        }

        public ThingDto Create(
            string name, 
            int householdId,
            bool show,
            bool needed,
            double defaultPrice)
        {

            ThingEntity entity = new ThingEntity();
            entity.Name = name;
            entity.HouseholdId = householdId;
            entity.Show = show;
            entity.Needed = needed;
            entity.DefaultPrice = defaultPrice;

            context.Things.Add(entity);
            context.SaveChanges();


            ThingDto dto = new ThingDto()
            {
                ThingId = entity.ThingId,
                Name = entity.Name,
                Needed = entity.Needed,
                Show = entity.Show,
                DefaultPrice = entity.DefaultPrice,
                HouseholdId = entity.HouseholdId
            };
            
            return dto;
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
            ThingEntity entity = context.Things.Find(id);
            if (entity != null)
            {
                context.Things.Remove(entity);

                ThingDto dto = new ThingDto()
                {
                    ThingId = entity.ThingId,
                    DefaultPrice = entity.DefaultPrice,
                    Name = entity.Name,
                    Needed = entity.Needed,
                    Show = entity.Show,
                    HouseholdId = entity.HouseholdId
                };

                context.SaveChanges();

                return dto;
            }
            else
            {
                throw (new KeyNotFoundException());
            }
        }

        public void Dispose() {
            context.Dispose();
        }

        //public void Injectcontext(TwnContext context) {
        //    context = context;
        //}
    }
}