using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThingsWeNeed.Models {
    public class NeedsViewModel
    {
        public ICollection<Thing> Thing { get; set; }
        public Purchase ThingLastPurchase {
            get
            {
                return new Purchase();
            }
        }
    }
}