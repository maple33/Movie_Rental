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
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var listActorsJoin = _context.MovieActors.Where(m => m.MovieId == id).ToList();
            var listOfActors = new List<Actor>();

            foreach (var actorId in listActorsJoin)
            {
                var actor = _context.Actors.Where(a => a.id == actorId.ActorId).SingleOrDefault();
                listOfActors.Add(actor);
            }


            var viewModel = new AddActorViewModel
            {
                Movie = movie,
                Actors = listOfActors
            };


            return View(viewModel);
        }

        public ActionResult New()
        {
            return View();
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            //get last id and choose random number between 1 and last id. 
            var lastId = _context.Movies.OrderByDescending(m => m.Id).First().Id;
            Random r = new Random();
            int id = r.Next(1, lastId);

            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var listActorsJoin = _context.MovieActors.Where(m => m.MovieId == id).ToList();
            var listOfActors = new List<Actor>();

            foreach (var actorId in listActorsJoin)
            {
                var actor = _context.Actors.Where(a => a.id == actorId.ActorId).SingleOrDefault();
                listOfActors.Add(actor);
            }

            var viewModel = new AddActorViewModel
            {
                Movie = movie,
                Actors = listOfActors
            };


            return View(viewModel);
        }
        //Save changes or add new movie to the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
                return View("New", movie);

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

            return View("UploadPoster", movie);
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
                Actors = _context.Actors.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult SaveActors(List<Actor> Actors, Movie movie)
        {

            foreach (var actor in Actors)
            {
                if (actor.IsSeclected == true)
                {
                    _context.Set<MovieActors>().Add(new MovieActors
                    {
                        MovieId = movie.Id,
                        ActorId = actor.id
                    }
                        );
                    actor.IsSeclected = false;
                }

            }
            _context.SaveChanges();

            return RedirectToAction("Details", "Movies", new { id = movie.Id });
        }

        [HttpPost]
        public ActionResult UploadPoster(HttpPostedFileBase upload, int Id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if (movie == null)
                return HttpNotFound();

            string fileName = movie.Name + ".png";
            if (upload != null)
            {
                upload.SaveAs(Server.MapPath("~/Content/Images/" + fileName));
            }

            movie.posterPath = "/Content/Images/" + fileName;
            _context.SaveChanges();

            return RedirectToAction("Details", "Movies", new { id = movie.Id });
        }

        public ActionResult UploadMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            return View(movie);
        }

        [HttpPost]
        public ActionResult SaveVideo(IEnumerable<HttpPostedFileBase> uploads, int Id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if (movie == null)
                return HttpNotFound();

            string fileName = movie.Name;

            foreach (var file in uploads)
            {
                for (var i = 1; i <= uploads.Count(); i++)
                {
                    if (file != null)
                    {
                        file.SaveAs(Server.MapPath("~/Content/Videos/" + fileName + i));
                    }
                }
                
            }

            movie.videoPath = "/Content/Videos/" + fileName;
            _context.SaveChanges();

            return RedirectToAction("Details", "Movies", new { id = movie.Id });
        }

    }

}