using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAspTest.Controllers
{
	public class SessionController : Controller
	{
		[HttpGet]
		public ActionResult Login()
		{
			return View("Login");
		}

		[HttpPost]
		public ActionResult Login(string login, string password)
		{
			return View("Login");
		}

		[HttpGet]
		public ActionResult Register()
		{
			return View("Register");
		}

		[HttpPost]
		public ActionResult Register(string login, string password)
		{
			return View("Register");
		}
	}
}
