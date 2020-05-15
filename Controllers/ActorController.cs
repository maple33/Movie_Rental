using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Movie_Rentals.Models;
using Movie_Rentals.ViewModels;
using WebApplication1.Models;

namespace Movie_Rentals.Controllers
{
    public class ActorController : Controller
    {
        private ApplicationDbContext _context;

        public ActorController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Actor
        public ActionResult Index()
        {
            var actor = _context.Actors.ToList();
            return View(actor);
        }

        public ActionResult Details(int id)
        {
            var actor = _context.Actors.SingleOrDefault(a => a.id == id);

            if (actor == null)
                return HttpNotFound();

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

            return View(viewModel);
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Actor actor)
        {
            if (actor.id == 0)
                _context.Actors.Add(actor);
            else 
            {
                var actorInDb = _context.Actors.Single(a => a.id == actor.id);

                actorInDb.Name = actor.Name;
                actorInDb.BirthDate = actor.BirthDate;
            }
            _context.SaveChanges();

            return RedirectToAction("Details", "Actor", new { id = actor.id });
        }

        public ActionResult Edit(int id)
        {
            var actor = _context.Actors.SingleOrDefault(a => a.id == id);
            if (actor == null)
                return HttpNotFound();

            return View("New", actor);
        }
    }
}