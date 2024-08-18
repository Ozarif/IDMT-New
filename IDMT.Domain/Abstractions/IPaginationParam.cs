using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Domain.Abstractions
{
	public interface IPaginationParam
	{
		int MaxPageSize { get; init; }

		int PageNumber { get; set; }

		int PageSize { get; set; }

		string? SortColumn { get; set; }

		string? SortDirection { get; set; }
		string? Search { get; set; }

	}
}
