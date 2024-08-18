using IDMT.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Domain.HrJobs
{
	public static class HrJobErrors
	{
		public static readonly Error NotFound = new(
							"HrJob.NotFound",
							"The HR Job with the specified identifier was not found");


		public static readonly Error AlreadyAssigned = new(
							"HrJob.AlreadyAssigned",
							"This Hr Job is already assigned to employees.");

		public static readonly Error AlreadyExists = new(
							"HrJob.AlreadyExists",
							"This Hr Job is already existed.");
	}
}
