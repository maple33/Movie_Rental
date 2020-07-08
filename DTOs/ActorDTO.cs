using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movie_Rentals.DTOs
{
    public class ActorDTO
    {

        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public bool IsSeclected { get; set; }
        public string imgPath { get; set; }
        public int CalculateAge(DateTime BirthDate)
        {
            var age = DateTime.Now.Year - BirthDate.Year;
            if (DateTime.Now.DayOfYear < BirthDate.DayOfYear)
                age = age - 1;
            return age;
        }
    }
}