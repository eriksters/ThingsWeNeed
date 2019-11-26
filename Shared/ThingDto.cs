using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using ThingsWeNeed.Data.Household;
using ThingsWeNeed.Data.Thing;
using ThingsWeNeed.Data.User;

namespace ThingsWeNeed.Shared
{
    public class ThingDto
    {
        public ThingDto()
        {
            Needed = true;
            DefaultPrice = 0;
        }

        public int ThingId { get; set; }

        [Required(ErrorMessage = "Name required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Household Id required")]
        public int HouseholdId { get; set; }

        public bool? Needed { get; set; }

        public double? DefaultPrice { get; set; }

        public bool? Show { get; set; }
            

        public HouseholdDto Household { get; set; }

        
    }
}