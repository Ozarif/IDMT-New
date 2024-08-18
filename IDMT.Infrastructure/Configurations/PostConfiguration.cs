using IDMT.Domain.Employees;
using IDMT.Domain.Positions;
using IDMT.Domain.Posts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IDMT.Infrastructure.Configurations
{
	public class PostConfiguration : IEntityTypeConfiguration<Post>
	{
		public void Configure(EntityTypeBuilder<Post> builder)
		{
			builder.ToTable("Posts");
			builder.HasKey(post => post.Id);

			builder.OwnsOne(post => post.Duration);


			builder.HasOne<Employee>()
					.WithMany()
					.HasForeignKey(post => post.EmployeeId);

			builder.HasOne<Position>()
					.WithMany()
					.HasForeignKey(post => post.PositionId);


		}
	}
}
