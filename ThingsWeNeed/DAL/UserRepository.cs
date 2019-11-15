using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThingsWeNeed.Models;

namespace ThingsWeNeed.DAL
{
    public class UserRepository : IGenericRepository<AppUser>
    {
        private ModelContainer mc;

        public UserRepository(ModelContainer mc)
        {
            this.mc = mc;
        }

        public void Delete(int id) => mc.AppUsers.Remove(mc.AppUsers.Find(id));

        public IEnumerable<AppUser> GetAll() => mc.AppUsers.ToList();

        public AppUser GetById(int id) => mc.AppUsers.Find(id);

        public void Insert(AppUser toInsert) => mc.AppUsers.Add(toInsert);

        public void Update(AppUser changes) => mc.Entry(changes).State = System.Data.Entity.EntityState.Modified;

        public void Save() => mc.SaveChanges();

        public void Dispose()
        {
            mc.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}