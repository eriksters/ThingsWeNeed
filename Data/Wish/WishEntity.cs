using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThingsWeNeed.Data.User;

namespace ThingsWeNeed.Data.Wish
{

    [Table("Wish", Schema = "TWN")]
    public class WishEntity
    {
        public  WishEntity()
        {

        }
        [Key]
    public int WishId { get; set; }
        [Required]
        public double MaxPrice { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public double ExtraPay { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime GrantedOn { get; set; }

        [ForeignKey("UserId")]
        public virtual UserEntity User { get; set; }

        /*
                [ForeignKey("MadeById")]
                public virtual UserEntity Made { get; set; }

            */
    }
}
