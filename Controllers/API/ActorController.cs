using AutoMapper;
using Movie_Rentals.DTOs;
using Movie_Rentals.Models;
using Movie_Rentals.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

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

        public IHttpActionResult GetActor(int id)
        {
            var actor = _context.Actors.SingleOrDefault(a => a.id == id);

            if (actor == null)
                return NotFound();

            var listMoviesJoin = _context.MovieActors.Where(a => a.ActorId == id).ToList();
            var listOfMovies = new List<Movie>();

            foreach (var movieId in listMoviesJoin)
            {
                var movie = _context.Movies.Where(m => m.Id == movieId.MovieId).SingleOrDefault();
                listOfMovies.Add(movie);
            }

            var viewModel = new ActorViewModel
            {
                Actor = actor,
                Movies = listOfMovies
            };

            return Ok(Mapper.Map<ActorViewModel, ActorViewModelDTO>(viewModel));
        }

        [HttpPost]
        public IHttpActionResult CreateActor(ActorDTO actorDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var actor = Mapper.Map<ActorDTO, Actor>(actorDTO);
            _context.Actors.Add(actor);
            _context.SaveChanges();

            actorDTO.id = actor.id;

            return Created(new Uri(Request.RequestUri + "/" + actor.id), actorDTO);
        }

        [HttpPut]
        public void UpdateActor(int id, ActorDTO actorDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var actorInDb = _context.Actors.SingleOrDefault(a => a.id == id);
            if (actorInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(actorDTO, actorInDb);

            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteActor(int id)
        {
            var actorInDb = _context.Actors.SingleOrDefault(a => a.id == id);
            if(actorInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Actors.Remove(actorInDb);
            _context.SaveChanges();
        }
    }
}
