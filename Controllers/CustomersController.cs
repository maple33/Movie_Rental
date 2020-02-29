using Movie_Rentals.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

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
        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            //var customer = _context.Customers.SingleOrDefault(c => c.ID == id);
            var customer = _context.Customers.Include(c => c.MembershipType).Include(m => m.Movies).SingleOrDefault(c => c.ID == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
                
    }
}