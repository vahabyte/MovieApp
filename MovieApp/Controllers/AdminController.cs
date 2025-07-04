using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Entity;
using MovieApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Controllers
{
    public class AdminController : Controller
    {

        private readonly MovieContext _context;
        public AdminController(MovieContext context)
        {
            _context = context;
        }
        public IActionResult MovieUpdate(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var entity = _context.Movies.Select(m => new AdminEditMovieViewModel
            {
                MovieId = m.MovieId,
                Title = m.Title,
                Description = m.Description,
                ImageUrl = m.ImageUrl,
                GenreIds = m.Genres.Select(g => g.GenreId).ToArray()
            }).FirstOrDefault(m => m.MovieId == id);

            ViewBag.Genres = _context.Genres.ToList();

            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }
        [HttpPost]
        public async Task<IActionResult> MovieUpdate(AdminEditMovieViewModel model, int[] genreIds, IFormFile file)
        {
            if (ModelState.IsValid)
            {


                var entity = _context.Movies
                    .Include("Genres")
                    .FirstOrDefault(m => m.MovieId == model.MovieId);
                if (entity == null)
                {

                    return NotFound();

                }
                entity.Title = model.Title;
                entity.Description = model.Description;

                if (file != null)
                {
                    var extension = Path.GetExtension(file.FileName);
                    var fileName = string.Format($"{Guid.NewGuid()}{extension}");
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", fileName);
                    entity.ImageUrl = fileName;

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                }

                entity.Genres = genreIds.Select(id => _context.Genres.FirstOrDefault(i => i.GenreId == id)).ToList();

                _context.SaveChanges();

                return RedirectToAction("MovieList");

            }
            ViewBag.Genres = _context.Genres.ToList();
            return View(model);
        }
        public IActionResult Index()
        {
            return View();
        }
        [AcceptVerbs("GET","POST")]
        public IActionResult VerifyMovieTitle(string Title)
        {
            if(_context.Movies.Any(m=>m.Title == Title))
            {
                return Json($"Zaten {Title} adında bir film var!");
            }
            return Json(true);
        }
        public IActionResult MovieList()
        {
            return View(new AdminMoviesViewModel
            {

                Movies = _context.Movies
                .Include(m => m.Genres)
                .Select(g => new AdminMovieViewModel
                {
                    MovieId = g.MovieId,
                    Title = g.Title,
                    ImageUrl = g.ImageUrl,
                    Genres = g.Genres.ToList()
                })
                .ToList()

            });
        }

        private AdminGenresViewModel GetGenres()
        {
            return new AdminGenresViewModel
            {
                Genres = _context.Genres.Select(g => new AdminGenreViewModel
                {
                    GenreId = g.GenreId,
                    Name = g.Name,
                    Count = g.Movies.Count
                }).ToList()
            };
        }

        public IActionResult GenreList()
        {
            return View(GetGenres());
        }
        [HttpPost]
        public IActionResult GenreCreate(AdminGenresViewModel model)
        {
            if (model.Name != null && model.Name.Length < 3)
            {
                ModelState.AddModelError("Name", "Tür adı en az 3 karakterli olmalıdır!");
            }
            if (ModelState.IsValid)
            {
                _context.Genres.Add(new Genre { Name = model.Name, });
                _context.SaveChanges();

                return RedirectToAction("GenreList");
            }
            return View("GenreList", GetGenres());
        }

        public IActionResult GenreUpdate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = _context.Genres
                .Select(g => new AdminGenreEditViewModel
                {
                    GenreId = g.GenreId,
                    Name = g.Name,
                    Movies = g.Movies.Select(m => new AdminMovieViewModel
                    {
                        MovieId = m.MovieId,
                        Title = m.Title,
                        ImageUrl = m.ImageUrl,

                    }).ToList()
                })
                .FirstOrDefault(g => g.GenreId == id);

            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }
        [HttpPost]
        public IActionResult GenreUpdate(AdminGenreEditViewModel model, int[] movieIds)
        {
            if (ModelState.IsValid)
            {
                var entity = _context.Genres.Include("Movies").FirstOrDefault(g => g.GenreId == model.GenreId);
                if (entity == null)
                {
                    return NotFound();
                }
                entity.Name = model.Name;

                foreach (var id in movieIds)
                {
                    entity.Movies.Remove(entity.Movies.FirstOrDefault(m => m.MovieId == id));
                }

                _context.SaveChanges();

                return RedirectToAction("GenreList");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult GenreDelete(int? genreId)
        {
            if (genreId == null)
            {
                return NoContent();
            }

            var entity = _context.Genres.Find(genreId);

            if (entity != null)
            {
                _context.Genres.Remove(entity);
                _context.SaveChanges();
            }
            return RedirectToAction("GenreList");


        }

        [HttpPost]
        public IActionResult MovieDelete(int? movieId)
        {
            if (movieId == null)
            {
                return NoContent();
            }

            var entity = _context.Movies.Find(movieId);

            if (entity != null)
            {
                _context.Movies.Remove(entity);
                _context.SaveChanges();
            }
            return RedirectToAction("MovieList");


        }

        public IActionResult MovieCreate()
        {
            ViewBag.Genres = _context.Genres.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MovieCreate(AdminCreateMovieViewModel model, int[] genreIds, IFormFile file)
        {
            if (model.Title != null && model.Title.Contains("@"))
            {
                ModelState.AddModelError("", "Film başlığı @ işareti içeremez!");
            }

            if (genreIds.Length == 0)
            {
                ModelState.AddModelError("GenreIds", "En az 1 film türü seçmelisiniz!");
            }

            if (ModelState.IsValid)
            {
                string imageFileName = "no-image.jpg";

                // Eğer kullanıcı dosya yüklediyse:
                if (file != null && file.Length > 0)
                {
                    var extension = Path.GetExtension(file.FileName).ToLower();
                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };

                    if (!allowedExtensions.Contains(extension))
                    {
                        ModelState.AddModelError("file", "Sadece .jpg, .jpeg, .png, .gif uzantılı dosyalar yüklenebilir.");
                        ViewBag.Genres = _context.Genres.ToList();
                        return View(model);
                    }

                    var imgFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img");
                    if (!Directory.Exists(imgFolder))
                        Directory.CreateDirectory(imgFolder);

                    imageFileName = $"{Guid.NewGuid()}{extension}";
                    var filePath = Path.Combine(imgFolder, imageFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }

                var entity = new Movie
                {
                    Title = model.Title,
                    Description = model.Description,
                    ImageUrl = imageFileName
                };

                foreach (var id in genreIds)
                {
                    var genre = _context.Genres.FirstOrDefault(g => g.GenreId == id);
                    if (genre != null)
                    {
                        entity.Genres.Add(genre);
                    }
                }

                _context.Movies.Add(entity);
                _context.SaveChanges();

                return RedirectToAction("MovieList", "Admin");
            }

            ViewBag.Genres = _context.Genres.ToList();
            return View(model);
        }

    }
}
