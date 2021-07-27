using System;

#nullable disable

namespace MoviesAspTest.Models
{
    public partial class MovieGenreJunction
    {
        public Guid MovieId { get; set; }
        public Guid GenreId { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
