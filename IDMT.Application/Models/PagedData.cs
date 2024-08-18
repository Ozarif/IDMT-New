using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Application.Models
{
	public class PagedData<T> 
	{
		public IEnumerable<T> PagedList { get; private set; }
		public int CurrentPage { get; private set; }
		public int TotalPages { get; private set; }
		public int PageSize { get; private set; }
		public int TotalCount { get; private set; }
		public bool HasPrevious => CurrentPage > 1;
		public bool HasNext => CurrentPage < TotalPages;

		public PagedData(IEnumerable<T> List, int pageNumber, int pageSize)
		{
			PagedList = List;
			TotalCount = List.Count();
			PageSize = pageSize;
			CurrentPage = pageNumber;
			TotalPages = (int)Math.Ceiling(TotalCount / (double)pageSize);
		}
		public static PagedData<T> Create(IEnumerable<T> List, int pageNumber, int pageSize)
		{
			return new PagedData<T>(List,pageNumber,pageSize);
		}

	}
}
