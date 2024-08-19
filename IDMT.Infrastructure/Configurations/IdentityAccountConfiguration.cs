using IDMT.Domain.IdentityAccounts;
using IDMT.Domain.Employees;
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
    internal sealed class IdentityAccountConfiguration : IEntityTypeConfiguration<IdentityAccount>
	{
		public void Configure(EntityTypeBuilder<IdentityAccount> builder)
		{
			builder.ToTable("ActiveDirectoryAccounts");
			builder.HasKey(AdAccount => AdAccount.Id);

			builder.Property(AdAccount => AdAccount.LoginName)
				.HasMaxLength(50)
				.IsRequired();

			builder.Property(AdAccount => AdAccount.Profile)
					.HasMaxLength(150)
					.IsRequired();

			builder.HasIndex(AdAccount => AdAccount.LoginName).IsUnique();
		}
	}
}
