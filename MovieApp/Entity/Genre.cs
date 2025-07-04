using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace MovieApp.Entity

{

    public class Genre
    {
        public int GenreId { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }

    }
}
