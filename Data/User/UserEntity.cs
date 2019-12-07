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

namespace ThingsWeNeed.Data.User
{
    [Table("AppUser", Schema = "TWN")]
    public partial class UserEntity
    {
        public UserEntity()
        {
            this.Households = new HashSet<HouseholdEntity>();
        }

        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Email required")]
        [EmailAddress(ErrorMessage = "Email must be in correct format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Username required")]
        public string Username { get; set; }

        public float PenisSize { get; set; }

        public string FName { get; set; }
        public string LName { get; set; }
        public string PhoneNumber { get; set; }



        [InverseProperty("Users")]
        public virtual ICollection<HouseholdEntity> Households { get; set; }

    }
}
