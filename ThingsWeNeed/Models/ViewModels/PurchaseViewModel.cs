using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TwnData;

namespace ThingsWeNeed.Models.ViewModels {
    public class PurchaseViewModel : ViewModel {
        public PurchaseViewModel(string title) : base(title) { }

        public int PurchaseId { get; set; }
        public System.DateTime MadeOn { get; set; }
        public double Paid { get; set; }
        public int MadeById { get; set; }
        public int ThingId { get; set; }
        public int HouseholdId { get; set; }


        public virtual AppUser MadeBy { get; set; }

        public virtual Household Household { get; set; }

        public virtual Thing Thing { get; set; }
    }
}