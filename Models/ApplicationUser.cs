using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace MoviesAspTest.Models
{
	public class ApplicationUser : IdentityUser
	{
		public ApplicationUser()
		{
			Actors = new HashSet<Actor>();
			Movies = new HashSet<Movie>();
		}

		public virtual ICollection<Actor> Actors { get; set; }
		public virtual ICollection<Movie> Movies { get; set; }
	}
}
