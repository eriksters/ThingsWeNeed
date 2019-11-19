using System;
using System.Collections.Generic;
using System.Linq;

namespace TwnData
{
    public class ThingRepository : GenericRepository<Thing>, IThingRepository
    {

        public ThingRepository(TwnContext mc) : base(mc)
        {

        }
    }
}   