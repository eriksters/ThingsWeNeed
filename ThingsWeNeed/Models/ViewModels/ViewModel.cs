using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThingsWeNeed.Models.ViewModels {
    public abstract class ViewModel {
        public string Title { get; set; }

        protected ViewModel(string title)
        {
            this.Title = title;
        }

    }
}