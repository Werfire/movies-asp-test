using System;
using System.Collections.Generic;

#nullable disable

namespace MoviesAspTest.Models
{
    public partial class MovieGenreJunction
    {
        public Guid MovieId { get; set; }
        public Guid GenreId { get; set; }
    }
}
