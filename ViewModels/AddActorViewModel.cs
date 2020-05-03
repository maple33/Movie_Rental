using Movie_Rentals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace Movie_Rentals.ViewModels
{
    public class AddActorViewModel
    {
        public List <Actor> Actors { get; set; }
        public Movie Movie { get; set; }
    }
}