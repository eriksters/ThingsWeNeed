using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThingsWeNeed.Data.Core;
using ThingsWeNeed.Data.User;
using ThingsWeNeed.Shared;

namespace ThingsWeNeed.Data.Purchase
{


    public class PurchaseDaLogic : IRestResource<PurchaseDto>, IDisposable
    {
        private string userId;
        private TwnContext context;

        public PurchaseDaLogic(TwnContext context, string userId)
        {
            this.context = context;
            this.userId = userId;
        }

        public PurchaseDto GetById(int id) {

            var entity = context.Purchases.Find(id);

            if (entity != null)
            {
                var dto = ToDto(entity);

                return dto;
            }
            else
            {
                throw new KeyNotFoundException();
            }


        }

        public PurchaseDto[] GetCollection() {

            var entities = context.Purchases.ToArray();

            PurchaseDto[] dtos = entities.Select(x => ToDto(x)).ToArray();

            return dtos;
        }

        public void Create(PurchaseDto dto) {
            var entity = new PurchaseEntity()
            {
                ThingId = dto.ThingId,
                MadeById = dto.MadeById,
                Price = dto.Price,
                MadeOn = dto.MadeOn,
            };

            context.Purchases.Add(entity);
            context.SaveChanges();

            dto.PurchaseId = entity.PurchaseId;
        }

        public void Update(PurchaseDto dto) {

            var entity = context.Purchases.Find(dto.ThingId);

            if (entity != null)
            {
                entity.Price = dto.Price;
                context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException();
            }

        }

        public PurchaseDto Delete(int id) {
            var entity = context.Purchases.Find(id);

            if (entity != null)
            {
                context.Purchases.Remove(entity);
                context.SaveChanges();
                return(ToDto(entity));
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }


        public static PurchaseDto ToDto(PurchaseEntity entity) {
            var dto = new PurchaseDto()
            {
                Price = entity.Price,
                MadeById = entity.MadeById,
                ThingId = entity.ThingId,
                PurchaseId = entity.PurchaseId,
                MadeOn = entity.MadeOn,
            };

            return dto;
        }

        public void Dispose() {
            context.Dispose();
        }
    }
}
