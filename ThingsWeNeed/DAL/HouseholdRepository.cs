using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThingsWeNeed.Models;

namespace ThingsWeNeed.DAL
{
    public class HouseholdRepository : IGenericRepository<Household>
    {
        private ModelContainer mc;

        public HouseholdRepository(ModelContainer mc)
        {
            this.mc = mc;
        }

        public void Delete(int id) => mc.Households.Remove(mc.Households.Find(id));

        public IEnumerable<Household> GetAll() => mc.Households.ToList();

        public Household GetById(int id) => mc.Households.Find(id);

        public void Insert(Household toInsert) => mc.Households.Add(toInsert);

        public void Update(Household changes) => mc.Entry(changes).State = System.Data.Entity.EntityState.Modified;

        public void Save() => mc.SaveChanges();

        public void Dispose()
        {
            mc.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}