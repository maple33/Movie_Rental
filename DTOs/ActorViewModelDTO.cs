using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movie_Rentals.DTOs
{
    public class ActorViewModelDTO
    {
        public ActorDTO ActorDTO { get; set; }
        public List<MovieDTO> movieDTOs { get; set; }
    }
}