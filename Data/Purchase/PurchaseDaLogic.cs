using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThingsWeNeed.Data.Core;
using ThingsWeNeed.Shared;

namespace ThingsWeNeed.Data.Purchase
{


    public class PurchaseDaLogic : IDisposable
    {
        public TwnContext DatabaseContext { get; private set; }

        public PurchaseDaLogic()
        {
            DatabaseContext = new TwnContext();
        }

        public PurchaseDto GetById(int id) {

            var entity = DatabaseContext.Purchases.Find(id);

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

            var entities = DatabaseContext.Purchases.ToArray();

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

            DatabaseContext.Purchases.Add(entity);
            DatabaseContext.SaveChanges();

            dto.PurchaseId = entity.PurchaseId;
        }

        public void Update(PurchaseDto dto) {

            var entity = DatabaseContext.Purchases.Find(dto.ThingId);

            if (entity != null)
            {
                entity.Price = dto.Price;
                DatabaseContext.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException();
            }

        }

        public PurchaseDto Delete(int id) {
            var entity = DatabaseContext.Purchases.Find(id);
            PurchaseDto dto;

            if (entity != null)
            {
                DatabaseContext.Purchases.Remove(entity);
                DatabaseContext.SaveChanges();
                dto = ToDto(entity);
            }
            else
            {
                throw new KeyNotFoundException();
            }

            return dto;
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
            DatabaseContext.Dispose();
        }
    }
}
