using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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

        [Required(ErrorMessage = "Please Enter Unique User Id")]
        [Display(Name = "UserId", ResourceType = typeof(Resources.Models_Member))]
        public int UserId { get; set; }

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

        public int FeeID { get; set; }

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

