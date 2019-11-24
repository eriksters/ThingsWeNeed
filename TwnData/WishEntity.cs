using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwnData
{

    [Table("Wish", Schema = "TWN")]
    public partial class WishEntity
    {
        public WishEntity()
        {
            this.ExtraPay = 0;
            this.Status = WishStatus.Pending;
        }

        [Key]
        public int WIshId { get; set; }

        [Required(ErrorMessage = "Maximum price required")]
        public double MaxPrice { get; set; }

        public double ExtraPay { get; set; }

        [Required]
        public DateTime MadeOn { get; set; }

        public DateTime? BoughtOn { get; set; }

        public WishStatus Status { get; set; }

        [Required]
        public int MadeByUserId { get; set; }

        public Nullable<int> GrantedByUserId { get; set; }

        [Required(ErrorMessage = "Name required")]
        public string Name { get; set; }



        [ForeignKey("MadeByUserId")]
        public virtual UserEntity MadeBy { get; private set; }

        [ForeignKey("GrantedByUserId")]
        public virtual UserEntity GrantedBy { get; private set; }
    }
}
