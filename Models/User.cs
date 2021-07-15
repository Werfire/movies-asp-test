using System;
using System.Collections.Generic;

#nullable disable

namespace MoviesAspTest
{
    public partial class User
    {
        public User()
        {
            ActorLikes = new HashSet<ActorLike>();
            MovieLikes = new HashSet<MovieLike>();
        }

        public string Login { get; set; }
        public string Password { get; set; }
        public Guid Id { get; set; }

        public virtual ICollection<ActorLike> ActorLikes { get; set; }
        public virtual ICollection<MovieLike> MovieLikes { get; set; }
    }
}
