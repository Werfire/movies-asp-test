using System;
using System.Collections.Generic;

#nullable disable

namespace MoviesAspTest
{
    public partial class ActorParticipation
    {
        public Guid MovieId { get; set; }
        public Guid ActorId { get; set; }

        public virtual Actor Actor { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
