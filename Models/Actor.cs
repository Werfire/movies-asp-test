using System;
using System.Collections.Generic;

#nullable disable

namespace MoviesAspTest
{
    public partial class Actor
    {
        public Actor()
        {
            ActorLikes = new HashSet<ActorLike>();
            ActorParticipations = new HashSet<ActorParticipation>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ActorLike> ActorLikes { get; set; }
        public virtual ICollection<ActorParticipation> ActorParticipations { get; set; }
    }
}
