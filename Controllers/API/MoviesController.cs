using AutoMapper;
using Movie_Rentals.DTOs;
using Movie_Rentals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace Movie_Rentals.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<MovieDTO> GetMovies()
        {
            return _context.Movies.ToList().Select(Mapper.Map<Movie,MovieDTO>);
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDTO, Movie>(movieDTO);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDTO.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDTO);
        }

        [HttpPut]
        public void UpdateMovie(int id, MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(movieDTO, movieInDb);
            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }

        [HttpPost]
        public IHttpActionResult AddActors(MovieDTO movieDTO, List<ActorDTO> actorDTOs)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movie = _context.Movies.SingleOrDefault(m => m.Id == movieDTO.Id);

            //Check if sent actors exist (ISSUE: check is done by id, so theoretically user can throw random  as long as an id exist in a database)
            foreach (var actorInList in actorDTOs)
            {
                var result = _context.Actors.SingleOrDefault(a => a.id == actorInList.id);
                if (result == null)
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            foreach (var actorInList in actorDTOs)
            {
                _context.Set<MovieActors>().Add(new MovieActors
                {
                    MovieId = movie.Id,
                    ActorId = actorInList.id
                });
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
