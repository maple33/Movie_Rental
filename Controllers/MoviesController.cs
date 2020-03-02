using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using Movie_Rentals.Models;


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
        
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(a=>a.Actors).SingleOrDefault(m => m.Id == id);
            
            if (movie == null)
                return HttpNotFound();
            return View(movie);
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

        // GET: Movies/Edit
        public ActionResult Edit(int id)
        {

            var movieId = new Movie() { Id = id };
            return View(movieId);

        }

    }
}