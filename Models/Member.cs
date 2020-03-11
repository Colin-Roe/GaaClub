using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaaClub.Models
{
    public enum GenderType
    {
        Male = 0,
        Female = 1,
        None = 2
    }

    public class Member
    {
        public Member() {}

        [Required]
        public int ID { get; set; }

        // user ID from AspNetUser table.
        public string OwnerID { get; set; }

        [Required(ErrorMessage = "Please Enter First Name")]
        [Display(Name = "FirstName", ResourceType = typeof(Resources.Models_Member))]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter Last Name")]
        [Display(Name = "LastName", ResourceType = typeof(Resources.Models_Member))]
        public string LastName { get; set; }

        [Display(Name = "DateOfBirth", ResourceType = typeof(Resources.Models_Member))]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = false)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Gender", ResourceType = typeof(Resources.Models_Member))]
        public GenderType Gender { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Registered", ResourceType = typeof(Resources.Models_Member))]
        public byte Registered { get; set; }

        [Required(ErrorMessage = "An Address must be entered")]
        [StringLength(50)]
        public string Address1 { get; set; }

        [StringLength(50)]
        public string Address2 { get; set; }

        [StringLength(50)]
        public string Address3 { get; set; }

        [StringLength(50)]
        public string Address4 { get; set; }

        [Required(ErrorMessage = "A City address must be entered")]
        [StringLength(20)]
        public string City { get; set; }

        [Required(ErrorMessage = "An postal code must be entered")]
        [Display(Name = "Post Code")]
        public string PostCode { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [DefaultValue(false)]
        [Display(Name = "Is player?")]
        public bool IsPlayer { get; set; }

        [DefaultValue(false)]
        [Display(Name = "Is match official?")]
        public bool MatchOfficial { get; set; }

        public int? FeeID { get; set; }

        [DefaultValue(false)]
        [Display(Name = "Fee Paid")]
        public bool FeePaid { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        [ForeignKey("FeeID")]
        public virtual FeeType FeeType { get; set; }
    }
}

