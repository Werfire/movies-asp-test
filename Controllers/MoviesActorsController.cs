using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAspTest.Controllers
{
	public class MoviesActorsController : Controller
	{
		public ActionResult Index()
		{
			return View(GetMoviesByName());
		}

		private List<Movie> GetMoviesByName()
		{
			using (MoviesActorsContext db = new MoviesActorsContext())
			{
				return db.Movies.OrderBy(m => m.Name).ToList();
			}
		}

		private List<Movie> GetMoviesByReleaseDate()
		{
			using (MoviesActorsContext db = new MoviesActorsContext())
			{
				return db.Movies.OrderByDescending(m => m.ReleaseDate).ToList();
			}
		}

		private List<Movie> GetMoviesByLikes()
		{
			using (MoviesActorsContext db = new MoviesActorsContext())
			{
				return db.Movies.OrderByDescending(m => m.MovieLikes.Count).ToList();
			}
		}

		private List<Actor> GetActorsByLikes()
		{
			using (MoviesActorsContext db = new MoviesActorsContext())
			{
				return db.Actors.OrderByDescending(a => a.ActorLikes.Count).ToList();
			}
		}

		private List<Movie> GetMoviesWithActor(Actor actor)
		{
			using (MoviesActorsContext db = new MoviesActorsContext())
			{
				return db.Movies.Where(m => m.ActorParticipations.Where(ap => ap.ActorId == actor.Id).Count() > 0).ToList();
			}
		}
	}
}
