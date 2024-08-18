using DDD.Application.Exceptions;
using IDMT.Application.Abstractions.Clock;
using IDMT.Application.Abstractions.Identity;
using IDMT.Domain.Abstractions;
using IDMT.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IDMT.Infrastructure
{
	public sealed class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IUnitOfWork
	{
		private readonly IDateTimeProvider _dateTimeProvider;
		private readonly ICurrentUserService _currentUserService;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
		IDateTimeProvider dateTimeProvider,
		ICurrentUserService currentUserService
	) : base(options)
		{
			_dateTimeProvider = dateTimeProvider;
			_currentUserService = currentUserService;
		}


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<ApplicationUser>().ToTable("Users", "security");
			modelBuilder.Entity<IdentityRole>().ToTable("Roles", "security");
			modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "security");
			modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "security");
			modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "security");
			modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "security");
			modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "security");
		}

		public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			try
			{
			

				foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
				{

					switch (entry.State)
					{
						case EntityState.Added:
							entry.Entity.CreatedBy = _currentUserService.UserFullName;
							entry.Entity.Created = _dateTimeProvider.UtcNow;
							break;
						case EntityState.Modified:
							entry.Entity.LastModifiedBy = _currentUserService.UserFullName;
							entry.Entity.LastModified = _dateTimeProvider.UtcNow;

							break;
					}
				}

				//AddDomainEventsAsOutboxMessages();

				int result = await base.SaveChangesAsync(cancellationToken);

				return result;
			}
			catch (DbUpdateConcurrencyException ex)
			{
				throw new ConcurrencyException("Concurrency exception occurred.", ex);
			}
		}
	}
}
