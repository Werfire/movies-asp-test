using System;
using System.Collections.Generic;

#nullable disable

namespace MoviesAspTest.Models
{
    public partial class Movie
    {
        public Movie()
        {
            ActorParticipations = new HashSet<ActorParticipation>();
            MovieLikes = new HashSet<MovieLike>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public TimeSpan? Duration { get; set; }

        public virtual ICollection<ActorParticipation> ActorParticipations { get; set; }
        public virtual ICollection<MovieLike> MovieLikes { get; set; }
    }
}
