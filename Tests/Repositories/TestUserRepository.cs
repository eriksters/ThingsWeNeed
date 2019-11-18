using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThingsWeNeed.DAL;
using ThingsWeNeed.Models;
using System.Data.Entity;

namespace Tests.Repositories
{

    class TestUserRepository : TestGenericRepository<AppUser>, IUserRepository
    {
        public TestUserRepository(ModelContainer mc) : base(mc) {

        } 

    }
}
