using IDMT.Domain.Positions;
using IDMT.Domain.PositionsResources;
using IDMT.Domain.Resources;
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
	internal class PositionConfiguration : IEntityTypeConfiguration<Position>
	{
		public void Configure(EntityTypeBuilder<Position> builder)
		{
			builder.ToTable("Positions");
			builder.HasKey(position => position.Id);


			builder.Property(Position => Position.Name)
						.HasMaxLength(150);


			// builder.HasMany(a => a.PositionResources)
			// .WithOne()
			// .HasForeignKey(pr => pr.PositionId);
			builder
            .HasMany(e => e.Resources)
            .WithMany(e => e.Positions)
            .UsingEntity<Dictionary<string, object>>(
                "PositionsResources",
                j => j
                    .HasOne<Resource>()
                    .WithMany()
                    .HasForeignKey("ResourceId")
                    .HasConstraintName("FK_PositionsResources_ResourceId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasOne<Position>()
                    .WithMany()
                    .HasForeignKey("PositionId")
                    .HasConstraintName("FK_PositionsResources_PositionId")
                    .OnDelete(DeleteBehavior.Cascade));
		}
	}
}
