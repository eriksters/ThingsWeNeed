using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwnData
{

    [Table("Thing", Schema = "TWN")]
    public class ThingEntity
    {
        public ThingEntity()
        {
            this.DefaultPrice = 0;
            this.Needed = false;
            this.Purchases = new HashSet<PurchaseEntity>();
        }

        [Key]
        public int ThingId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int HouseholdId { get; set; }

        [Required]
        public bool Show { get; set; }      // For referential integrity
                                            // When deleting, dont actually delete the thing, but make it not show in the List

        public bool Needed { get; set; }

        public double DefaultPrice { get; set; }


        [InverseProperty("Thing")]
        public virtual ICollection<PurchaseEntity> Purchases { get; set; }

        [ForeignKey("HouseholdId")]
        public virtual HouseholdEntity Household { get; set; }
    }
}