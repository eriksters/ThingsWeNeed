using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThingsWeNeed.Models;

namespace ThingsWeNeed.DAL
{
    public class UserRepository : GenericRepository<AppUser>, IUserRepository
    {
        private ModelContainer mc;

        public UserRepository(ModelContainer mc) : base(mc)
        {
            this.mc = mc;
        }
    }
}