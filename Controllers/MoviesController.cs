using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class MoviesController : Controller
    {

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

        //GET:movies index & sort

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";
            return Content(String.Format("page index {0} , sort by {1}", pageIndex, sortBy));
        }

        //GET: movies by released datete
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }


        //GET: movies list
        public ActionResult MoviesList()
        {
            var moviesList = new List<Movie>
            {
                new Movie { Name = "Rock" },
                new Movie { Name = "Rambo"},
                new Movie { Name = "Windtalkers"}
            };
            var movieViewModel = new MovieList
            {
                Movies = moviesList
            };
            return View(movieViewModel);
        }
    }
}