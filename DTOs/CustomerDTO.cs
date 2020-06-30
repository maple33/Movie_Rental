using Movie_Rentals.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movie_Rentals.DTOs
{
    public class CustomerDTO
    {
        
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipTypeDTO MembershipType { get; set; }

        public byte MembershipTypeId { get; set; }

        public DateTime? birthDate { get; set; }
        
    }
}