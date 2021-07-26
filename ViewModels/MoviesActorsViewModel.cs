using System;
using MoviesAspTest.Enums;
using MoviesAspTest.Models;
using System.Collections.Generic;

namespace MoviesAspTest.ViewModels
{
	public class MoviesActorsViewModel
	{
		public List<Movie> MoviesList { get; set; }
		public List<Actor> ActorsList { get; set; }
		public List<Guid> LikedMoviesIds { get; set; }
		public List<Guid> LikedActorsIds { get; set; }
		public MoviesActorsAction ActionName { get; set; }
		public string ActionDesc { get; set; }
	}
}
