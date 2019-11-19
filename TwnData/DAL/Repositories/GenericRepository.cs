using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TwnData.Transactions;

namespace TwnData
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly TwnContext context;
        protected readonly DbSet<T> entities;
        protected readonly DbSet<DbTransaction> transactions;

        public GenericRepository(TwnContext mc, string tableName)
        {
            this.context = mc;
            entities = mc.Set<T>();
        }

        public void Delete(int id) {
            entities.Remove(entities.Find(id));
            transactions.Add(new DbTransaction { 
                Action = TransactionAction.Delete,
                AffectedId = id,
                TableName = entities.
            });

        }

        public IEnumerable<T> GetAll() => entities.ToList();

        public T GetById(int id) => entities.Find(id);

        public void Insert(T toInsert) => entities.Add(toInsert);

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