using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ThingsWeNeed.Models;

namespace ThingsWeNeed.DAL
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ModelContainer mc;
        private readonly DbSet<T> entities;

        public GenericRepository(ModelContainer mc)
        {
            this.mc = mc;
            entities = mc.Set<T>();
        }

        public void Delete(int id) => entities.Remove(entities.Find(id));

        public IEnumerable<T> GetAll() => entities.ToList();

        public T GetById(int id) => entities.Find(id);

        public void Insert(T toInsert) => entities.Add(toInsert);

        public void Update(T changes) => mc.Entry<T>(changes).State = EntityState.Modified;

    }
}