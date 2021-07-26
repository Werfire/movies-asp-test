using System;
using System.Collections.Generic;

#nullable disable

namespace MoviesAspTest.Models
{
    public partial class MovieLike
    {
        public string UserId { get; set; }
        public Guid MovieId { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
