﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Enter Last Name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please Enter Unique User Id")]
        [Display(Name = "User Id")]
        public int UserId { get; set; }
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        public GenderType Gender { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}

