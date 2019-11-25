using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThingsWeNeed.Binders
{
    public class ThingIncludeDto
    {
        public bool IncludeHousehold { get; set; }

        public bool IncludeHidden { get; set; }
    }
}