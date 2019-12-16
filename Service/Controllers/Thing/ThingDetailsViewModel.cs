﻿using System.Collections.Generic;
using ThingsWeNeed.Shared;

namespace ThingsWeNeed.Service.Controllers.Thing
{
    public class ThingDetailsViewModel
    {
        public ThingDto Thing { get; set; }
        public ICollection<ThingDto> Things { get; set; }
    }
}