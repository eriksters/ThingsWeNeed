using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

using ThingsWeNeed.Data.Thing;
using ThingsWeNeed.Data.User;
using ThingsWeNeed.Data.Household;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ThingsWeNeed.Data.User
{
    [Table("AppUser", Schema = "TWN")]
    public partial class UserEntity : IdentityUser
    {
        public UserEntity()
        {
            this.Households = new HashSet<HouseholdEntity>();
        }

        public string FName { get; set; }

        public string LName { get; set; }

        [InverseProperty("Users")]
        public virtual ICollection<HouseholdEntity> Households { get; private set; }

    }
}
