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
    public class ThingDaLogic : IRestResource<ThingDto>, IDisposable 
    {
        private string userId;
        private TwnContext context;

        public ThingDaLogic(TwnContext context, string userId)
        {
            this.context = context;
            this.userId = userId;
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

        public ThingDto[] GetCollection()
        {
            ICollection<ThingDto> collection = new List<ThingDto>();

            foreach (HouseholdEntity household in context.Users.Find(userId).Households)
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

            return collection.ToArray();
        }

        public void Create(ThingDto dto)
        {
            ThingEntity entity = new ThingEntity();
            entity.Name = dto.Name;
            entity.HouseholdId = dto.HouseholdId;
            entity.Show = dto.Show;
            entity.Needed = dto.Needed;
            entity.DefaultPrice = dto.DefaultPrice;

            context.Things.Add(entity);
            context.SaveChanges();

            dto.ThingId = entity.ThingId;
        }


        public void Update(ThingDto dto)
        {
            ThingEntity entity = context.Things.Find(dto.ThingId);

            if (entity != null)
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;

                entity.Show = dto.Show;
                entity.Needed = dto.Needed;
                entity.Name = dto.Name;
                entity.DefaultPrice = dto.DefaultPrice;
                
                context.SaveChanges();
            }
            
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

      //  public void Injectcontext(TwnContext context) {
      //   context = context;
      // }
    }
}