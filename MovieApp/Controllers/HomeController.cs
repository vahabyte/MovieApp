using Microsoft.AspNetCore.Mvc;
using MovieApp.Data;
using MovieApp.Model;
using MovieApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace MovieApp.Controllers
{
    public class HomeController : Controller
    {
        public readonly MovieContext _context;
        public HomeController(MovieContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var model = new HomePageViewModel()
            {
                PopularMovies = _context.Movies.ToList()
            };

            return View(model);
        }


        public IActionResult About()
        {
            return View();
        }


    }

}
