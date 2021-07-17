using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAspTest.Models;
using MoviesAspTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAspTest.Controllers
{
	public class MoviesActorsController : Controller
	{
		public ViewResult Index(string _action = null, Actor actor = null)
		{
			MoviesActorsViewModel model = new MoviesActorsViewModel();
			model.actionName = _action;

			if (_action == "get_movies_by_name")
			{
				model.moviesList = GetMoviesByName();
				model.actionDesc = "Movies ordered by name:";
			}
			else if (_action == "get_movies_by_release_date")
			{
				model.moviesList = GetMoviesByReleaseDate();
				model.actionDesc = "Movies ordered by release date:";
			}
			else if (_action == "get_movies_by_likes")
			{
				model.moviesList = GetMoviesByLikes();
				model.actionDesc = "Movies ordered by popularity:";
			}
			else if (_action == "get_actors_by_likes")
			{
				model.actorsList = GetActorsByLikes();
				model.actionDesc = "Actors ordered by popularity:";
			}
			else if (_action == "get_movies_with_actor")
			{
				model.moviesList = GetMoviesWithActor(actor);
				model.actionDesc = string.Format("Movies starring {0}:", actor.Name);
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
