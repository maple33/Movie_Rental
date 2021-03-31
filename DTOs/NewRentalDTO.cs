using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace Movie_Rentals.DTOs
{
    public class NewRentalDTO
    {
        
        [Required]
        public int customerId { get; set; }
        [Required]
        public List<int> movieIds { get; set; }
        
    }
}