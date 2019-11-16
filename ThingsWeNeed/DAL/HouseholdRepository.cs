using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThingsWeNeed.Models;

namespace ThingsWeNeed.DAL
{
    public class HouseholdRepository : GenericRepository<Household>, IHouseholdRepository
    {
        private ModelContainer mc;

        public HouseholdRepository(ModelContainer mc) : base(mc)
        {
            this.mc = mc;
        }
    }
}