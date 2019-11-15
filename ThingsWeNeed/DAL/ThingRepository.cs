using System;
using System.Collections.Generic;
using System.Linq;
using ThingsWeNeed.Models;

namespace ThingsWeNeed.DAL
{
    public class ThingRepository : IGenericRepository<Thing>
    {
        private ModelContainer mc;

        public ThingRepository(ModelContainer mc)
        {
            this.mc = mc;
        }

        public void Delete(int id) => mc.Things.Remove(mc.Things.Find(id));

        public IEnumerable<Thing> GetAll() => mc.Things.ToList();

        public Thing GetById(int id) => mc.Things.Find(id);

        public void Insert(Thing toInsert) => mc.Things.Add(toInsert);

        public void Update(Thing changes) => mc.Entry(changes).State = System.Data.Entity.EntityState.Modified;

        public void Save() => mc.SaveChanges();

        public void Dispose()
        {
            mc.Dispose();
            GC.SuppressFinalize(this);
        }

        
    }
}   