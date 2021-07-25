using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoviesAspTest.ViewModels;

namespace MoviesAspTest.Controllers
{
	public class UserController : Controller
	{
		private readonly UserManager<IdentityUser> userManager;
		private readonly SignInManager<IdentityUser> signInManager;

		public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
		}

		[HttpGet]
		public ActionResult SignIn()
		{
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> SignIn(SignInViewModel model)
		{
			if (!ModelState.IsValid)
				return View(model);

			var user = await userManager.FindByNameAsync(model.Login);

			if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
				await signInManager.SignInAsync(user, model.RememberMe);
			else
			{
				ModelState.AddModelError("", "Wrong login or password.");
				return View(model);
			}

			return model.ReturnUrl == null ? RedirectToAction("Index", "MoviesActors") : Redirect(model.ReturnUrl);
		}

		public async Task<ActionResult> Logout()
		{
			await signInManager.SignOutAsync();
			return RedirectToAction("Index", "MoviesActors");
		} 

		[HttpGet]
		public ActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> Register(RegisterViewModel model)
		{
			if (!ModelState.IsValid)
				return View(model);

			var user = new IdentityUser
			{
				UserName = model.Login,
			};
			var result = await userManager.CreateAsync(user, model.Password);

			if (!result.Succeeded)
			{
				foreach(var error in result.Errors)
					ModelState.AddModelError("", error.Description);
				return View(model);
			}

			return RedirectToAction("SignIn", "User");
		}
	}
}
