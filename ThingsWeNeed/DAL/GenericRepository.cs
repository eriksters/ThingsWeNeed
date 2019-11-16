using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
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

        public IEnumerable<T> Query(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> QueryObjectGraph(Expression<Func<T, bool>> filter, string children)
        {
            throw new NotImplementedException();
        }

    }
}