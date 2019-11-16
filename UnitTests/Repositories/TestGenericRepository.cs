using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ThingsWeNeed.DAL;

namespace UnitTests.Repositories
{
    class TestGenericRepository<T> : IGenericRepository<T>
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T toInsert)
        {
            throw new NotImplementedException();
        }

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
