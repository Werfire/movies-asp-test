using System.ComponentModel.DataAnnotations;

namespace MoviesAspTest.ViewModels
{
	public class SignInViewModel
	{
		[Required]
		[StringLength(32)]
		public string Login { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[StringLength(32)]
		public string Password { get; set; }

		[Required]
		[Display(Name = "Remember me")]
		public bool RememberMe { get; set; }

		public string ReturnUrl { get; set; }
	}
}
