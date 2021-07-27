using System;
using System.Collections.Generic;

#nullable disable

namespace MoviesAspTest.Models
{
    public partial class Movie
    {
        public Movie()
        {
            Actors = new HashSet<Actor>();
            UsersLiked = new HashSet<ApplicationUser>();
            Genres = new HashSet<Genre>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public TimeSpan? Duration { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }
        public virtual ICollection<ApplicationUser> UsersLiked { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
    }
}
