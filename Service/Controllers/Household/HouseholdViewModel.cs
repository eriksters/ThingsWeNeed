using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThingsWeNeed.Shared;

namespace ThingsWeNeed.Service.Controllers.Household
{
    public class HouseholdViewModel
    {
        public ICollection<HouseholdDto> Households { get; set; }
        public HouseholdDto Household { get;  set; }

        public string Name { get; set; }
    }
}