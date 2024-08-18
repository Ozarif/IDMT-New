using IDMT.Domain.Abstractions;
using System.Linq.Expressions;

namespace IDMT.Domain.Positions
{
    public interface IPositionRepository
	{
		Task<IReadOnlyCollection<Position>?> GetAllAsync(Expression<Func<Position, bool>>? filter = null,
																Expression<Func<Position, object>>? orderBy = null,
																string orderByDirection = "asc",
																CancellationToken cancellationToken = default);
		Task<PagedList<Position>> GetAllAsync(PaginationParam param, CancellationToken cancellationToken = default);
		Task<Position?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
		Task CreateAsync(Position position);
	}
}
