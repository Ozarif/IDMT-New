using IDMT.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Domain.Positions
{
	public class PositionErrors
	{
		public static readonly Error NotFound = new(
							"Position.NotFound",
							"The position with the specified identifier was not found");

		public static readonly Error AlreadyAssigned = new(
		"Position.AlreadyAssigned",
		"This Resource is already assigned to the position.");
	}
}
