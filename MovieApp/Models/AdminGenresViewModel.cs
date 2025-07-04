using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class AdminGenresViewModel
    {
        [Required(ErrorMessage ="Lütfen Tür Adı Giriniz!")]
        public string Name { get; set; }
        public List<AdminGenreViewModel> Genres { get; set; }

    }

    public class AdminGenreViewModel
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }

    }
    public class AdminGenreEditViewModel
    {
        public int GenreId { get; set; }
        [Required(ErrorMessage = "Lütfen Tür Adı Giriniz!")]
        public string Name { get; set; }
        public List<AdminMovieViewModel> Movies { get; set; }

    }
}
