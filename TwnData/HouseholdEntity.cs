using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwnData
{
    [Table("Households", Schema = "TWN")]
    public partial class HouseholdEntity
    {
        public HouseholdEntity()
        {
            this.Things = new HashSet<ThingEntity>();
            this.Users = new HashSet<UserEntity>();
            this.Purchases = new HashSet<PurchaseEntity>();
        }

        [Key]
        public int HouseholdId { get; set; }

        [Required(ErrorMessage = "A name is required. This can be anything.")]
        public string Name { get; set; }

        public Address Address { get; set; }


        [InverseProperty("Household")]
        public virtual ICollection<ThingEntity> Things { get; private set; }

        [InverseProperty("Households")]
        public virtual ICollection<UserEntity> Users { get; private set; }

        [InverseProperty("Household")]
        public virtual ICollection<PurchaseEntity> Purchases { get; private set; }
    }


}
