using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TwnData;

namespace ThingsWeNeed.Models.ViewModels
{
    public class ThingsListViewModel : ViewModel
    {
        public UserEntity User { get; set; }

        public ThingsListViewModel(string title) : base(title) { }

    }
}