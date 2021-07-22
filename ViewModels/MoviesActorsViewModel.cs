using MoviesAspTest.Enums;
using MoviesAspTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAspTest.ViewModels
{
	public class MoviesActorsViewModel
	{
		public List<Movie> moviesList { get; set; }
		public List<Actor> actorsList { get; set; }
		public MoviesActorsAction actionName { get; set; }
		public string actionDesc { get; set; }
	}
}
