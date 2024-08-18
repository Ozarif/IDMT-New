using IDMT.Domain.Abstractions;
using IDMT.Domain.Positions;
using System.Linq.Expressions;

namespace IDMT.Infrastructure.Repositories
{
	internal class PositionRepository : Repository<Position>, IPositionRepository
	{
		public PositionRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}

		public Task<PagedList<Position>> GetAllAsync(PaginationParam param, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}

		public Task<IReadOnlyCollection<Position>?> GetAllAsync(Expression<Func<Position, bool>>? filter = null, Expression<Func<Position, object>>? orderBy = null, string orderByDirection = "asc", CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}
	}
}
