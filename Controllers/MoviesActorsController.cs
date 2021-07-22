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
			MoviesActorsViewModel model = new MoviesActorsViewModel();
			model.actionName = _action;

			switch (_action)
			{
				case MoviesActorsAction.GetMoviesByName:
					model.moviesList = GetMoviesByName();
					model.actionDesc = "Movies ordered by name:";
					break;
				case MoviesActorsAction.GetMoviesByReleaseDate:
					model.moviesList = GetMoviesByReleaseDate();
					model.actionDesc = "Movies ordered by release date:";
					break;
				case MoviesActorsAction.GetMoviesByLikes:
					model.moviesList = GetMoviesByLikes();
					model.actionDesc = "Movies ordered by popularity:";
					break;
				case MoviesActorsAction.GetActorsByLikes:
					model.actorsList = GetActorsByLikes();
					model.actionDesc = "Actors ordered by popularity:";
					break;
				case MoviesActorsAction.GetMoviesWithActor:
					model.moviesList = GetMoviesWithActor(actor);
					model.actionDesc = string.Format("Movies starring {0}:", actor.Name);
					break;
			}

			return View(model);
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
