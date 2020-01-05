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
        public int ID { get; set; }

        [Required(ErrorMessage = "Please Enter Type")]
        [StringLength(20)]
        [DisplayName("Fee Type")]
        public string Type { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Please Enter Fee Amount")]
        [DisplayName("Price")]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public decimal FeeCost { get; set; }

        public ICollection<Member> Members { get; set; }
    }
}
