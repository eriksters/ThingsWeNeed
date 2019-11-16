using System;
using System.Collections.Generic;
using System.Linq;
using ThingsWeNeed.Models;

namespace ThingsWeNeed.DAL
{
    public class ThingRepository : GenericRepository<Thing>, IThingRepository
    {
        private ModelContainer mc;

        public ThingRepository(ModelContainer mc) : base(mc)
        {
            this.mc = mc;
        }
    }
}   