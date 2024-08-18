using IDMT.Domain.Abstractions;
using IDMT.Domain.Abstractions.Specification;
using IDMT.Domain.SupportGroups;
using IDMT.Infrastructure.Specification;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace IDMT.Infrastructure.Repositories
{
	internal abstract class Repository<T> where T : Entity
	{
		protected readonly ApplicationDbContext DbContext;

		protected Repository(ApplicationDbContext dbContext)
		{
			DbContext = dbContext;
		}


		public async Task<IQueryable<T>> FindAllAsync(bool trackChanges = false) =>
!trackChanges ? await Task.Run(() => DbContext.Set<T>().AsNoTracking()) : await Task.Run(() => DbContext.Set<T>());

		public async Task<IQueryable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges = false) =>
			!trackChanges ? await Task.Run(() => DbContext.Set<T>().Where(expression).AsNoTracking()) : await Task.Run(() => DbContext.Set<T>().Where(expression));

		public async Task CreateAsync(T entity) => await Task.Run(() => DbContext.Set<T>().Add(entity));

		public async Task UpdateAsync(T entity) => await Task.Run(() => DbContext.Set<T>().Update(entity));
		public async Task RemoveAsync(T entity) => await Task.Run(() => DbContext.Set<T>().Remove(entity));

		public async Task<bool> AnyAsync(Expression<Func<T, bool>> criteria, CancellationToken cancellationToken = default)
				=> await DbContext.Set<T>().AnyAsync(criteria, cancellationToken);

		public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
		{
			return await DbContext
				.Set<T>()
				.FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
		}
		private IQueryable<T> ApplySpecification(ISpecification<T> specification)
		{
			return SpecificationEvaluator<T>.GetQuery(DbContext.Set<T>().AsQueryable(), specification);
		}

	}
}
