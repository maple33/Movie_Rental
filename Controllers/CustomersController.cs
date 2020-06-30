using Movie_Rentals.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using Movie_Rentals.ViewModels;

namespace WebApplication1.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            //ISSUE : every time I send a new customer details the model is invalid!
            
            //if (!ModelState.IsValid)
            //{
            //    var viewModel = new NewCustomerViewModel
            //    {
            //        Customer = customer,
            //        MembershipTypes = _context.MembershipTypes.ToList()
            //    };
            //    return View("New", viewModel);
            //}

            if (customer.ID == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.ID == customer.ID);

                customerInDb.Name = customer.Name;
                customerInDb.birthDate = customer.birthDate;
                customerInDb.MembershipType = customer.MembershipType;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();

            return RedirectToAction("Details", "Customers", new { id = customer.ID});
        }

        public ViewResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c=>c.MembershipType).SingleOrDefault(c => c.ID == id);

            if (customer == null)
                return HttpNotFound();
            var listOfMoviesJoin = _context.MovieCustomers.Where(c => c.CustomerId == id);
            var listOfMovies = new List<Movie>();

            foreach (var movieId in listOfMoviesJoin)
            {
                var movie = _context.Movies.Where(m => m.Id == movieId.MovieId).SingleOrDefault();
                listOfMovies.Add(movie);
            }

            var viewModel = new CustomerViewModel
            {
                Customer = customer,
                Movies = listOfMovies
            };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.ID == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("New", viewModel);
        }
                
    }
}