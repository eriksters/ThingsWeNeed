using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThingsWeNeed.DTOs
{
    public class Thing
    {
        public Thing() {
            Needed = true;
            DefaultPrice = 0;
        }

        public int ThingId { get; set; }

        [Required (ErrorMessage = "Name required")]
        public string Name { get; set; }

        [Required (ErrorMessage = "Penis size is a must")]
        public string PenisSize { get; set; }

        [Required (ErrorMessage = "Household Id required")]
        public int HouseholdId { get; set; }

        public bool Needed { get; set; }

        public double DefaultPrice { get; set; }

    }
}
