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

            foreach (ThingEntity entity in context.Things)
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


        public ThingDto Update(ThingEntity entity)
        {
            ThingEntity thingEntity = context.Things.Find(entity.ThingId);
            thingEntity.Name = entity.Name;
            thingEntity.Needed = entity.Needed;
            thingEntity.Show = entity.Show;
            thingEntity.HouseholdId = entity.HouseholdId;
            thingEntity.ThingId = entity.ThingId;

            context.SaveChanges();

            ThingDto thingDto = buildDto(thingEntity);
            return thingDto;
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

        public void Dispose()
        {
            context.Dispose();
        }

        //public void Injectcontext(TwnContext context) {
        //    context = context;
        //}

        public ThingDto buildDto(ThingEntity entity)
        {
            if (entity != null)
            {
                ThingDto dto = new ThingDto()
                {
                    ThingId = entity.ThingId,
                    HouseholdId = entity.HouseholdId,
                    DefaultPrice = entity.DefaultPrice,
                    Name = entity.Name,
                    Needed = entity.Needed,
                    Show = entity.Show,
                };
                return dto;
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }
    }
}