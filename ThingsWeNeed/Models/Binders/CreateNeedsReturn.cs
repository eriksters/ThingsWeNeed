using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThingsWeNeed.Models;

namespace ThingsWeNeed.Models.Binders {
    public class CreateNeedsReturn
    {
        public List<ReturnThing> CreateThings { get; set; }

        public CreateNeedsReturn()
        {
            CreateThings = new List<ReturnThing>();
        }

        public class ReturnThing
        {
            public string ThingId { get; set; }
            public double ThingPrice { get; set; }
        }
    }
}