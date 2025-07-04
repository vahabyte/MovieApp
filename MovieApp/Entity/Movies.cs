using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Entity
{
    public class Movie
    {

        public Movie()
        {
            Genres = new List<Genre>();
        }

        public int MovieId { get; set; }
        public string Title { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<Genre> Genres { get; set; }
        public int GenreId { get; set; }

    }
}
