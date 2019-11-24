using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThingsWeNeed.Models.ViewModels
{
    public class ViewModel
    {
        public string Title { get; set; }

        protected ViewModel(string title)
        {
            Title = title;
        }

    }
}