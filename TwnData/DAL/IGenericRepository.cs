using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TwnData
{
    //  A generic implementation of the repository pattern
    public interface IGenericRepository<T>
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Insert(T toInsert);
        void Delete(int id);
        IEnumerable<T> Query(Expression<Func<T, bool>> filter);
        IEnumerable<T> QueryObjectGraph(Expression<Func<T, bool>> filter, string children);

    }
}
