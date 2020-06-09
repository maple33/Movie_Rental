using AutoMapper;
using Movie_Rentals.DTOs;
using Movie_Rentals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Movie_Rentals.Controllers.API
{
    public class ActorController : ApiController
    {
        private ApplicationDbContext _context;

        public ActorController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<ActorDTO> GetActors()
        {
            return _context.Actors.ToList().Select(Mapper.Map<Actor, ActorDTO>);
        }
        //public IHttpActionResult GetActor(int id)
        //{
        //    var actor = _context.Actors.SingleOrDefault(a => a.id == id);

        //    if (actor == null)
        //        return NotFound();

        //    return 
        //}
    }
}
