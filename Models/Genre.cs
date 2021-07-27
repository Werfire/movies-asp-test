﻿using System;
using System.Collections.Generic;

#nullable disable

namespace MoviesAspTest.Models
{
    public partial class Genre
    {
	    public Genre()
	    {
		    Movies = new HashSet<Movie>();
	    }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
