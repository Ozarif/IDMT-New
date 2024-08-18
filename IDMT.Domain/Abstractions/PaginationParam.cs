using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Domain.Abstractions;

public abstract record PaginationParam 
{
	private int _pageSize = 10;
	private string? _search;

	public int MaxPageSize { get; init; } = 50;

	public int PageNumber { get; set; } = 1;

	public int PageSize
	{
		get
		{
			return _pageSize;
		}
		set
		{
			_pageSize = value > MaxPageSize ? MaxPageSize : value;
		}
	}

	public string? SortColumn { get; set; }

	public string? SortDirection { get; set; }
	public string? Search
	{
		get => _search;
		set => _search = value.ToLower();
	}
}
