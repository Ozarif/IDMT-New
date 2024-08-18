using IDMT.Domain.Resources;
using IDMT.Domain.ResourcesProfiles;
using IDMT.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Infrastructure.Configurations
{
	internal class ResourceProfileConfiguration : IEntityTypeConfiguration<ResourceProfile>
	{
		public void Configure(EntityTypeBuilder<ResourceProfile> builder)
		{
			builder.ToTable("ResourcesProfiles");
			builder.HasKey(resourceProfile => resourceProfile.Id);

			builder.Property(resourceProfile => resourceProfile.Name)
				.HasMaxLength(150);


			builder.HasOne<Resource>()
					.WithMany()
					.HasForeignKey(resourceProfile => resourceProfile.ResourceId);
		}
	}
}
