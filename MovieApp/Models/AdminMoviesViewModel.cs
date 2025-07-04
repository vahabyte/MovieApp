using Microsoft.AspNetCore.Mvc;
using MovieApp.Entity;
using MovieApp.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class AdminMoviesViewModel
    {
        public List<AdminMovieViewModel> Movies { get; set; }
    }
    public class AdminMovieViewModel
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public List<Genre> Genres { get; set; }
    }

    public class AdminCreateMovieViewModel
    {
        [Display(Name = "Film adı")]
        [Required(ErrorMessage ="Bir film adı girmelisiniz")]
        [StringLength(50,MinimumLength =3, ErrorMessage ="Film adı 3-50 karakter uzunluğunda olmalıdır!")]
        [Remote(action:"VerifyMovieTitle",controller:"Admin")]
        public string Title { get; set; }

        [Display(Name = "Film açıklaması")]
        [Required(ErrorMessage = "Bir film açıklaması girmelisiniz")]
        [StringLength(3000, MinimumLength = 10, ErrorMessage = "Film açıklaması 10-3000 karakter uzunluğunda olmalıdır!")]
        public string Description { get; set; }
        [Required(ErrorMessage ="En az 1 tür bilgisi seçmelisiniz!")]
        public int[] GenreIds { get; set; }

        public bool IsClassic { get; set; }

        [ClassicMovie(1950)]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; } = DateTime.Now;

    }

    public class AdminEditMovieViewModel
    {
        public int MovieId { get; set; }

        [Display(Name = "Film adı")]
        [Required(ErrorMessage = "Bir film adı girmelisiniz")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Film adı 3-50 karakter uzunluğunda olmalıdır!")]
        public string Title { get; set; }

        [Display(Name = "Film açıklaması")]
        [Required(ErrorMessage = "Bir film açıklaması girmelisiniz")]
        [StringLength(3000, MinimumLength = 10, ErrorMessage = "Film açıklaması 10-3000 karakter uzunluğunda olmalıdır!")]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<Genre> Genres { get; set; }
        [Required(ErrorMessage = "En az 1 tür bilgisi seçmelisiniz!")]
        public int[] GenreIds { get; set; }
    }

}
