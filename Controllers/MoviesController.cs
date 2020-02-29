using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;
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
            var movie = new Movie() { Name = "Rock" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1"},
                new Customer { Name = "Customer 2"},
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };


            return View(viewModel);

        }

        // GET: Movies/Edit
        public ActionResult Edit(int id)
        {

            var movieId = new Movie() { Id = id };
            return View(movieId);

        }

    }
}