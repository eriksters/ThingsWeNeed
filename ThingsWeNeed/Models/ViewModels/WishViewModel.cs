using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TwnData;

namespace ThingsWeNeed.Models.ViewModels {
    public class WishViewModel {
        public int WIshId { get; set; }

        public double MaxPrice { get; set; }

        public double ExtraPay { get; set; }

        public System.DateTime MadeOn { get; set; }

        public Nullable<DateTime> BoughtOn { get; set; }

        public Status Status { get; set; }



        public string Name { get; set; }



        public virtual AppUser MadeBy { get; private set; }

        public virtual AppUser GrantedBy { get; private set; }
    }
}