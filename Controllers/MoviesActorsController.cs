using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesAspTest.Enums;
using MoviesAspTest.Models;
using MoviesAspTest.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace MoviesAspTest.Enums
{
	public enum MoviesActorsAction
	{
		None, GetMoviesByName, GetMoviesByReleaseDate, GetMoviesByLikes, GetActorsByLikes, GetMoviesWithActor, 
		GetMovieInfo, GetActorInfo
	}
}

namespace MoviesAspTest.Controllers
{
	public class MoviesActorsController : Controller
	{
		public ActionResult Index(MoviesActorsAction _action = MoviesActorsAction.None, Guid movieId = new(), Guid actorId = new())
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
					model.MoviesList = GetMoviesWithActor(actorId);
					model.ActionDesc = $"Movies starring {GetActor(actorId).Name}:";
					break;
				case MoviesActorsAction.GetMovieInfo:
					Movie movie = GetMovie(movieId);
					model.MoviesList = new List<Movie> {movie};
					model.ActionDesc = movie.Name + ":";
					break;
				case MoviesActorsAction.GetActorInfo:
					Actor actor = GetActor(actorId);
					model.ActorsList = new List<Actor> {actor};
					model.ActionDesc = actor.Name + ":";
					break;
			}

			return View(model);
		}

		[Authorize]
		public ActionResult LikeMovie(Guid movieId)
		{
			using (MoviesTestContext db = new MoviesTestContext())
			{
				db.MovieLikes.Add(new MovieLike
				{
					UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
					MovieId = movieId
				});
				db.SaveChanges();
			}

			return View("Index", new MoviesActorsViewModel());
		}

		[Authorize]
		public ActionResult LikeActor(Guid actorId)
		{
			using (MoviesTestContext db = new MoviesTestContext())
			{
				db.ActorLikes.Add(new ActorLike
				{
					UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
					ActorId = actorId
				});
				db.SaveChanges();
			}

			return View("Index", new MoviesActorsViewModel());
		}

		private List<Movie> GetMoviesByName()
		{
			using (MoviesTestContext db = new MoviesTestContext())
			{
				return db.Movies.OrderBy(m => m.Name).ToList();
			}
		}

		private List<Movie> GetMoviesByReleaseDate()
		{
			using (MoviesTestContext db = new MoviesTestContext())
			{
				return db.Movies.OrderByDescending(m => m.ReleaseDate).ToList();
			}
		}

		private List<Movie> GetMoviesByLikes()
		{
			using (MoviesTestContext db = new MoviesTestContext())
			{
				return db.Movies.OrderByDescending(m => m.MovieLikes.Count).ToList();
			}
		}

		private List<Actor> GetActorsByLikes()
		{
			using (MoviesTestContext db = new MoviesTestContext())
			{
				return db.Actors.OrderByDescending(a => a.ActorLikes.Count).ToList();
			}
		}

		private List<Movie> GetMoviesWithActor(Guid actorId)
		{
			using (MoviesTestContext db = new MoviesTestContext())
			{
				return db.Movies.Where(m => m.ActorParticipations.Any(ap => ap.ActorId == actorId)).ToList();
			}
		}

		private Movie GetMovie(Guid movieId)
		{
			using (MoviesTestContext db = new MoviesTestContext())
			{
				return db.Movies.First(m => m.Id == movieId);
			}
		}

		private Actor GetActor(Guid actorId)
		{
			using (MoviesTestContext db = new MoviesTestContext())
			{
				return db.Actors.First(a => a.Id == actorId);
			}
		}
	}
}
