using IDMT.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Domain.SupportGroups
{
    public interface ISupportGroupRepository
	{
		Task<SupportGroup?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
		Task<bool> AnyAsync(Expression<Func<SupportGroup, bool>> filter, CancellationToken cancellationToken = default);
		Task<PagedList<SupportGroup>> GetSupportGroupsAsync(SupportGroupPaginationParam supportGroupParams, CancellationToken cancellationToken = default);
		Task<IReadOnlyList<SupportGroup>> GetSupportGroupsAsync(Expression<Func<SupportGroup, bool>> filter, CancellationToken cancellationToken = default);
		Task CreateAsync(SupportGroup supportGroup);
		Task UpdateAsync(SupportGroup supportGroup);
	}
}
