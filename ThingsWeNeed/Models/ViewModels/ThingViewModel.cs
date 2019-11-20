using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TwnData;

namespace ThingsWeNeed.Models.ViewModels {
    public class ThingViewModel : ViewModel {
        public ThingViewModel(string title) : base(title)
        {
            Purchases = new List<Purchase>();
        }

        public int ThingId { get; set; }

        public string Name { get; set; }

        public bool Needed { get; set; }

        public double DefaultPrice { get; set; }

        public ICollection<Purchase> Purchases { get; set; }

        public Household Household { get; set; }

    }
}