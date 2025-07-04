using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Entity;
using MovieApp.Model;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp.Controllers
{
    public class MoviesController : Controller
    {
        public readonly MovieContext _context;
        public MoviesController(MovieContext context)
        {
            _context = context;   
        }
        public string Name { get; private set; }

        public IActionResult Index()
        {
            return View();
        }

        //localhost:xxxx/movies/list
        //localhost:xxxx/movies/list/id
        public IActionResult List(int? id,string q) 
        {


            var movies = _context.Movies.AsQueryable();

            //var movies = MovieRepository.Movies;
            
            if(id != null)
            {

                movies = movies.
                    Include(m=>m.Genres).
                    Where(m=>m.Genres.Any(g=>g.GenreId == id));

            }


            if (!string.IsNullOrEmpty(q))
            {
                movies = movies.Where(i =>
                i.Title.ToLower().Contains(q.ToLower()) || 
                i.Description.ToLower().Contains(q.ToLower()));
            }


            var model = new MoviesViewModel()
            {

                Movies = movies.ToList()

            };
      
            return View("Movie" , model);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_context.Movies.Find(id));
        }

    }
}
