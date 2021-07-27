using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesAspTest.Enums;
using MoviesAspTest.Models;
using MoviesAspTest.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

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
					model.ActionDesc = $"Movies starring {LightGetActor(actorId).Name}:";
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

			if (_action is MoviesActorsAction.GetMoviesByName or MoviesActorsAction.GetMoviesByReleaseDate or
				MoviesActorsAction.GetMoviesByLikes or MoviesActorsAction.GetMoviesWithActor)
				model.LikedMoviesIds = GetUserLikedMoviesIds();
			else if (_action is MoviesActorsAction.GetActorsByLikes)
				model.LikedActorsIds = GetUserLikedActorsIds();

			return View(model);
		}

		[Authorize]
		public ActionResult LikeMovie(Guid movieId)
		{
			using (MoviesTestContext db = new MoviesTestContext())
			{
				var user = db.AppUsers
					.Include(u => u.Movies)
					.Single(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));
				var movie = db.Movies
					.Single(m => m.Id == movieId);
				user.Movies.Add(movie);
				db.SaveChanges();
			}

			return View("Index", new MoviesActorsViewModel());
		}

		[Authorize]
		public ActionResult UnlikeMovie(Guid movieId)
		{
			using (MoviesTestContext db = new MoviesTestContext())
			{
				var user = db.AppUsers
					.Include(u => u.Movies)
					.Single(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));
				var movie = db.Movies
					.Single(m => m.Id == movieId);
				user.Movies.Remove(movie);
				db.SaveChanges();
			}

			return View("Index", new MoviesActorsViewModel());
		}

		[Authorize]
		public ActionResult LikeActor(Guid actorId)
		{
			using (MoviesTestContext db = new MoviesTestContext())
			{
				var user = db.AppUsers
					.Include(u => u.Actors)
					.Single(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));
				var actor = db.Actors
					.Single(a => a.Id == actorId);
				user.Actors.Add(actor);
				db.SaveChanges();
			}

			return View("Index", new MoviesActorsViewModel());
		}

		[Authorize]
		public ActionResult UnlikeActor(Guid actorId)
		{
			using (MoviesTestContext db = new MoviesTestContext())
			{
				var user = db.AppUsers
					.Include(u => u.Actors)
					.Single(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));
				var actor = db.Actors
					.Single(a => a.Id == actorId);
				user.Actors.Remove(actor);
				db.SaveChanges();
			}

			return View("Index", new MoviesActorsViewModel());
		}

		private Movie GetMovie(Guid movieId)
		{
			using (MoviesTestContext db = new MoviesTestContext())
			{
				return db.Movies.Include(m => m.UsersLiked)
					.Include(m => m.Actors)
					.Include(m => m.Genres)
					.First(m => m.Id == movieId);
			}
		}

		private Movie LightGetMovie(Guid movieId)
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
				return db.Actors.Include(a => a.UsersLiked)
					.Include(a => a.Movies)
					.First(a => a.Id == actorId);
			}
		}

		private Actor LightGetActor(Guid actorId)
		{
			using (MoviesTestContext db = new MoviesTestContext())
			{
				return db.Actors.First(a => a.Id == actorId);
			}
		}

		private List<Movie> GetMoviesByName()
		{
			using (MoviesTestContext db = new MoviesTestContext())
			{
				return db.Movies.OrderBy(m => m.Name).Include(m => m.UsersLiked).ToList();
			}
		}

		private List<Movie> GetMoviesByReleaseDate()
		{
			using (MoviesTestContext db = new MoviesTestContext())
			{
				return db.Movies.OrderByDescending(m => m.ReleaseDate).Include(m => m.UsersLiked).ToList();
			}
		}

		private List<Movie> GetMoviesByLikes()
		{
			using (MoviesTestContext db = new MoviesTestContext())
			{
				return db.Movies.OrderByDescending(m => m.UsersLiked.Count).Include(m => m.UsersLiked).ToList();
			}
		}

		private List<Actor> GetActorsByLikes()
		{
			using (MoviesTestContext db = new MoviesTestContext())
			{
				return db.Actors.OrderByDescending(a => a.UsersLiked.Count).Include(a => a.UsersLiked).ToList();
			}
		}

		private List<Movie> GetMoviesWithActor(Guid actorId)
		{
			using (MoviesTestContext db = new MoviesTestContext())
			{
				return db.Movies.Where(m => m.Actors.Any(a => a.Id == actorId)).Include(m => m.UsersLiked).ToList();
			}
		}

		private List<Guid> GetUserLikedMoviesIds()
		{
			using (MoviesTestContext db = new MoviesTestContext())
			{
				return db.Movies.Where(m =>
						m.UsersLiked.Any(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)))
					.Select(m => m.Id).ToList();
			}
		}

		private List<Guid> GetUserLikedActorsIds()
		{
			using (MoviesTestContext db = new MoviesTestContext())
			{
				return db.Actors.Where(a =>
						a.UsersLiked.Any(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)))
					.Select(a => a.Id).ToList();
			}
		}
	}
}
