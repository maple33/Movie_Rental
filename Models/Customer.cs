using Movie_Rentals.DTOs;
using Movie_Rentals.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Customer
    {
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }        
        public bool IsSubscribedToNewsletter { get; set; }
       
        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of birth")]
        [min18yrsIfMember]
        public DateTime? birthDate { get; set; }

    }
}
