using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Domain.Abstractions.Specification;

public sealed record OrderByDirection
{
	internal static readonly OrderByDirection None = new("");
	public static readonly OrderByDirection Ascending = new("asc");
	public static readonly OrderByDirection Descending = new("desc");


	private OrderByDirection(string direction) => Code = direction;

	public string Code { get; init; }

	public static readonly IReadOnlyCollection<OrderByDirection> All = new[]
{
		Ascending,
		Descending
	};
}
