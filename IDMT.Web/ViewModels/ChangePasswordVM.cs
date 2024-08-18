using System.ComponentModel.DataAnnotations;

namespace IDMT.Web.ViewModels
{
    public class ChangePasswordVM
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current Password")]
        public string CurrentPassword { get; set; } 
        
        [Required]
        [DataType(DataType.Password)]
		[Display(Name = "New Password")]
		public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation new password do not match.")]
		[Display(Name = "Confirm New Password")]
		public string ConfirmNewPassword { get; set; }
    }
}
