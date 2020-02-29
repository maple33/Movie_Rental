﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace Movie_Rentals.Models
{
    public class Actor
    {
        public Actor()
        {
            this.Movies = new HashSet<Movie>();
        }
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
        public DateTime BirthDate { get; set; }
        public int CalculateAge  (DateTime BirthDate)
        {
            var age = 0;
            age = DateTime.Now.Year - BirthDate.Year;
            if (DateTime.Now.DayOfYear < BirthDate.DayOfYear)
                age = age - 1;
            return age;
        }
    }

}