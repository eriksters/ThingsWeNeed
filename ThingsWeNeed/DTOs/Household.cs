using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TwnData;

namespace ThingsWeNeed.DTOs
{
    public class Household
    {
        public Household()
        {

        }

        public int HouseholdId { get; set; }

        [Required(ErrorMessage = "A name is required. This can be anything.")]
        public string Name { get; set; }

        public Address Address { get; set; }

    }
}