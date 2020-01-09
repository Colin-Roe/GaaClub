using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GaaClub.Models
{
    public class FeeType
    {
        [Required]
        [Key]
        public int FeeID { get; set; }

        [Required(ErrorMessage = "Please Enter Type")]
        [StringLength(20)]
        [DisplayName("FeeType")]
        [Display(Name = "FeeType", ResourceType = typeof(Resources.Models_FeeType))]
        public string Type { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Resources.Models_FeeType))]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please Enter Fee Amount")]
        [DisplayName("Price")]
        [Display(Name = "Price", ResourceType = typeof(Resources.Models_FeeType))]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public decimal FeeCost { get; set; }

        public virtual ICollection<Member> Members { get; set; }
    }
}
