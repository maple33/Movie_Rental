using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using Movie_Rentals.Models;
using Movie_Rentals.ViewModels;

namespace WebApplication1.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        public ActionResult Index() 
        {
            var movie = _context.Movies.ToList();
            return View(movie);
        }

        //GET: Movies/Details        
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(a=>a.Actors).SingleOrDefault(m => m.Id == id);
            
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }

        public ActionResult New()
        {
            return View();
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            //get last id and choose random number between 1 and last id. 
            var lastId = _context.Movies.OrderByDescending(m=>m.Id).First().Id;
            Random r = new Random();
            int id = r.Next(1, lastId);
            
            var movie = _context.Movies.Include(a => a.Actors).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }
        //Save changes or add new movie to the database
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.AddDate = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.Genre = movie.Genre;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                
            }
            _context.SaveChanges();

            return RedirectToAction("Details", "Movies", new { id = movie.Id });
        }
        
        // GET: Movies/Edit
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            return View("New", movie);
        }

        //GET: Movies/AddActors
        public ActionResult AddActors(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            var viewModel = new AddActorViewModel
            {
                Movie = movie,
                Actors =_context.Actors.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult SaveActors(List <Actor> Actors, Movie movie)
        {
            
            foreach (var actor in Actors)
            {
                if (actor.IsSeclected == true)
                {
                    _context.Set<MovieActors>().Add(new MovieActors
                        {
                            Movie_id = movie.Id,
                            Actor_id = actor.id
                        }
                        );
                    actor.IsSeclected = false;
                }
                
            }
            _context.SaveChanges();
            
            return RedirectToAction("Details", "Movies", new { id = movie.Id });
        }
        

    }

}