using System;
using System.Collections.Generic;

#nullable disable

namespace MoviesAspTest
{
    public partial class MovieLike
    {
        public Guid UserId { get; set; }
        public Guid MovieId { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual User User { get; set; }
    }
}
