using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThingsWeNeed.Models;
using ThingsWeNeed.DAL;
using System.Data.Entity;

namespace Tests.Repositories
{
    class TestPurchaseRepository : TestGenericRepository<Purchase>, IPurchaseRepository
    {
        public TestPurchaseRepository(ModelContainer mc) : base(mc) {

        }
    }
}
