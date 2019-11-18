using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ThingsWeNeed.DAL;
using ThingsWeNeed.Models;
using System.Data.Entity;

namespace Tests.Repositories
{
    class TestGenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ModelContainer context;
        protected readonly DbSet<T> entities;

        public TestGenericRepository(ModelContainer mc)
        {
            if (mc != null) {
                context = mc;
                entities = mc.Set<T>();
            } else {
                throw new ArgumentNullException("The given database context was null");
            }
        }

        public void Delete(int id)
        {
            entities.Remove(entities.Find(id));
        }

        public IEnumerable<T> GetAll()
        {
            return entities.ToList();
        }

        public T GetById(int id)
        {
            return entities.Find(id);
        }

        public void Insert(T toInsert)
        {
            entities.Add(toInsert);
        }

        public IEnumerable<T> Query(Expression<Func<T, bool>> filter)
        {
            return entities.Where(filter);
        }

        public IEnumerable<T> QueryObjectGraph(Expression<Func<T, bool>> filter, string children)
        {
            return entities.Include(children).Where(filter);
        }
    }
}
