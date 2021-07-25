using System.ComponentModel.DataAnnotations;

namespace MoviesAspTest.ViewModels
{
	public class RegisterViewModel
	{
		[Required]
		[StringLength(32)]
		public string Login { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[StringLength(32)]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirm Password")]
		[Compare("Password", 
			ErrorMessage = "Password and confirmation password must match.")]
		public string ConfirmPassword { get; set; }
	}
}
