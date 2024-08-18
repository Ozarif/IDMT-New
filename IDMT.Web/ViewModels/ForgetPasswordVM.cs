using System.ComponentModel.DataAnnotations;

namespace IDMT.Web.ViewModels
{
	public class ForgetPasswordVM
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }
	}
}
