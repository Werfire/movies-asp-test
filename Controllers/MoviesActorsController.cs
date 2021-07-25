using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesAspTest.Enums;
using MoviesAspTest.Models;
using MoviesAspTest.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace MoviesAspTest.Enums
{
	public enum MoviesActorsAction
	{
		None, GetMoviesByName, GetMoviesByReleaseDate, GetMoviesByLikes, GetActorsByLikes, GetMoviesWithActor
	}
}

namespace MoviesAspTest.Controllers
{
	public class MoviesActorsController : Controller
	{
		public ViewResult Index(MoviesActorsAction _action = MoviesActorsAction.None, Actor actor = null)
		{
			MoviesActorsViewModel model = new MoviesActorsViewModel {ActionName = _action};
			
			switch (_action)
			{
				case MoviesActorsAction.GetMoviesByName:
					model.MoviesList = GetMoviesByName();
					model.ActionDesc = "Movies ordered by name:";
					break;
				case MoviesActorsAction.GetMoviesByReleaseDate:
					model.MoviesList = GetMoviesByReleaseDate();
					model.ActionDesc = "Movies ordered by release date:";
					break;
				case MoviesActorsAction.GetMoviesByLikes:
					model.MoviesList = GetMoviesByLikes();
					model.ActionDesc = "Movies ordered by popularity:";
					break;
				case MoviesActorsAction.GetActorsByLikes:
					model.ActorsList = GetActorsByLikes();
					model.ActionDesc = "Actors ordered by popularity:";
					break;
				case MoviesActorsAction.GetMoviesWithActor:
					model.MoviesList = GetMoviesWithActor(actor);
					model.ActionDesc = $"Movies starring {actor.Name}:";
					break;
			}

			return View(model);
		}

		[Authorize]
		public ActionResult Like()
		{
			return View("Index");
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
				return db.Movies.Where(m => m.ActorParticipations.Any(ap => ap.ActorId == actor.Id)).ToList();
			}
		}

		private void LikeMovie(Movie movie)
		{

		}

		private void UnlikeMovie(Movie movie)
		{

		}

		private void LikeActor(Actor actor)
		{

		}

		private void UnlikeActor(Actor actor)
		{

		}
	}
}
