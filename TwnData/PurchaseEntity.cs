using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;

namespace TwnData
{
    [Table("Purchase", Schema = "TWN")]
    public class PurchaseEntity
    {
        [Key]
        public int PurchaseId { get; set; }
        public System.DateTime MadeOn { get; set; }
        public double Paid { get; set; }
        public int MadeById { get; set; }
        public int ThingId { get; set; }
        public int HouseholdId { get; set; }


        [ForeignKey("MadeById")]
        public virtual UserEntity MadeBy { get; private set; }

        [ForeignKey("HouseholdId")]
        public virtual HouseholdEntity Household { get; private set; }

        [ForeignKey("ThingId")]
        public virtual ThingEntity Thing { get; private set; }
    }
}
