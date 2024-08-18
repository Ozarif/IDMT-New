using Microsoft.Extensions.Primitives;

namespace IDMT.Web.Models
{
	public class DataTableParam
	{
		public string? Draw { get; set; }
		public int PageSize { get; set; }
		public int Skip { get; set; }
		public StringValues SearchValue { get; set; }
		public StringValues SortColumn { get; set; }
		public StringValues SortColumnDirection { get; set; }
	}
}
