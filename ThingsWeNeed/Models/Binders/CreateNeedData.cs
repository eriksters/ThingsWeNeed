using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ThingsWeNeed.Models.Binders
{
    public class CreateNeedData
    {
        [Required(ErrorMessage = "Thing must be specified")]
        public int ThingId { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public double ThingPrice { get; set; }
    }
}