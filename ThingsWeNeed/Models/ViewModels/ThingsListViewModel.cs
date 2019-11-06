using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThingsWeNeed.Models.ViewModels {
    public class ThingsListViewModel : ViewModel
    {
        public AppUser User { get; set; }
    
        public ThingsListViewModel(string title) : base(title) { }

    }
}