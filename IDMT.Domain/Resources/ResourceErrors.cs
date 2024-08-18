using IDMT.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Domain.Resources
{
	public static class ResourceErrors
	{
		public static readonly Error AlreadyAssigned = new(
										"Resource.AlreadyAssigned",
										"This Position is already assigned to the resource.");

		public static readonly Error NotFound = new(
								"Resource.NotFound",
								"Resource with the specified identifier was not found");
	}
}
