using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThingsWeNeed.Models.ViewModels {
    public class ThingsListViewModel
    {
        private ICollection<Thing> valThingsList;

        public ICollection<Thing> ThingsList
        {
            get => valThingsList;
            set => valThingsList = value;
        }

    }
}