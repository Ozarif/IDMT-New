using IDMT.Domain.Employees;
using IDMT.Domain.HrJobs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Infrastructure.Configurations
{
	internal sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
	{
		public void Configure(EntityTypeBuilder<Employee> builder)
		{
			builder.ToTable("Employees");

			builder.HasKey(employee => employee.Id);
			builder.Property(employee => employee.HrId)
				.HasMaxLength(100)
				.IsRequired();
			builder.Property(employee => employee.FirstName)
				.HasMaxLength(100);

			builder.Property(employee => employee.FatherName)
				.HasMaxLength(100);

			builder.Property(employee => employee.LastName)
				.HasMaxLength(100);

			builder.Property(employee => employee.SpouseName)
				.HasMaxLength(100);

			builder.HasOne<HrJob>()
				.WithMany()
				.HasForeignKey(hrJob => hrJob.HrJobId);
			
			builder.HasMany(a => a.Accounts)
				.WithOne()
				.HasForeignKey(AdAccount => AdAccount.EmployeeId);


			builder.HasIndex(Employee => Employee.HrId).IsUnique();

		}
	}
}
