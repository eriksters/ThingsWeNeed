using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using ThingsWeNeed.Data.Core;
using ThingsWeNeed.Data.Wish;
using ThingsWeNeed.Shared;

namespace ThingsWeNeed.Data.Wish
{
    public class WishLogic : IDisposable
    {
        public TwnContext DatabaseContext { get; private set; }

        public WishLogic()
        {
            DatabaseContext = new TwnContext();
        }
        public WishDto GetById(int id)
        {
            var entity = DatabaseContext.Wishes.Find(id);

            if (entity != null)
            {
                WishDto dto = new WishDto()
                {
                    WishId = entity.WishId,
                    //UserId = entity.UserId,
                    ExtraPay = entity.ExtraPay,
                    MaxPrice = entity.MaxPrice,
                    GrantedOn = entity.GrantedOn,
                    Name = entity.Name
                };
                return dto;
            }
            else
            {
                //  Use Key not found Exception for when a resource is not found
                throw new KeyNotFoundException();


            }
           
        }

        public WishDto[] GetCollection()
        {
            List<WishEntity> wishesList = DatabaseContext.Wishes.ToList();
            List<WishDto> wishDtoList = new List<WishDto>();

            foreach (WishEntity entity in wishesList)
            {
                if (entity != null)
                {
                    WishDto dto = new WishDto()
                    {
                        WishId = entity.WishId,
                        //UserId = entity.UserId,
                        ExtraPay = entity.ExtraPay,
                        MaxPrice = entity.MaxPrice,
                        GrantedOn = entity.GrantedOn,
                        Name = entity.Name
                    };
                    wishDtoList.Add(dto);
                }
            }
            return wishDtoList.ToArray();
        }
        public WishDto Update(int id)
        {
            WishEntity entity = DatabaseContext.Wishes.Find(id);

            if (entity != null)
            {
                DatabaseContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;

                WishDto dto = new WishDto()
                {
                    WishId = entity.WishId,
                    //UserId = entity.UserId,
                    ExtraPay = entity.ExtraPay,
                    MaxPrice = entity.MaxPrice,
                    GrantedOn = entity.GrantedOn,
                    Name = entity.Name
                };

                DatabaseContext.SaveChanges();

                return dto;


            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public WishDto Create(int id)
        {
            var entity = DatabaseContext.Wishes.Find(id);
            if (entity != null)
            {
                DatabaseContext.Wishes.Add(entity);

                WishDto dto = new WishDto()
                {
                    WishId = entity.WishId,
                    //UserId = entity.UserId,
                    ExtraPay = entity.ExtraPay,
                    MaxPrice = entity.MaxPrice,
                    GrantedOn = entity.GrantedOn,
                    Name = entity.Name
                };

                DatabaseContext.SaveChanges();

                return dto;
            }
            else
            {
                throw (new KeyNotFoundException());
            }
        }



        public WishDto Delete(int id)
        {
            var entity = DatabaseContext.Wishes.Find(id);
            if (entity != null)
            {
                DatabaseContext.Wishes.Remove(entity);

                WishDto dto = new WishDto()
                {
                    WishId = entity.WishId,
                    //UserId = entity.UserId,
                    ExtraPay = entity.ExtraPay,
                    MaxPrice = entity.MaxPrice,
                    GrantedOn = entity.GrantedOn,
                    Name = entity.Name
                };

                DatabaseContext.SaveChanges();

                return dto;
            }
            else
            {
                throw (new KeyNotFoundException());
            }
        }

        public IEnumerable<WishDto> GetCollection()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            DatabaseContext.Dispose();
        }
        public void InjectDatabaseContext(TwnContext context)
        {
            DatabaseContext = context;
        }
    }
}

