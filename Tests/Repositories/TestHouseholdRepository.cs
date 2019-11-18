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
    class TestHouseholdRepository : TestGenericRepository<Household>, IHouseholdRepository
    {

        public TestHouseholdRepository(ModelContainer mc) : base(mc) {

        }
    }
}
