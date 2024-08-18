using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IDMT.Web.ViewModels
{
	public class RegisterUserVM
	{

		[Required]
        [DisplayName("Login User Name")]
        public string UserName { get; set; }
		[Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
		[DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }

        [DisplayName("Role")]
        public string? Role { get; set; }

		[ValidateNever]
		public IEnumerable<SelectListItem>? RoleList { get; set; }
	}
}
