using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace MoviesAspTest.Models
{
	public class ApplicationUser : IdentityUser
	{
		public List<ActorLike> ActorLikes { get; set; }
		public List<MovieLike> MovieLikes { get; set; }
	}
}
