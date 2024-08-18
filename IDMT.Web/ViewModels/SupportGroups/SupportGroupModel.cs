using System.ComponentModel.DataAnnotations;

namespace IDMT.Web.ViewModels.SupportGroups
{
	public class SupportGroupModel
	{
		public Guid? Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required,EmailAddress]
		public string Email { get; set; }
	}
}
