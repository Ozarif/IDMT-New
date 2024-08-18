using IDMT.Domain.Abstractions;
using IDMT.Domain.SupportGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Domain.HrJobs
{
	public interface IHrJobRepository
	{
		Task<HrJob?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
		Task<bool> AnyAsync(Expression<Func<HrJob, bool>> filter,CancellationToken cancellationToken = default);
		Task<PagedList<HrJob>> GetHrJobsAsync(HrJobPaginationParam hrJobParams, CancellationToken cancellationToken = default);
		Task CreateAsync(HrJob hrJob);
		Task UpdateAsync(HrJob hrJob);
		Task RemoveAsync(HrJob hrJob);
	}
}
