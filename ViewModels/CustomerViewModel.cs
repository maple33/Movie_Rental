using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace Movie_Rentals.ViewModels
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }
        public List<Movie> Movies { get; set; }
    }
}