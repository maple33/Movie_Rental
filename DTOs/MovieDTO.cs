using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace Movie_Rentals.DTOs
{
    public class MovieDTO
    {
        public MovieDTO()
        {
            this.Customers = new HashSet<Customer>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        public DateTime AddDate { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}