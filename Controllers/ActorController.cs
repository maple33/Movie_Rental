using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Movie_Rentals.Models;

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
            var actor = _context.Actors.Include(m => m.Movies).SingleOrDefault(a => a.id == id);

            if (actor == null)
                return HttpNotFound();
            return View(actor);
        }
    }
}