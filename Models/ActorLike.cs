using System;
using System.Collections.Generic;

#nullable disable

namespace MoviesAspTest.Models
{
    public partial class ActorLike
    {
        public Guid UserId { get; set; }
        public Guid ActorId { get; set; }

        public virtual Actor Actor { get; set; }
        public virtual User User { get; set; }
    }
}
