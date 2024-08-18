using Azure.Core;
using IDMT.Application.Models;
using IDMT.Domain.Abstractions;
using IDMT.Domain.Abstractions.Specification;
using IDMT.Domain.SupportGroups;
using IDMT.Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;


namespace IDMT.Infrastructure.Repositories
{
	internal sealed class SupportGroupRepository : Repository<SupportGroup>, ISupportGroupRepository
	{
		public SupportGroupRepository(ApplicationDbContext dbContext) : base(dbContext) { }


		public async Task<PagedList<SupportGroup>> GetSupportGroupsAsync(SupportGroupPaginationParam param, CancellationToken cancellationToken = default)
		{
			var query = await FindAllAsync();

			if (!string.IsNullOrEmpty(param.Search))
			{
				var t = 
				query = query.Where(a => string.IsNullOrEmpty(param.Search) ? true
																	:  a.Name.Contains(param.Search.ToLower()));
			}

			if (!string.IsNullOrEmpty(param.SortColumn) && !string.IsNullOrEmpty(param.SortDirection))
			{
				var sortExpression = await HelperFunctions.GetSortExpressionAsync<SupportGroup>(param.SortColumn);

				if (param.SortDirection.ToLower() == OrderByDirection.Ascending.Code)
				{
					query = query.OrderBy(sortExpression);
				}
				else
				{
					query = query.OrderByDescending(sortExpression);
				}
			}


			return  PagedList<SupportGroup>.ToPagedList(query, param.PageNumber, param.PageSize);
		}

		public Task<IReadOnlyList<SupportGroup>> GetSupportGroupsAsync(Expression<Func<SupportGroup, bool>> filter, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}
	}
}
