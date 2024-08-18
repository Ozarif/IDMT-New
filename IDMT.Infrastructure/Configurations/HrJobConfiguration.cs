using IDMT.Domain.HrJobs;
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
	internal class HrJobConfiguration : IEntityTypeConfiguration<HrJob>
	{
		public void Configure(EntityTypeBuilder<HrJob> builder)
		{
			builder.ToTable("HrJobs");
			builder.HasKey(hrJob => hrJob.Id);

			builder.Property(hrJob => hrJob.Name)
			.HasMaxLength(150)
			.IsRequired();


			builder.HasIndex(hrJob => hrJob.Name).IsUnique();
		}
	}
}
