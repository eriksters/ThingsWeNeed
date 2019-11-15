using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThingsWeNeed.Models;

namespace ThingsWeNeed.DAL
{
    public class PurchaseRepository : IGenericRepository<Purchase>
    {
        private ModelContainer mc;

        public PurchaseRepository(ModelContainer mc)
        {
            this.mc = mc;
        }

        public void Delete(int id) => mc.Purchases.Remove(mc.Purchases.Find(id));

        public IEnumerable<Purchase> GetAll() => mc.Purchases.ToList();

        public Purchase GetById(int id) => mc.Purchases.Find(id);

        public void Insert(Purchase toInsert) => mc.Purchases.Add(toInsert);

        public void Update(Purchase changes) => mc.Entry(changes).State = System.Data.Entity.EntityState.Modified;

        public void Save() => mc.SaveChanges();

        public void Dispose()
        {
            mc.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
