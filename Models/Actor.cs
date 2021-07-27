using System;
using System.Collections.Generic;

#nullable disable

namespace MoviesAspTest.Models
{
    public partial class Actor
    {
        public Actor()
        {
            UsersLiked = new HashSet<ApplicationUser>();
            Movies = new HashSet<Movie>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ApplicationUser> UsersLiked { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
