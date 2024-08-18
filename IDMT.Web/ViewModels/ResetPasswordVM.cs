using System.ComponentModel.DataAnnotations;

namespace IDMT.Web.ViewModels
{
	public class ResetPasswordVM
	{
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		[Display(Name = "Confirm Password")]
		public string ConfirmPassword { get; set; }
		public string Email { get; set; }
		public string Token { get; set; }
	}
}
