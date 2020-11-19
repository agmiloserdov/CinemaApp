using System.Collections.Generic;
using System.Linq;
using Cinema.Data;
using Cinema.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers
{
    public class Films : Controller
    {
        private CinemaContext _db;

        public Films(CinemaContext db)
        {
            _db = db;
        }
        
        public IActionResult Index()
        {
            List<Film> films = _db.Films.OrderBy(f => f.UpdatedAt).ToList();
            return View(films);
        }
    }
}