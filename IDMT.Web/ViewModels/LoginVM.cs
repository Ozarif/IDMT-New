using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IDMT.Web.ViewModels
{
	public class LoginVM
	{
		[Required]
        [DisplayName("User ID")]
		public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
