using IDMT.Domain.Posts;
using IDMT.Domain.Resources;
using IDMT.Domain.SupportGroups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Infrastructure.Configurations
{
	internal class PostResourceConfiguration : IEntityTypeConfiguration<PostResource>
	{
		public void Configure(EntityTypeBuilder<PostResource> builder)
		{
			builder.ToTable("PostsResources");
			builder.HasKey(postsResources => postsResources.Id);

			builder.HasOne<Resource>()
				.WithMany()
				.HasForeignKey(resource => resource.ResourceId);

		}
	}
}
