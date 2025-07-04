using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using MovieApp.Data;
using MovieApp.Model;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp.ViewComponents
{
    public class GenresViewComponent : ViewComponent
    {

        public readonly MovieContext _context;
        public GenresViewComponent(MovieContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {

            ViewBag.SelectedGenre = RouteData.Values["id"];

            return View(_context.Genres.ToList());
            


        }

    }
}
