using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ThingsWeNeed.Data.User;
using ThingsWeNeed.Data.Thing;
using ThingsWeNeed.Shared;

namespace ThingsWeNeed.Data.Household
{
    [Table("Households", Schema = "TWN")]
    public partial class HouseholdEntity
    {
        public HouseholdEntity()
        {
            this.Things = new HashSet<ThingEntity>();
            this.Users = new HashSet<UserEntity>();
        }

        [Key]
        public int HouseholdId { get; set; }

        [Required]
        public string Name { get; set; }

        public AddressDto Address { get; set; }

        [InverseProperty("Household")]
        public virtual ICollection<ThingEntity> Things { get; private set; }

        [InverseProperty("Households")]
        public virtual ICollection<UserEntity> Users { get; private set; }

    }
}