using IDMT.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Application.Features.Employees.Shared
{
	public sealed class EmployeeResponse
	{
		public Guid Id { get; set; }
		public string HrId { get; set; }
		public string FirstName { get; set; }
		public string FatherName { get; set; }
		public string LastName { get; set; }
		public string? SpouseName { get; set; }
		public Guid HrJobId { get; set; }
	}
}
