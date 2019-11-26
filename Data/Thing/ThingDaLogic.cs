using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ThingsWeNeed.Data.Core;
using ThingsWeNeed.Data.Thing;
using ThingsWeNeed.Shared;

namespace ThingsWeNeed.Data.Thing
{
    public class ThingDaLogic
    {
        protected TwnContext DatabaseContext { get; private set; }

        public ThingDaLogic (TwnContext context) {
            DatabaseContext = context;
        }

        public ThingDaLogic() {
            DatabaseContext = new TwnContext();    
        }

        public ThingDto GetById(int id) {
            throw new NotImplementedException();
        }

        public ThingDto Create(
            int id,
            int householdId,
            string name, 
            bool show,
            bool needed,
            double defaultPrice)
        {
            throw new NotImplementedException();
        }

    }
}