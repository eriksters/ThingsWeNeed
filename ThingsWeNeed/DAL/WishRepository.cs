using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThingsWeNeed.Models;

namespace ThingsWeNeed.DAL
{
    public class WishRepository
    {
        private ModelContainer mc;

        public WishRepository(ModelContainer mc)
        {
            this.mc = mc;
        }

        public void Delete(int id) => mc.Wishes.Remove(mc.Wishes.Find(id));

        public IEnumerable<Wish> GetAll() => mc.Wishes.ToList();

        public Wish GetById(int id) => mc.Wishes.Find(id);

        public void Insert(Wish toInsert) => mc.Wishes.Add(toInsert);

        public void Update(Wish changes) => mc.Entry(changes).State = System.Data.Entity.EntityState.Modified;

        public void Save() => mc.SaveChanges();

        public void Dispose()
        {
            mc.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}