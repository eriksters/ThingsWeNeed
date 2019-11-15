using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThingsWeNeed.Models;

namespace ThingsWeNeed.DAL
{
    //  A generic implementation of the repository pattern
    interface IGenericRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T toInsert);
        void Delete(int id);
        void Update(T changes);
    }
}
