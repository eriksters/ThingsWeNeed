using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwnData
{
    [Table("AppUser", Schema = "TWN")]
    public partial class UserEntity
    {
        public UserEntity()
        {
            this.Purchases = new HashSet<PurchaseEntity>();
            this.Households = new HashSet<HouseholdEntity>();
            this.MadeWishes = new HashSet<WishEntity>();
            this.GrantedWishes = new HashSet<WishEntity>();
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


        [InverseProperty("MadeBy")]
        public virtual ICollection<PurchaseEntity> Purchases { get; private set; }

        [InverseProperty("Users")]
        public virtual ICollection<HouseholdEntity> Households { get; private set; }

        [InverseProperty("MadeBy")]
        public virtual ICollection<WishEntity> MadeWishes { get; private set; }

        [InverseProperty("GrantedBy")]
        public virtual ICollection<WishEntity> GrantedWishes { get; private set; }
    }
}