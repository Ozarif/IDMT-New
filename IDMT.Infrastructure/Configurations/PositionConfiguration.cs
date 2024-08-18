using IDMT.Domain.Positions;
using IDMT.Domain.PositionsResources;
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


			builder.HasMany(a => a.PositionResources)
			.WithOne()
			.HasForeignKey(pr => pr.PositionId);
		}
	}
}
