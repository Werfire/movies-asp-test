using System;

#nullable disable

namespace MoviesAspTest.Models
{
    public partial class ActorLike
    {
        public string UserId { get; set; }
        public Guid ActorId { get; set; }

        public virtual Actor Actor { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
