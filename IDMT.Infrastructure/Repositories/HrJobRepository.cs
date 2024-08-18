using IDMT.Application.Models;
using IDMT.Domain.Abstractions;
using IDMT.Domain.Abstractions.Specification;
using IDMT.Domain.HrJobs;
using IDMT.Domain.Shared;
using IDMT.Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace IDMT.Infrastructure.Repositories
{
	internal sealed class HrJobRepository : Repository<HrJob>, IHrJobRepository
	{
        public HrJobRepository(ApplicationDbContext dbContext) : base(dbContext) { }

		public async Task<PagedList<HrJob>> GetHrJobsAsync(HrJobPaginationParam hrJobParams, CancellationToken cancellationToken = default)
		{
			IQueryable<HrJob> query = DbContext.Set<HrJob>();
			IEnumerable<HrJob> hrJobs;

			if (!string.IsNullOrEmpty(hrJobParams.Search))
			{
				query = query.Where(x => x.Name.ToLower().Contains(hrJobParams.Search.ToLower()));
			}

			if (!string.IsNullOrEmpty(hrJobParams.SortColumn) && !string.IsNullOrEmpty(hrJobParams.SortDirection))
			{
				var sortExpression = await HelperFunctions.GetSortExpressionAsync<HrJob>(hrJobParams.SortColumn);

				if (hrJobParams.SortDirection.ToLower() == OrderByDirection.Ascending.Code)
				{
					query = query.OrderBy(sortExpression);
				}
				else
				{
					query = query.OrderByDescending(sortExpression);
				}
			}

//return PagedData<HrJob>.Create(hrJobs,hrJobParams.PageNumber, hrJobParams.PageSize);
		return PagedList<HrJob>.ToPagedList(query, hrJobParams.PageNumber, hrJobParams.PageSize);
		}
	}
}
