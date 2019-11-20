using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TwnData;

namespace ThingsWeNeed.Models.ViewModels {
    public class HouseholdViewModel : ViewModel {
        public HouseholdViewModel(string title) : base(title)
        {
        }
        public int HouseholdId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }


        public ICollection<Thing> Things { get; set; }

        public ICollection<AppUser> AppUsers { get; set; }

        public ICollection<Purchase> Purchases { get; set; }

    }
}