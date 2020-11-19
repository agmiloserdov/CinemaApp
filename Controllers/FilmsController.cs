using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Cinema.Data;
using Cinema.Models;
using Cinema.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Cinema.Controllers
{
    public class Films : Controller
    {
        private CinemaContext _db;
        private UploadFileService _uploader;

        private readonly IHostEnvironment _environment; 

        public Films(
            CinemaContext db, 
            UploadFileService uploader, 
            IHostEnvironment environment
            )
        {
            _db = db;
            _uploader = uploader;
            _environment = environment;

        }
        
        public IActionResult Index()
        {
            List<Film> films = _db.Films.OrderBy(f => f.UpdatedAt).ToList();
            return View(films);
        }
    
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        public async Task<IActionResult> Add(FilmViewModel film)
        {
            if (!ModelState.IsValid) return View(film);
            string path = Path.Combine(_environment.ContentRootPath,"wwwroot/images/Posters/");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
                
            string posterPath = $"images/Posters/{film.Name}{film.File.FileName}";
            _uploader.Upload(path, film.File.FileName, film.File);
            Film post = new Film()
            {
                Description = film.Description,
                Poster = posterPath,
                UserId = "fixture"
            };
            var result = _db.Films.AddAsync(post);
            if (!result.IsCompleted) return View(film);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}