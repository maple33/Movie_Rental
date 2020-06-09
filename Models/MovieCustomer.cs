using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace Movie_Rentals.Models
{
    [Table("MovieCustomer")]
    public class MovieCustomer
    {
        [Key]
        [Column(Order = 2)]
        public int MovieId { get; set; }
        [Key]
        [Column(Order = 1)]
        public int CustomerId { get; set; }
        public Movie Movie { get; set; }
        public Customer Customer { get; set; }

    }
}