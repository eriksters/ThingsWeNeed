using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThingsWeNeed.Data
{
    public interface IRestResource<T>
    {
        T GetById(int id);

        T[] GetCollection();

        void Create(T toCreate);

        void Update(T toUpdate);

        T Delete(int id);
    }
}
